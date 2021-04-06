# String Calculator Kata

## The Process
* Don't read ahead
* Do one step at a time
* Only need to test for valid inputs

## Goal for this Kata
* TDD
* Four Principles of Design
* YAGNI
* Command Query Separation
* Maybe? Test Doubling

## Test Checklist
(I started this on Step 5)

Step 5. New line breaks and commas should be interchangeable between numbers.
* It should already handle only commas from previous tests
* A test for only \n
* A test when \n occurs before commas
* A test when commas occurs before \n

Step 6. Support single character delimiter `//[delimiter]\n[numbers...]`
* A test for a single character symbol delimiter such as the pattern `//;\n[numbers...]`
* A test for a single character number delimiter such as the pattern `//0\n[numbers...]`
* A test for a single character letter delimiter such as the pattern `//a\n[numbers...]`

Step 7. Calling add with a negative number will throw an exception 
`Add("-1,2,-3") > Throws exception with Negatives not allowed: -1, -3  `
* A test for just 1 negative number
* A test for multiple negatives 

Step 8. Numbers >= 1000 should be ignored
* A test with 999 in the sequence (before boundary)
* A test with 1000 and 1001 in the sequence (start of boundary)
* A test where entire sequence is >= 1000

Step 9. Delimiters can be of any length in the format `//[delimiter]\n`
* A test where delimiter contains no number (only letters and symbols)
* A test where a number is part of the delimiter

Step 10. Allow multiple delimiters `//[delim1][delim2]\n`
* A test where there are multiple delimiters
* A test where there are multiple delimiters of differing lengths