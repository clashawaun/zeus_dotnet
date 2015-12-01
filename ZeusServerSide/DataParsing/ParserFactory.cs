using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusEntities.Type;

namespace ZeusServerSide.DataParsing
{
    public class ParserFactory
    {
        public static IParser GetDataParser(DataType type)
        {
            switch(type)
            {
                case DataType.Json:
                    {
                        return new JsonParser();
                    }
                case DataType.Xml:
                    {
                        return new XmlParser();
                    }
                default:
                    return null;
            }
        }
    }
}
