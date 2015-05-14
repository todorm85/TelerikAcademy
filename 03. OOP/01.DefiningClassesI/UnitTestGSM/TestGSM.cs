using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhone;

namespace UnitTestGSM
{
    [TestClass]
    public class TestGSM
    {
        private static GSM testGSM;

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GSMNegativePrice()
        {
            // test should throw an arguement exception if it is to be valid (price can`t be negative!
            testGSM = new GSM("unknown", "random", -5, "random", new Battery("unknown"), new Display());
        }

        [TestMethod]
        [TestInitialize]
        public void GSMInit()
        {
            testGSM = new GSM("unknown", "random", 5, "random", new Battery("unknown"), new Display());
        }

        [TestMethod]
        public void Owner()
        {
            Assert.AreEqual("unknown", testGSM.Model);
        }

        [TestMethod]
        public void BatteryModel()
        {
            Assert.AreEqual("unknown", testGSM.Battery.BatteryModel);
        }
    }
}
