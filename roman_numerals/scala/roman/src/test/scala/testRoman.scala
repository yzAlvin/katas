package com.test

import org.scalatest.FunSpec

class RomanNumeralsTest extends FunSpec {

  describe("Convert Single Digits") {
    def generateTest(testCase: TestCase): Unit = {
      it("should convert " + testCase.getInput) {
        assert(
          RomanNumerals.toRoman(testCase.getInput) == testCase.getExpectedOutput
        )
      }
    }

    var testCases = List(
      new TestCase(0, ""),
      new TestCase(1, "I"),
      new TestCase(2, "II"),
      new TestCase(3, "III"),
      new TestCase(4, "IV"),
      new TestCase(5, "V"),
      new TestCase(6, "VI"),
      new TestCase(7, "VII"),
      new TestCase(8, "VIII"),
      new TestCase(9, "IX"),
      new TestCase(10, "X"),
      new TestCase(30, "XXX"),
      new TestCase(40, "XL"),
      new TestCase(50, "L"),
      new TestCase(80, "LXXX"),
      new TestCase(90, "XC"),
      new TestCase(100, "C"),
      new TestCase(800, "DCCC"),
      new TestCase(1444, "MCDXLIV"),
      new TestCase(2999, "MMCMXCIX"),
      new TestCase(3000, "MMM"),
      new TestCase(3999, "MMMCMXCIX")
    )

    testCases.foreach(generateTest)
  }
}

class TestCase(input: Int, expectedOutput: String) {
  def getInput: Int = input

  def getExpectedOutput: String = expectedOutput
}
