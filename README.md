# MVC_Coding_Challenge
Programming challenge which is written in C# using MVC.

Please provide an application showing use of the MVC design pattern with supporting unit tests.  Also note that there may or may not be test cases outside of the sample input provided that should be handled if possible.

Input
The first line is the number K of input data sets, followed by the K data sets, each of the following form:

The first line of each data set contains the number 2 <= D <= 7 of denominations, and the number 2 <= N <= 10 of the item’s different prices. On the next line are D −1 positive integers, where the ith integer specifies the number of notes of denomination i + 1 that are equivalent to 1 note of denomination i.

This is followed by N lines, each one specifying a price in terms of the quantity of notes of each denomination. Each line contains D non-negative integers, where the ith integer specifies the number of notes of denomination i. It is guaranteed that each of the N prices, in terms of the smallest denomination, will fit in a 32-bit integer.

Output
For each data set, output “Data Set x:” on a line by itself, where x is its number. On the next line, output the difference between the highest price and the lowest price, in terms of the smallest denomination. Each data set should be followed by a blank line.

Sample Input / Output
Input	Output
2

2 2

2

2 0

0 5

3 3

3 5

1 1 1

3 0 0

1 10 0


Data Set 1:
1

Data Set 2:
44
