using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusEntities.Communication;
using ZeusEntities.DTO;
using ZeusEntities.State;
using ZeusServerSide.Core.Communication;
using ZeusServerSide.Core.Error;
using ZeusServerSide.DataParsing;
using ZeusServerSide.Entities;
using ZeusServerSide.Persistance;
using ZeusServerSide.Utils;

namespace ZeusServerSide.Core.Operations
{
    /// <summary>
    /// The process order.
    /// </summary>
    public class ProcessOrder
    {
        public async Task<IServerMessage> GenerateResponse(IServerMessage request)
        {
            var orderDto = ParserFactory.GetDataParser(request.DataType).ParseData<OrderDto>(request.Body);

            var products = new List<Product>();
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Parallel.ForEach(orderDto.Products.Select(x => x.Id).ToList(), (currentProductId) =>
            {
                var unitOfWork = new UnitOfWork();
                var product = unitOfWork.ProductRepository.GetOrDefault(currentProductId);
                if (product == null)
                {
                    return;
                }
                lock (products)
                {
                    products.Add(product);
                }
            });
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);

            if (products.Count < orderDto.Products.Count)
            {
                return ErrorFactory.GetError(request.Message, 103, request.DataType);
            }

            var itemsForfulfilment = new List<IItem>();
            foreach (var product in products)
            {
                var bestItemPriority = -1;
                var availableItems = new UnitOfWork().ItemRepository.GetAvailableItemByProduct(product);
                var bestItem = availableItems.FirstOrDefault();
                var itemLock = new object();
                if (bestItem == null)
                {
                    return ErrorFactory.GetError(request.Message, 104, request.DataType);
                }

                Parallel.ForEach(availableItems.Where(i => itemsForfulfilment.All(x => x.Id != i.Id)), (item) =>
                {
                    // This is executed in parallel because it may become the case in the future
                    // that the algortihm that calculates the priority for a specifc product
                    // is computationally expensive and as such this is a good candidate for 
                    // threading, although concurrently the gains are minimal if any!
                    // It will also improve performance as the stock of a product grows
                    // -- Strategy --
                    var itemPriority = product.Priority.CalculatePriority(item, product);
                    lock (itemLock)
                    {
                        if (itemPriority > bestItemPriority)
                        {
                            bestItem = item;
                            bestItemPriority = itemPriority;
                        }
                    }
                });
                itemsForfulfilment.Add(bestItem);
            }

            // Now we need to make changes to the add them to the relevant sector and
            // update the state. Unit of work encapsulates all below operations
            var updateItems = new UnitOfWork();
            foreach (var item in itemsForfulfilment)
            {
                item.State = ItemState.AwaitingPicker;
                item.QueuedTime = DateTime.Now;
                updateItems.ItemRepository.Update(item);
            }

            // Create the order and commit it to persistance
            var order = new Order()
            {
                Items = itemsForfulfilment,
                Status = OrderStatus.Recieved,
                ShippingAddress = orderDto.ShippingAddress
            };
            updateItems.OrderRepository.Add(order);
            await updateItems.SaveChangesAsync();

            // End of unit of work, changes have been saved
            // ------
            // Lets inform the user that there order has been processed. We are going to use the 
            // bridge in this case
            var customer = ParserFactory.GetDataParser(request.DataType).ParseData<Customer>(request.User);
            var communication = new UserCommunication()
            {
                Subject = "Order Update ",
                Endpoint = customer.Phone,
                Body = $" Hey {customer.Firstname}, your order has been placed successfully. Thanks for using Zeus Solutions." +
                       $" Your order will be shipped to {orderDto.ShippingAddress}"
            };

            // Use SMS to send order info - BRIDGE
            communication.CommunicationCommunicator = new SmsSender();
            communication.Send();
            return new ServerMessage(request.Message + "Result", ParserFactory.GetDataParser(request.DataType).SerializeData(new OrderResultDto() { Success = true }));
        }
    }
}
