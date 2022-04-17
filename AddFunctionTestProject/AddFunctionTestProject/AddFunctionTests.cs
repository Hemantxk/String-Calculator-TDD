using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorNameSpace;
using System;

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

            int result2 = StringCalculator.Add("0");
            Assert.AreEqual(0, result2);

            int result3 = StringCalculator.Add("00");
            Assert.AreEqual(0, result3);
        }

        [TestMethod]
        public void TwoNumbersSimpleTest()
        {
            int result = StringCalculator.Add("5,6");
            Assert.AreEqual(11, result);

            int result2 = StringCalculator.Add("0,1");
            Assert.AreEqual(1, result2);

            int result3 = StringCalculator.Add("0,0");
            Assert.AreEqual(0, result3);

            int result4 = StringCalculator.Add("000,00");
            Assert.AreEqual(0, result4);
        }

        [TestMethod]
        public void AllowToAddMultipleNumbersTest()
        {
            int result = StringCalculator.Add("1,2,3,4,5,6,6,7");
            Assert.AreEqual(34, result);

            int result2 = StringCalculator.Add("234,324,23,234,234,436,234,234,438,328,382,979,834");
            Assert.AreEqual(4914, result2);

            int result3 = StringCalculator.Add("0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0");
            Assert.AreEqual(0, result3);

            int result4 = StringCalculator.Add("0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0");
            Assert.AreEqual(1, result4);

            int result5 = StringCalculator.Add("000,00,0000,00001,00000");
            Assert.AreEqual(1, result4);
        }

        [TestMethod]
        public void NewLineCharacterSimpleTest()
        {
            int result = StringCalculator.Add("1,2\n3,4,5\n6,6\n7");
            Assert.AreEqual(34, result);

            int result2 = StringCalculator.Add("234,324\n23,234,234,436,234,234,438\n328,382,979,834");
            Assert.AreEqual(4914, result2);

            int result3 = StringCalculator.Add("0,0,0,0,0,0,0,0,0,0,0\n0,0,0,0,0,0,0,0,0,0,0,0,0,0\n0,0,0,0,0,0,0,0,0,0\n0,0,0,0,0,0,0");
            Assert.AreEqual(0, result3);

            int result4 = StringCalculator.Add("0\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0\n1\n0\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0\n0");
            Assert.AreEqual(1, result4);

            int result5 = StringCalculator.Add("5\n5\n5\n50\n100\n500");
            Assert.AreEqual(665, result5);

            int result6 = StringCalculator.Add("0\n0");
            Assert.AreEqual(665, result6);

            int result7 = StringCalculator.Add("1\n0");
            Assert.AreEqual(1, result7);
        }

        [TestMethod]
        public void ChangeDelimiterSimpleTest()
        {
            int result = StringCalculator.Add("//;\n1;2;3;4;5;6;6;7");
            Assert.AreEqual(34, result);

            int result2 = StringCalculator.Add("//.\n234.324.23.234.234.436.234.234.438.328.382.979.834");
            Assert.AreEqual(4914, result2);

            int result3 = StringCalculator.Add("//;\n0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0");
            Assert.AreEqual(0, result3);

            int result4 = StringCalculator.Add("//;\n0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;1;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0");
            Assert.AreEqual(1, result4);

            int result5 = StringCalculator.Add("//)\n5)5)5)50)100)500");
            Assert.AreEqual(665, result5);
        }

        [TestMethod]
        public void ChangeDelimiterNewLineTest()
        {
            int result = StringCalculator.Add("//;\n1;2;3;4;5\n6;6\n7");
            Assert.AreEqual(34, result);

            int result2 = StringCalculator.Add("//.\n234\n324.23\n234.234.436.234.234.438\n328.382.979\n834");
            Assert.AreEqual(4914, result2);

            int result3 = StringCalculator.Add("//;\n0;0;0;0;0;0;0;0;0\n0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0\n0;0;0;0;0;0\n0;0;0");
            Assert.AreEqual(0, result3);

            int result4 = StringCalculator.Add("//;\n0;0;0;0;0;0;0;0\n0;0;0;0;0;0;0;0;0;0\n1;0;0;0;0;0;0;0;0;0;0\n0;0;0;0;0;0;0;0;0;0;0;0;0");
            Assert.AreEqual(1, result4);

            int result5 = StringCalculator.Add("//)\n5\n5\n5\n50\n100\n500");
            Assert.AreEqual(665, result5);

            int result6 = StringCalculator.Add("//;\n1\n0");
            Assert.AreEqual(1, result6);
        }

        [TestMethod]
        public void NegativeNumbersInStringTest()
        {
            var exception = Assert.ThrowsException<Exception>(() => { StringCalculator.Add("//;\n1;2;3;-4;5\n6;6\n7"); });
            Assert.AreEqual("negatives not allowed: -4", exception.Message);

            var exception2 = Assert.ThrowsException<Exception>(() => { StringCalculator.Add("//.\n-234\n324.-23\n234.234.436.234.234.438\n-328.382.-979\n-834"); });
            Assert.AreEqual("negatives not allowed: -234,-23,-328,-979,-834", exception2.Message);

            var exception3 = Assert.ThrowsException<Exception>(() => { StringCalculator.Add("//;\n0;0;0;0;0;0;0;0\n0;0;0;0;0;0;0;0;0;0\n-1;0;0;0;0;0;0;0;0;0;0\n0;0;0;0;0;0;0;0;0;0;0;0;0"); });
            Assert.AreEqual("negatives not allowed: -1", exception3.Message);

            var exception4 = Assert.ThrowsException<Exception>(() => { StringCalculator.Add("//)\n-5\n-5\n-5\n-50\n-100\n-500"); });
            Assert.AreEqual("negatives not allowed: -5,-5,-5,-50,-100,-500", exception4.Message);

            var exception5 = Assert.ThrowsException<Exception>(() => { StringCalculator.Add("//;\n-1\n0"); });
            Assert.AreEqual("negatives not allowed: -1", exception5.Message);

            var exception6 = Assert.ThrowsException<Exception>(() => { StringCalculator.Add("//;\n-1\n-5"); });
            Assert.AreEqual("negatives not allowed: -1,-5", exception6.Message);

            var exception7 = Assert.ThrowsException<Exception>(() => { StringCalculator.Add("-8,-9"); });
            Assert.AreEqual("negatives not allowed: -8,-9", exception7.Message);

            var exception8 = Assert.ThrowsException<Exception>(() => { StringCalculator.Add("-847"); });
            Assert.AreEqual("negatives not allowed: -847", exception8.Message);

            var exception9 = Assert.ThrowsException<Exception>(() => { StringCalculator.Add("//;\n-1;2;3;-4;5\n6;6\n7"); });
            Assert.AreEqual("negatives not allowed: -1,-4", exception9.Message);

            var exception10 = Assert.ThrowsException<Exception>(() => { StringCalculator.Add("1,2,3\n4,5,6,6,-7"); });
            Assert.AreEqual("negatives not allowed: -7", exception10.Message);
        }
    }
}
