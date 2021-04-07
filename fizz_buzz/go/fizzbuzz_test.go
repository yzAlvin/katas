package fizzbuzz

import (
	"fmt"
	"testing"
)

func checkFizzBuzz(t testing.TB, got, want string) {
	t.Helper()
	if got != want {
		t.Errorf("got %v want %v", got, want)
	}
}

func TestFizzBuzz(t *testing.T) {
	t.Run("Fizz on multiples of 3", func(t *testing.T) {
		got := FizzBuzz(3)
		want := "Fizz"

		checkFizzBuzz(t, got, want)
	})

	t.Run("Buzz on multiples of 5", func(t *testing.T) {
		got := FizzBuzz(5)
		want := "Buzz"

		checkFizzBuzz(t, got, want)
	})

	t.Run("FizzBuzz on multiples of 15", func(t *testing.T) {
		got := FizzBuzz(15)
		want := "FizzBuzz"

		checkFizzBuzz(t, got, want)
	})

	t.Run("number if not multiple", func(t *testing.T) {
		got := FizzBuzz(2)
		want := "2"

		checkFizzBuzz(t, got, want)
	})
}

func ExampleFizzBuzz() {
	fmt.Println(FizzBuzz(15))
	// Output: FizzBuzz
}

func BenchmarkFizzBuzz(b *testing.B) {
	for i := 1; i < b.N; i++ {
		FizzBuzz((i))
	}
}
