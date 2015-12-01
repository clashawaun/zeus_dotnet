using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZeusServerSide.Entities;

namespace ZeusUnitTests
{
    /// <summary>
    /// The error factory unit test.
    /// </summary>
    [TestClass]
    public class PriorityTest
    {
        /// <summary>
        /// The check error output test.
        /// </summary>
        [TestMethod]
        public void PrioriryFactoryTest()
        {
            var priority = PriorityFactory.GetPriority(1);
            Assert.AreNotEqual(priority, null);
        }

    }
}
