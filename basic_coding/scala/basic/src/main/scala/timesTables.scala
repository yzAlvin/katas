package com.test

object timesTables {
  val table = multiplicationTable(1 to 12)
//   println(tableString(table))

  def multiplicationTable(range: Range): Seq[Seq[Int]] =
    range map { i => range map { j => i * j } }

  def tableString(table: Seq[Seq[Int]]): String =
    table.map(rowString).mkString("\n")

  def rowString(row: Seq[Int]): String =
    row.map(cellString).mkString.trim

  def cellString(cell: Int): String =
    f"${cell.toString}%4s"
  // "%4s".format(cell.toString)
}
