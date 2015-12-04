using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace BinaryTrees
{
    using System.Numerics;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class test
    {
        // TREES()

        [TestMethod]
        public void Trees()
        {
            Program.memo = new BigInteger[4];
            var res = Program.Trees(2);

            Assert.AreEqual(2, res);
        }

        [TestMethod]
        public void Trees2()
        {
            Program.memo = new BigInteger[4];
            var res = Program.Trees(3);

            Assert.AreEqual(5, res);
        }

        [TestMethod]
        public void Trees3()
        {
            Program.memo = new BigInteger[5];
            var res = Program.Trees(4);

            Assert.AreEqual(15, res);
        }
    }
}
