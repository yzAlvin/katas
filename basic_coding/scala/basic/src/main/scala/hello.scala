package com.test

import scala.annotation.switch
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
}
