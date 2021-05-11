package com.test

object GuessingGame {
  def promptForNumber(): String =
    "Enter your guess: "

  def getGuess(): Int =
    scala.io.StdIn.readInt()

  def checkGuess(secret: Int, guess: Int): String =
    if (guess < secret) "Too Small"
    else if (guess > secret) "Too Large"
    else "Congrats"

  def getSecret(seed: Int): Int = {
    val r = scala.util.Random
    r.setSeed(
      seed
    ) // is this functional? isn't this setting the state of r or something
    r.nextInt(10)
  }

  /*
  This is not functional:
  guesses and guess have states which are constantly being changed
  ...
   */
  def playGame(): Unit = {
    println("Welcome to the guessing game!")
    println("Guess the number between 1 and 10 in the fewest tries.")
    val secret = getSecret(0)
    var guesses = 1
    var guess = getGuess()
    while (guess != secret) {
      println(checkGuess(secret, guess))
      guess = getGuess()
      guesses += 1
    }
    println(s"the secret was $secret")
    println(s"it took $guesses guesses")
  }
//   playGame()
}
