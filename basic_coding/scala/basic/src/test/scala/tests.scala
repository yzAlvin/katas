package org.scalatest.examples.flatspec

import org.scalatest.flatspec.AnyFlatSpec

class SetSpec extends AnyFlatSpec {

  behavior of "An empty Set"

  it should "have size 0" in {
    assert(Set.empty.size === 0)
  }

  it should "produce NoSuchElementException when head is invoked" in {
    assertThrows[NoSuchElementException] {
      Set.empty.head
    }
  }
}
