using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhone;

namespace UnitTestGSM
{
    [TestClass]
    public class TestBattery
    {
        private static Battery testBattery;

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegatveHoursTalk()
        {
            testBattery = new Battery("unknown model");
            testBattery = new Battery("TestGuy", -5.4, 4, BatteryType.LiIon);
        }

        [TestMethod]
        [TestInitialize]
        public void Creation()
        {
            testBattery = new Battery("unknown model");
            testBattery = new Battery("Generic model", 5.4, 4, BatteryType.LiIon);
        }

        [TestMethod]
        public void Model()
        {
            Assert.AreEqual("Generic model", testBattery.BatteryModel);
        }
    }
}
