using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusServerSide.Persistance.Context;

namespace ZeusServerSide.Persistance
{
    /// <summary>
    /// The unit of work.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The _product repository.
        /// </summary>
        private ProductRepository _productRepository;

        private CubbyRepository _cubbyRepository;

        private ItemRepository _itemRepository;

        private PriorityRepository _priorityRepository;

        private ShelfRepository _shelfRepository;

        private OrderRepository _orderRepository;

        private SectorRepository _sectorRepository;

        /// <summary>
        /// Gets the context.
        /// </summary>
        public DbContext Context { get; } = new ZeusDbContext();

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }

        public ProductRepository ProductRepository
        {
            get
            {
                if (this._productRepository == null)
                {
                    this._productRepository = new ProductRepository((ZeusDbContext)Context);
                }
                return _productRepository;
            }
        }

        public CubbyRepository CubbyRepository
        {
            get
            {
                if (this._cubbyRepository == null)
                {
                    this._cubbyRepository = new CubbyRepository((ZeusDbContext)Context);
                }
                return _cubbyRepository;
            }
        }

        public ItemRepository ItemRepository
        {
            get
            {
                if (this._itemRepository == null)
                {
                    this._itemRepository = new ItemRepository((ZeusDbContext)Context);
                }
                return _itemRepository;
            }
        }

        public PriorityRepository PriorityRepository
        {
            get
            {
                if (this._priorityRepository == null)
                {
                    this._priorityRepository = new PriorityRepository((ZeusDbContext)Context);
                }
                return _priorityRepository;
            }
        }

        public ShelfRepository ShelfRepository
        {
            get
            {
                if (this._shelfRepository == null)
                {
                    this._shelfRepository = new ShelfRepository((ZeusDbContext)Context);
                }
                return _shelfRepository;
            }
        }

        public OrderRepository OrderRepository
        {
            get
            {
                if (this._orderRepository == null)
                {
                    this._orderRepository = new OrderRepository((ZeusDbContext)Context);
                }
                return _orderRepository;
            }
        }

        public SectorRepository SectorRepository
        {
            get
            {
                if (this._sectorRepository == null)
                {
                    this._sectorRepository = new SectorRepository((ZeusDbContext)Context);
                }
                return _sectorRepository;
            }
        }
    }
}
