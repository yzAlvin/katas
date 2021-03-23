# Roman Numerals
Create a conversion mechanism from integers to a Roman representation (a string)

[Wikipedia page on Roman Numerals](https://en.wikipedia.org/wiki/Roman_numerals)

<table>
  <tr>
    <th>Symbol</th>
    <td>I</td>
    <td>V</td>
    <td>X</td>
    <td>L</td>
    <td>C</td>
    <td>D</td>
    <td>M</td>
  </tr>
  <tr>
    <th>Value</th>
    <td>1</td>
    <td>5</td>
    <td>10</td>
    <td>50</td>
    <td>100</td>
    <td>500</td>
    <td>1000</td>
  </tr>
</table>

| Numbers       | Thousands     | Hundreds      | Tens          | Ones          |
| :------------ |--------------:|--------------:|--------------:|--------------:|
| 0             |               |               |               |               |
| 1             | M             | C             | X             | I             |
| 2             | MM            | CC            | XX            | II            |
| 3             | MMM           | CCC           | XXX           | III           |
| 4             |               | CD            | XL            | IV            |
| 5             |               | D             | L             | V             |
| 6             |               | DC            | LX            | VI            |
| 7             |               | DCC           | LXX           | VII           |
| 8             |               | DCCC          | LXXX          | VIII          |
| 9             |               | CM            | XC            | IX            |

## Approach
Using a **greedy** approach:
* Look at thousands and above place -> "M" until we reach the right value
* Look at hundreds place -> "CM" if you can, else "D" if you can, else "CD" if you can, else "C" while you can
* Look at tens place -> "XC" if you can, else "L" if you can, else "XL" if you can, else "X" while you can
* Look at ones place -> "IX" if you can, else "V" if you can, else "IV" if you can, else "I" while you can

Using a **dictionary** approach:
* Implement above table into a dictionary, with (key, value) pairs being (place value, corresponding symbol)
* Pass each digit in integer through dictionary
* Return the corresponding symbol of each place value concatenated

## Test Checklist
* 1, 5, 10, 50, 100, 500, 1000 all return the corresponding symbol I, V, X, L, C, D, M
* Any number >= 1000 returns "M" * number // 1000 as the first symbol
* (2, 3) * n where n = {1, 10, 100} returns
  * I if n = 1 * (2, 3)
  * X if n = 10 * (2, 3)
  * C if n = 100 * (2, 3)
* 4 * n where n = {1, 10, 100} returns 
  * IV if n = 1
  * XL if n = 10
  * CD if n = 100
* (5, 6, 7, 8) * n where n = {1, 10, 100} returns 
  * V if n = 1 + (I) * (0, 1, 2, 3)
  * L if n = 10 + (X) * (0, 1, 2, 3)
  * D if n = 100 + (C) * (0, 1, 2, 3)
* 9 * n where n = {1, 10, 100} returns
  * IX if n = 1
  * XC if n = 10
  * CM if n = 100
* If input <= 0, throws exception
* 34 return XXXIV
* 86 return LXXXVI
* 2021 return MMXXI
