package com.test

object RomanNumerals {
  //http://gibbons.org.uk/scala-roman-numerals-different-approaches

  def toRoman(n: Int): String =
    "M" * (n / 1000) +
      ("", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM")
        .productElement(n % 1000 / 100) +
      ("", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC")
        .productElement(n % 100 / 10) +
      ("", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX")
        .productElement(n % 10)
  //productElement returns the name of specified index

}
