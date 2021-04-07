package roman_numerals

import "testing"

func checkRomanNumeral(t testing.TB, got, want string) {
	t.Helper()
	if got != want {
		t.Errorf("got %v want %v", got, want)
	}
}

func TestRomanNumeralBaseSymbols(t *testing.T) {
	t.Run("1 returns I", func(t *testing.T) {
		got := IntToRomanNumeral(1)
		want := "I"

		checkRomanNumeral(t, got, want)
	})

	t.Run("5 returns V", func(t *testing.T) {
		got := IntToRomanNumeral(5)
		want := "V"

		checkRomanNumeral(t, got, want)
	})

	t.Run("10 returns X", func(t *testing.T) {
		got := IntToRomanNumeral(10)
		want := "X"

		checkRomanNumeral(t, got, want)
	})

	t.Run("50 returns L", func(t *testing.T) {
		got := IntToRomanNumeral(50)
		want := "L"

		checkRomanNumeral(t, got, want)
	})

	t.Run("C returns 100", func(t *testing.T) {
		got := IntToRomanNumeral(100)
		want := "C"

		checkRomanNumeral(t, got, want)
	})

	t.Run("500 returns D", func(t *testing.T) {
		got := IntToRomanNumeral(500)
		want := "D"

		checkRomanNumeral(t, got, want)
	})
}

func TestRomanNumeralNine(t *testing.T) {
	t.Run("9 returns IX", func(t *testing.T) {
		got := IntToRomanNumeral(9)
		want := "IX"

		checkRomanNumeral(t, got, want)
	})

	t.Run("90 returns XC", func(t *testing.T) {
		got := IntToRomanNumeral(90)
		want := "XC"

		checkRomanNumeral(t, got, want)
	})
	t.Run("900 returns CM", func(t *testing.T) {
		got := IntToRomanNumeral(900)
		want := "CM"

		checkRomanNumeral(t, got, want)
	})
}

func TestRomanNumeralCombinations(t *testing.T) {
	t.Run("34 returns XXXIV", func(t *testing.T) {
		got := IntToRomanNumeral(34)
		want := "XXXIV"

		checkRomanNumeral(t, got, want)
	})

	t.Run("86 returns LXXXVI", func(t *testing.T) {
		got := IntToRomanNumeral(86)
		want := "LXXXVI"

		checkRomanNumeral(t, got, want)
	})

	t.Run("999 returns CMXCIX", func(t *testing.T) {
		got := IntToRomanNumeral(999)
		want := "CMXCIX"

		checkRomanNumeral(t, got, want)
	})
}
