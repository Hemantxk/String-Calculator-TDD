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
            Assert.AreEqual(5, result, "Failed to Calculate Add for \"5\"");

            int result2 = StringCalculator.Add("0");
            Assert.AreEqual(0, result2, "Failed to Calculate Add for \"0\"");

            int result3 = StringCalculator.Add("00");
            Assert.AreEqual(0, result3, "Failed to Calculate Add for \"00\"");
        }

        [TestMethod]
        public void TwoNumbersSimpleTest()
        {
            int result = StringCalculator.Add("5,6");
            Assert.AreEqual(11, result, "Failed to Add two numbers, simple case : \"5,6\"");

            int result2 = StringCalculator.Add("0,1");
            Assert.AreEqual(1, result2, "Failed to Add two numbers, simple case : \"0,1\"");

            int result3 = StringCalculator.Add("0,0");
            Assert.AreEqual(0, result3, "Failed to Add two numbers, simple case : \"0,0\"");

            int result4 = StringCalculator.Add("000,00");
            Assert.AreEqual(0, result4, "Failed to Add two numbers, simple case : \"000,00\"");
        }

        [TestMethod]
        public void AllowToAddMultipleNumbersTest()
        {
            string input = "1,2,3,4,5,6,6,7";
            int result = StringCalculator.Add(input);
            Assert.AreEqual(34, result, "Failed to add unknown amount of numbers, simple case: " + input);

            string input2 = "234,324,23,234,234,436,234,234,438,328,382,979,834";
            int result2 = StringCalculator.Add(input2);
            Assert.AreEqual(4914, result2, "Failed to add unknown amount of numbers, simple case: " + input2);

            string input3 = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            int result3 = StringCalculator.Add(input3);
            Assert.AreEqual(0, result3, "Failed to add unknown amount of numbers, simple case: " + input3);

            string input4 = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            int result4 = StringCalculator.Add(input4);
            Assert.AreEqual(1, result4, "Failed to add unknown amount of numbers, simple case: " + input4);

            string input5 = "000,00,0000,00001,00000";
            int result5 = StringCalculator.Add(input5);
            Assert.AreEqual(1, result4, "Failed to add unknown amount of numbers, simple case: " + input5);
        }

        [TestMethod]
        public void NewLineCharacterSimpleTest()
        {
            string input = "1,2\n3,4,5\n6,6\n7";
            int result = StringCalculator.Add(input);
            Assert.AreEqual(34, result, "Failed to add numbers where new line character is used, simple case: " + input);

            string input2 = "234,324\n23,234,234,436,234,234,438\n328,382,979,834";
            int result2 = StringCalculator.Add(input2);
            Assert.AreEqual(4914, result2, "Failed to add numbers where new line character is used, simple case: " + input2);

            string input3 = "0,0,0,0,0,0,0,0,0,0,0\n0,0,0,0,0,0,0,0,0,0,0,0,0,0\n0,0,0,0,0,0,0,0,0,0\n0,0,0,0,0,0,0";
            int result3 = StringCalculator.Add(input3);
            Assert.AreEqual(0, result3, "Failed to add numbers where new line character is used, simple case: " + input3);

            string input4 = "0\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0\n1\n0\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0\n0";
            int result4 = StringCalculator.Add(input4);
            Assert.AreEqual(1, result4, "Failed to add numbers where new line character is used, simple case: " + input4);

            string input5 = "5\n5\n5\n50\n100\n500";
            int result5 = StringCalculator.Add(input5);
            Assert.AreEqual(665, result5, "Failed to add numbers where new line character is used, simple case: " + input5);

            string input6 = "0\n0";
            int result6 = StringCalculator.Add(input6);
            Assert.AreEqual(0, result6, "Failed to add numbers where new line character is used, simple case: " + input6);

            string input7 = "1\n0";
            int result7 = StringCalculator.Add(input7);
            Assert.AreEqual(1, result7, "Failed to add numbers where new line character is used, simple case: " + input7);
        }

        [TestMethod]
        public void ChangeDelimiterSimpleTest()
        {
            string input = "//;\n1;2;3;4;5;6;6;7";
            int result = StringCalculator.Add(input);
            Assert.AreEqual(34, result, "Failed to add numbers where delimiter is used, simple case: " + input);

            string input2 = "//.\n234.324.23.234.234.436.234.234.438.328.382.979.834";
            int result2 = StringCalculator.Add(input2);
            Assert.AreEqual(4914, result2, "Failed to add numbers where delimiter is used, simple case: " + input2);

            string input3 = "//;\n0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0";
            int result3 = StringCalculator.Add(input3);
            Assert.AreEqual(0, result3, "Failed to add numbers where delimiter is used, simple case: " + input3);

            string input4 = "//;\n0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;1;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0";
            int result4 = StringCalculator.Add(input4);
            Assert.AreEqual(1, result4, "Failed to add numbers where delimiter is used, simple case: " + input4);

            string input5 = "//)\n5)5)5)50)100)500";
            int result5 = StringCalculator.Add(input5);
            Assert.AreEqual(665, result5, "Failed to add numbers where delimiter is used, simple case: " + input5);
        }

        [TestMethod]
        public void ChangeDelimiterNewLineTest()
        {
            string input = "//;\n1;2;3;4;5\n6;6\n7";
            int result = StringCalculator.Add(input);
            Assert.AreEqual(34, result, "Failed to add numbers where combination of delimiter & new line character is used, case : " + input);

            string input2 = "//.\n234\n324.23\n234.234.436.234.234.438\n328.382.979\n834";
            int result2 = StringCalculator.Add(input2);
            Assert.AreEqual(4914, result2, "Failed to add numbers where combination of delimiter & new line character is used, case : " + input2);

            string input3 = "//;\n0;0;0;0;0;0;0;0;0\n0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0\n0;0;0;0;0;0\n0;0;0";
            int result3 = StringCalculator.Add(input3);
            Assert.AreEqual(0, result3, "Failed to add numbers where combination of delimiter & new line character is used, case : " + input3);

            string input4 = "//;\n0;0;0;0;0;0;0;0\n0;0;0;0;0;0;0;0;0;0\n1;0;0;0;0;0;0;0;0;0;0\n0;0;0;0;0;0;0;0;0;0;0;0;0";
            int result4 = StringCalculator.Add(input4);
            Assert.AreEqual(1, result4, "Failed to add numbers where combination of delimiter & new line character is used, case : " + input4);

            string input5 = "//)\n5\n5\n5\n50\n100\n500";
            int result5 = StringCalculator.Add(input5);
            Assert.AreEqual(665, result5, "Failed to add numbers where combination of delimiter & new line character is used, case : " + input5);

            string input6 = "//;\n1\n0";
            int result6 = StringCalculator.Add(input6);
            Assert.AreEqual(1, result6, "Failed to add numbers where combination of delimiter & new line character is used, case : " + input6);

            string input7 = "//;\n";
            int result7 = StringCalculator.Add(input7);
            Assert.AreEqual(0, result7, "Failed to add numbers where combination of delimiter & new line character is used, case : " + input7);
        }

        [TestMethod]
        public void NegativeNumbersInStringTest()
        {
            string input = "//;\n1;2;3;-4;5\n6;6\n7";
            var exception = Assert.ThrowsException<Exception>(() => { StringCalculator.Add(input); });
            Assert.AreEqual("negatives not allowed: -4", exception.Message, "Exception message not matched, case: " + input);

            string input2 = "//.\n-234\n324.-23\n234.234.436.234.234.438\n-328.382.-979\n-834";
            var exception2 = Assert.ThrowsException<Exception>(() => { StringCalculator.Add(input2); });
            Assert.AreEqual("negatives not allowed: -234,-23,-328,-979,-834", exception2.Message, "Exception message not matched, case: " + input2);

            string input3 = "//;\n0;0;0;0;0;0;0;0\n0;0;0;0;0;0;0;0;0;0\n-1;0;0;0;0;0;0;0;0;0;0\n0;0;0;0;0;0;0;0;0;0;0;0;0";
            var exception3 = Assert.ThrowsException<Exception>(() => { StringCalculator.Add(input3); });
            Assert.AreEqual("negatives not allowed: -1", exception3.Message, "Exception message not matched, case: " + input3);

            string input4 = "//)\n-5\n-5\n-5\n-50\n-100\n-500";
            var exception4 = Assert.ThrowsException<Exception>(() => { StringCalculator.Add(input4); });
            Assert.AreEqual("negatives not allowed: -5,-5,-5,-50,-100,-500", exception4.Message, "Exception message not matched, case: " + input4);

            string input5 = "//;\n-1\n0";
            var exception5 = Assert.ThrowsException<Exception>(() => { StringCalculator.Add(input5); });
            Assert.AreEqual("negatives not allowed: -1", exception5.Message, "Exception message not matched, case: " + input5);

            string input6 = "//;\n-1\n-5";
            var exception6 = Assert.ThrowsException<Exception>(() => { StringCalculator.Add(input6); });
            Assert.AreEqual("negatives not allowed: -1,-5", exception6.Message, "Exception message not matched, case: " + input6);

            string input7 = "-8,-9";
            var exception7 = Assert.ThrowsException<Exception>(() => { StringCalculator.Add(input7); });
            Assert.AreEqual("negatives not allowed: -8,-9", exception7.Message, "Exception message not matched, case: " + input7);

            string input8 = "-847";
            var exception8 = Assert.ThrowsException<Exception>(() => { StringCalculator.Add(input8); });
            Assert.AreEqual("negatives not allowed: -847", exception8.Message, "Exception message not matched, case: " + input8);

            string input9 = "//;\n-1;2;3;-4;5\n6;6\n7";
            var exception9 = Assert.ThrowsException<Exception>(() => { StringCalculator.Add(input9); });
            Assert.AreEqual("negatives not allowed: -1,-4", exception9.Message, "Exception message not matched, case: " + input9);

            string input10 = "1,2,3\n4,5,6,6,-7";
            var exception10 = Assert.ThrowsException<Exception>(() => { StringCalculator.Add(input10); });
            Assert.AreEqual("negatives not allowed: -7", exception10.Message, "Exception message not matched, case: " + input10);
        }
    }
}
