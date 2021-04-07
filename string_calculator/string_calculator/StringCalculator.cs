using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace string_calculator
{
    public class StringCalculator
    {
        public int Add(string s)
        {

            s = Delimiters.parseDelimiters(s);

            var listOfStrings = s.Split(Delimiters.delimiters.ToArray(), StringSplitOptions.None);
            
            var listOfInts = parseIntsInList(listOfStrings);

            listOfInts = ignoreIntsGreaterThan1000(listOfInts);
            
            checkListForNegatives(listOfInts);

            return listOfInts.Sum();
        }

        private static List<int> ignoreIntsGreaterThan1000(List<int> listOfInts)
        {
            return listOfInts.Where(n => n < 1000).ToList();
        }

        private static void checkListForNegatives(List<int> listOfInts)
        {
            if (listOfInts.Any(c => c < 0))
            {
                throw new NegativesNotAllowedException(listOfInts.Where(n => n < 0).ToList());
            }
        }

        private static List<int> parseIntsInList(string[] listOfStrings)
        {
            var listOfInts = new List<int>();
            if (listOfStrings.All(n => Int32.TryParse(n, out var _)))
            {
                listOfInts = listOfStrings.Select(n => Int32.Parse(n)).ToList();
            }

            return listOfInts;
        }
    }
}
