package roman_numerals

import "strings"

var increments = map[int]string{
	100: "C",
	10:  "X",
	1:   "I",
}

var upperSymbols = map[int]string{
	100: "M",
	10:  "C",
	1:   "X",
}

var halfwaySymbols = map[int]string{
	100: "D",
	10:  "L",
	1:   "V",
}

func IntToRomanNumeral(number int) string {
	romanNumeral := ""
	placeValues := [3]int{100, 10, 1}

	for i := 0; i < len(placeValues); i++ {
		increment := increments[placeValues[i]]
		upperSymbol := upperSymbols[placeValues[i]]
		halfwaySymbol := halfwaySymbols[placeValues[i]]

		currentPlaceValue := number / placeValues[i]

		switch currentPlaceValue {
		case 9:
			romanNumeral += increment + upperSymbol
		case 8, 7, 6, 5:
			romanNumeral += halfwaySymbol + strings.Repeat(increment, currentPlaceValue-5)
		case 4:
			romanNumeral += increment + halfwaySymbol
		case 3, 2, 1:
			romanNumeral += strings.Repeat(increment, currentPlaceValue)
		}

		number = number % placeValues[i]
	}
	return romanNumeral
}
