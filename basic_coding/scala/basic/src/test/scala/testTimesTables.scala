package com.test

import org.scalatest.FunSuite
import java.io.{ByteArrayOutputStream, StringReader}

class timesTablesTessts extends FunSuite {
  test("times tables is 12 rows long") {
    assert(timesTables.table.length == 12)
  }

  test("times tables contains 1 2 and 12 times tables") {
    assert(timesTables.table.contains(1 to 12))
    assert(timesTables.table.contains(2 to 24 by 2))
    assert(timesTables.table.contains(12 to 144 by 12))
  }

}
