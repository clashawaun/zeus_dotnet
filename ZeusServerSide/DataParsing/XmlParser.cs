using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeusServerSide.DataParsing
{
    public class XmlParser : IParser
    {
        /// <summary>
        /// The parse data.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public T ParseData<T>(string data)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The serialize data.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public string SerializeData(object data)
        {
            throw new NotImplementedException();
        }
    }
}
