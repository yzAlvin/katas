package fizzbuzz

import "fmt"

// FizzBuzz returns string "Fizz" on multiples of 3, "Buzz" on multiples of 5, "FizzBuzz" on multiples of both, and the number if it is not a multiple of either.
func FizzBuzz(number int) string {
	if divisibleBy15(number) {
		return "FizzBuzz"
	} else if divisibleBy3(number) {
		return "Fizz"
	} else if divisibleBy5(number) {
		return "Buzz"
	}
	return fmt.Sprint(number)
}

func divisibleBy15(number int) bool {
	return divisibleBy5(number) && divisibleBy3(number)
}
func divisibleBy5(number int) bool {
	return number%5 == 0
}
func divisibleBy3(number int) bool {
	return number%3 == 0
}
