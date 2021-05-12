using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace string_calculator
{
    public static class Calculator
    {
        private static string customDelimiter = @"//.*\n";
        private static List<String> delimiters = new List<String> { ",", "\n" };
        private static string[] trimCustomDelimiters = new string[] { "//", "\n", "[", "]" };
        public static int ConvertStringToNumber(string input)
        {
            if (int.TryParse(input, out var num)) return num;
            return 0;
        }

        public static int AddNumbers(string input)
        {
            var regex = new Regex(customDelimiter, RegexOptions.IgnoreCase);
            if (regex.Match(input).Success)
            {
                var whereDelimiterEnds = regex.Match(input).Length;
                var newDelimiter = regex.Match(input).Value.ReplaceStrings(trimCustomDelimiters).Split("").ToList();
                delimiters.Concat<String>(newDelimiter);
                input = input[whereDelimiterEnds..];
            }
            CheckForNegatives(input);
            return input.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(ConvertToNumber).Sum();
        }

        private static void CheckForNegatives(string input)
        {
            if (input.Any(c => c == '-')) throw new Exception();
        }

        private static int ConvertToNumber(string s)
        {
            var number = int.Parse(s);
            if (number >= 1000) return 0;
            return number;
        }

        private static string ReplaceStrings(this string input, string[] badStrings)
        {
            foreach (var str in badStrings)
            {
                input = input.Replace(str, "");
            }
            return input;
        }

    }
}