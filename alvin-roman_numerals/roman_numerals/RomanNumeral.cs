using System;
using System.Linq;

namespace roman_numerals
{
    public static class RomanNumeral
    {
        public static string Parse(int integerToParse)
        {
            checkIntegerIsPositive(integerToParse);

            string romanNumeralRepresentation = "";

            romanNumeralRepresentation = 
                parseThousandsPlace(integerToParse / 1000)
                + parseHundredsAndUnderPlace(integerToParse % 1000);
                // parseHelper(integerToParse);

            return romanNumeralRepresentation;
        }

        private static string parseHelper(int integerToParse)
        {
            return parseHundredsAndUnderPlace(integerToParse / 1000) + parseHundredsAndUnderPlace(integerToParse % 1000);
        }

        private static void checkIntegerIsPositive(int integerToParse)
        {
            if (integerToParse <= 0) throw new InvalidOperationException("Cannot convert numbers less than 0.");
        }

        private static string parseThousandsPlace(int thousands)
        {
            return String.Concat(Enumerable.Repeat("M", thousands));
        }

        private static string parseHundredsAndUnderPlace(int number)
        {
            string symbolsToAdd = "";

            int[] placeValues = new int[] {100, 10, 1};
            foreach (int place in placeValues)
            {
                string increment = place == 100 ? "C" : place == 10 ? "X" : "I";
                string upperSymbol = place == 100 ? "M" : place == 10 ? "C" : "X";
                string halfwaySymbol = place == 100 ? "D" : place == 10 ? "L" : "V";
                string incrementToAdd = "";
                int currentPlaceValue = number/place;
                switch (currentPlaceValue)
                {
                    case 9:
                        symbolsToAdd += $"{increment}{upperSymbol}";
                        break;
                    case 8:
                    case 7:
                    case 6:
                    case 5:
                        incrementToAdd = String.Concat(Enumerable.Repeat(increment, currentPlaceValue - 5));
                        symbolsToAdd += $"{halfwaySymbol}{incrementToAdd}";
                        break;
                    case 4:
                        symbolsToAdd += $"{increment}{halfwaySymbol}";
                        break;
                    case 3:
                    case 2:
                    case 1:
                        incrementToAdd = String.Concat(Enumerable.Repeat(increment, currentPlaceValue));
                        symbolsToAdd += $"{incrementToAdd}";
                        break;
                    default:
                        break;
                }
                number = number % place;
            }

            return symbolsToAdd;
        }

    }
}
