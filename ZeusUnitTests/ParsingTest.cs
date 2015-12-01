using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZeusEntities.Type;
using ZeusServerSide.DataParsing;
using ZeusServerSide.Entities;

namespace ZeusUnitTests
{
    /// <summary>
    /// The parsing test.
    /// </summary>
    [TestClass]
    public class ParsingTest
    {
        [TestMethod]
        public void TestJsonParser()
        {
            var parser = ParserFactory.GetDataParser(DataType.Json);
            var sampleObject = new ErrorResponse() { Code = 0, Reason = "Unit testing" };
            var sampleObjectAsString = parser.SerializeData(sampleObject);
            Assert.IsTrue(sampleObjectAsString.Contains("{\"Reason\":\"Unit testing\",\"Code\":0}"));
            var sampleObjectParsed = parser.ParseData<ErrorResponse>(sampleObjectAsString);
            Assert.IsTrue(sampleObjectParsed.Reason.Equals(sampleObject.Reason) && sampleObjectParsed.Code == sampleObject.Code);
        }
    }
}
