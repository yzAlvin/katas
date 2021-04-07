using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace string_calculator
{
    public class Delimiters{

        public const string isSingleCharDelimiter = "(?<=//).(?=\n)";
        public const string isLongerLengthDelimiter = "(?<=//\\[).*(?=\\]\n)";
        public const string isMultipleDelimiter = "(?<=//)[.*]+(?=\n)";


        public static List<String> delimiters = new List<String> { ",", "\n" };
        public static string[] customDelimiters = new string[] { isSingleCharDelimiter, isLongerLengthDelimiter };


        public static string parseDelimiters(string s)
        {
            foreach (var delimiter in customDelimiters)
            {
                if (Regex.IsMatch(s, delimiter))
                {
                    var matchedDelimiters = Regex.Match(s, $"{delimiter}").Groups;
                    foreach (var delim in matchedDelimiters)
                    {
                        // Console.WriteLine(item);
                        delimiters.Add(delim.ToString());
                    }
                    s = Regex.Match(s, $"(?<=//.*\n).*").Value;
                    // Console.WriteLine(s);
                }
            }

            return s;
        }

    }
}