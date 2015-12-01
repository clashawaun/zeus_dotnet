using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusEntities.Communication;
using ZeusEntities.Type;
using ZeusServerSide.DataParsing;
using ZeusServerSide.Entities;

namespace ZeusServerSide.Core.Error
{
    public static class ErrorFactory
    {
        public static IServerMessage GetError(string message, int errorCode, DataType responseFormat)
        {
            switch (errorCode)
            {
                case 100:
                {
                    return new ServerMessage(message + "Error", ConvertErrorToString(new ErrorResponse()
                    {
                        Reason = "Operation invoked is not available on the server",
                        Code = 100
                    }, 
                    responseFormat));
                }
                case 101:
                    {
                        return new ServerMessage(message + "Error", ConvertErrorToString(new ErrorResponse()
                        {
                            Reason = "Incorrect DTO was used",
                            Code = 101
                        }, 
                        responseFormat));
                    }

                case 102:
                    {
                        return new ServerMessage(message + "Error", ConvertErrorToString(new ErrorResponse()
                        {
                            Reason = "Invalid ID provided for an entity in the database",
                            Code = 102
                        }, 
                        responseFormat));
                    }

                case 103:
                    {
                        return new ServerMessage(message + "Error", ConvertErrorToString(new ErrorResponse()
                        {
                            Reason = "One or more of the products provided were invalid",
                            Code = 103
                        }, 
                        responseFormat));
                    } 
                case 104:
                {
                    return new ServerMessage(message + "Error", ConvertErrorToString(new ErrorResponse()
                    {
                        Reason = "Items not available to fulfill a product in order",
                        Code = 104
                    },
                    responseFormat));
                }
                default:
                {
                    return null;
                }
            }
        }

        private static string ConvertErrorToString(ErrorResponse error, DataType responseFormat)
        {
            return ParserFactory.GetDataParser(responseFormat).SerializeData(error);
        }
    }
}
