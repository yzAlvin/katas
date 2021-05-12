package com.test

import scala.annotation.switch
import scala.util.Random.nextInt
object Hello {
  def helloWorld(): String =
    "Hello, World!"

  def getName(): String = {
    println("What is your name? ")
    val name = scala.io.StdIn.readLine()
    name
  }

  def greetName(name: String): String =
    s"Hello, $name"

  def greetName2(name: String): String =
    name.toLowerCase match {
      case "alice" => s"Hello, ${name.toLowerCase.capitalize}"
      case "bob"   => s"Hello, ${name.toLowerCase.capitalize}"
      case _       => "go away"
    }

  def sumToN(n: Int): Int =
    (1 to n).fold(0)((a, b) => a + b)

  def getNum(): Int = {
    scala.io.StdIn.readInt()
  }

  def isMultiple3or5(n: Int): Boolean =
    if (n % 3 == 0) true
    else if (n % 5 == 0) true
    else false

  def sumToNIfMultiple3or5(n: Int): Int =
    (1 to n).fold(0)((acc, cur) => if (isMultiple3or5(cur)) acc + cur else acc)

  def productToN(n: Int): Int =
    (1 to n).fold(1)((acc, cur) => acc * cur)

  def chooseSumOrProduct(choice: String): String =
    choice.toLowerCase match {
      case "sum"     => "sum"
      case "product" => "product"
      case _         => ""
    }

  def bigDaddyProgram(n: Int, choice: String): Int =
    chooseSumOrProduct(choice) match {
      case "sum"     => sumToN(n)
      case "product" => productToN(n)
      case _         => n
    }

  def isLeapYear(n: Int): Boolean =
    if ((n % 4 == 0 && n % 100 != 0) || n % 400 == 0) true
    else false

  def nextNLeapYears(year: Int, nextN: Int): Seq[Int] =
    (year to year + 3 + (nextN * 4)).filter(isLeapYear)

  def average(array: Array[Double]): Double = {
    if (array.length == 0) 0.0
    else array.fold(0.0)((a, b) => a + b) / array.length
  }

  // def tester(): Unit = {
  //   // val testSeqs: Set[(Seq[Int], Seq[Int], Boolean)] = (0 until 40)
  //   val ra = Table[Double](
  //     0.0
  //   )
  //   println(ra)
  //   val r = scala.util.Random
  //   (1 to 40).foreach { i =>
  //     val testSeqs: Seq[Double] = Seq.fill(r.nextInt(10))(r.nextInt(100))
  //     println(testSeqs)
  //     val ans: Double = testSeqs.fold(0.0)((a, b) => a + b) / testSeqs.length
  //     println(ans)
  //   }
  //   // .map { _ =>
  //   // Create a random sequence of integers and pair it with the correct
  // squared sequence.
  // val (seq1, seq2) = (0 until (Random.nextInt(7) + 1)).map { _ =>
  //   val elem = Random.nextInt(100)
  //   (elem, elem * elem)
  // }.unzip

  // Randomly decide whether to break the second sequence so that the two
  // sequences no longer match.
  //   val matchingSeq = Random.nextBoolean
  //   val editedSeq2 = Random.shuffle(if (!matchingSeq) {
  //     seq2.updated(seq2.length - 1, seq2.last + 1)
  //   } else {
  //     seq2
  //   })

  //   (seq1, editedSeq2, matchingSeq)

  //   // Convert to a set to ensure we don't have any two random tests that are the same.
  // }.toSet

  // testSeqs foreach { case (seq1, seq2, matchingSeq) =>
  //   it(s"should return ${matchingSeq} for (${seq1}, ${seq2})") {
  //     assert(
  //       Solution.comp(seq1, seq2) == matchingSeq,
  //       s"\ncomp(${seq1}, ${seq2}) should be ${matchingSeq}"
  //     )
  //   }
  // }
  // }
  // tester()

}
