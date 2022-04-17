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
            char delimiter = ',';
            if(input.StartsWith("//") && input.Length >= 4)
            {
                delimiter = input[2];
                input = input.Substring(4);
            }
            if (input == "")
                return 0;
            var numStrings = input.Split(delimiter, '\n');
            int temp;
            if(numStrings.All(a => int.TryParse(a, out temp)))
            {
                if(numStrings.Any(a => int.Parse(a) < 0))
                {
                    var negativeNums = numStrings.Select(a => int.Parse(a)).Where(a => a < 0).ToList();
                    throw new Exception("negatives not allowed: " + string.Join(",", negativeNums));
                }
                else
                {
                    int addition = numStrings.Select(a => int.Parse(a)).Sum();
                    return addition;
                }
            }

            throw new NotSupportedException("Input format not supported.");
        }
    }
}
