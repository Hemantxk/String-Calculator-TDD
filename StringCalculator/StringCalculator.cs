﻿using System;
using System.Linq;

namespace StringCalculatorNameSpace
{
    public class StringCalculator
    {
        public const string DefaultDelimiter = ",";
        public const int DelimiterPrefixLength = 2;
        public const int MaxAllowedNumber = 999;

        public static int Add(string input)
        {
            if (input == string.Empty)
                return 0;
            int splitIndex;
            string strDelimiter = StringCalculator.ExtractDelimiter(input, out splitIndex);
            input = input.Substring(splitIndex + 1);
            if (input == string.Empty)
                return 0;
            var delimiters = new string[] { strDelimiter, "\n" };
            var numStrings = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            int temp;
            if(numStrings.All(numStr => int.TryParse(numStr, out temp)))
            {
                var numbers = numStrings.Select(a => int.Parse(a)).ToList();
                if (numbers.Any(num => num < 0))
                {
                    var negativeNums = numbers.Where(a => a < 0).ToList();
                    throw new Exception("negatives not allowed: " + string.Join(",", negativeNums));
                }
                else
                {
                    int addition = numbers.Select(num => num > MaxAllowedNumber ? 0 : num).Sum();
                    return addition;
                }
            }

            throw new NotSupportedException("Input format not supported.");
        }

        public static string ExtractDelimiter(string input, out int indx)
        {
            if (input.StartsWith("//"))
            {
                indx = input.IndexOf('\n');
                if (indx == -1)
                    new NotImplementedException();
                return input.Substring(DelimiterPrefixLength, indx - DelimiterPrefixLength);
            }
            else
            {
                indx = -1;
                return DefaultDelimiter;
            }
        }
    }
}
