using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorNameSpace;

namespace AddFunctionTestProject
{
    [TestClass]
    public class AddFunctionTests
    {
        [TestMethod]
        public void StringIsEmptyTest()
        {
            int result = StringCalculator.Add(string.Empty);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void SingleNumberSimpleTest()
        {
            int result = StringCalculator.Add("5");
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void TwoNumbersSimpleTest()
        {
            int result = StringCalculator.Add("5,6");
            Assert.AreEqual(11, result);
        }
    }
}
