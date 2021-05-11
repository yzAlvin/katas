package com.test

import org.scalatest.FunSuite
import java.io.{ByteArrayOutputStream, StringReader}

class HelloTests extends FunSuite {
  test("helloWorld returns 'Hello, World!'") {
    assert(Hello.helloWorld() == "Hello, World!")
  }

  test("greetName returns 'Hello, $name'") {
    val name = "alvin"
    assert(Hello.greetName(name) == "Hello, alvin")
  }

  test("getName returns name") {
    val in = new StringReader("abc")

    Console.withIn(in) {
      assert(Hello.getName() === "abc")
    }
  }

  test("greetName2 greets Alice") {
    assert(Hello.greetName2("alice") == "Hello, Alice")
    assert(Hello.greetName2("ALICE") == "Hello, Alice")
  }

  test("greetName2 greets Bob") {
    assert(Hello.greetName2("bob") == "Hello, Bob")
    assert(Hello.greetName2("BOB") == "Hello, Bob")
  }

  test("greetName2 doesn't greet if not alice or bob") {
    assert(Hello.greetName2("alvin") == "go away")
    assert(Hello.greetName2("banana") == "go away")
    assert(Hello.greetName2("carrot") == "go away")
  }

// todo: learn how to throw exceptions?
//   test("sumToN throws IllegalArgumentException when n is less than 1") {
//     assertThrows[IllegalArgumentException] {
//       Hello.sumToN(0)
//     }

  test("sumToN returns sum of numbers from 1 to n") {
    assert(Hello.sumToN(1) == 1)
    assert(Hello.sumToN(3) == 6)
    assert(Hello.sumToN(10) == 55)
  }

  test("getNum gets number from user") {
    val num = new StringReader("1")
    Console.withIn(num) {
      assert(Hello.getNum() == 1)
    }
  }

  test("isMultiple3or5 returns true on multiples of 3 or 5") {
    assert(Hello.isMultiple3or5(3))
    assert(Hello.isMultiple3or5(5))
    assert(Hello.isMultiple3or5(15))
  }

  test("sumToNIfMultiple3or5 returns correct sum") {
    assert(Hello.sumToNIfMultiple3or5(1) == 0)
    assert(Hello.sumToNIfMultiple3or5(3) == 3)
    assert(Hello.sumToNIfMultiple3or5(5) == 8)
    assert(Hello.sumToNIfMultiple3or5(15) == 60)
  }

  test("productToN returns product of numbers from 1 to n") {
    assert(Hello.productToN(1) == 1)
    assert(Hello.productToN(3) == 6)
    assert(Hello.productToN(5) == 120)
  }

  test("chooseSumOrProduct returns either") {
    assert(Hello.chooseSumOrProduct("sum") == "sum")
    assert(Hello.chooseSumOrProduct("PRODUCT") == "product")
    assert(Hello.chooseSumOrProduct("S") == "")
  }

  test("bigDaddyProgram returns sum of 1 to n if sum picked") {
    assert(Hello.bigDaddyProgram(1, "SUM") == 1)
    assert(Hello.bigDaddyProgram(10, "sum") == 55)
    assert(Hello.bigDaddyProgram(3, "SuM") == 6)
  }

  test("bigDaddyProgram returns product of 1 to n if product picked") {
    assert(Hello.bigDaddyProgram(1, "PRODUCT") == 1)
    assert(Hello.bigDaddyProgram(5, "PRoduCT") == 120)
    assert(Hello.bigDaddyProgram(3, "product") == 6)
  }

  test("bigDaddyProgram returns n if invalid choice") {
    assert(Hello.bigDaddyProgram(1, "boo") == 1)
    assert(Hello.bigDaddyProgram(999, "foo") == 999)
  }

  test("isLeapYear returns true on leap years") {
    assert(Hello.isLeapYear(1992))
    assert(Hello.isLeapYear(2000))
    assert(Hello.isLeapYear(1988))
  }
  test("isLeapYear returns false on not leap years") {
    assert(Hello.isLeapYear(1700) == false)
  }

  test("nextNLeapYears returns next N leap years") {
    assert(Hello.nextNLeapYears(2000, 3) == (2000 to 2012 by 4))
    assert(Hello.nextNLeapYears(1499, 3) == Vector(1504, 1508, 1512))
  }

}
