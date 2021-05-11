/*
Write a guessing game where the user has to guess a secret number.

After every guess the program tells the user whether
their number was too large or too small.

At the end the number of tries needed should be printed.

It counts only as one try if they input the
same number multiple times consecutively.

 */
package com.test

import org.scalatest.FunSuite
import java.io.{ByteArrayOutputStream, StringReader}

class GuessingGameTests extends FunSuite {
  test("prompt asks for a number") {
    assert(GuessingGame.promptForNumber() == "Enter your guess: ")
  }

  test("get number from user") {
    val num = new StringReader("3")
    Console.withIn(num) {
      assert(GuessingGame.getGuess() == 3)
    }
  }

  test("checkGuess returns corresponding") {
    val secret = 5
    assert(GuessingGame.checkGuess(secret, 4) == "Too Small")
    assert(GuessingGame.checkGuess(secret, 6) == "Too Large")
    assert(GuessingGame.checkGuess(secret, 5) == "Congrats")
  }

  test("getSecret gets random number between 1 and 10") {
    assert(GuessingGame.getSecret(0) == 0)
  }
}
