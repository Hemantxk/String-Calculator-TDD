using System;
using System.Linq;

namespace StringCalculatorNameSpace
{
    public class StringCalculator
    {
        public static int Add(string input)
        {
            if (input == "")
                return 0;
            var nums = input.Split(',');
            return nums.Sum(a => int.Parse(a));
        }
    }
}
