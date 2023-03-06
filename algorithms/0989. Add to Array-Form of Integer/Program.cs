/*
The array-form of an integer num is an array representing its digits in left to right order.

    For example, for num = 1321, the array form is [1,3,2,1].

Given num, the array-form of an integer, and an integer k, return the array-form of the integer num + k.

Example 1:
Input: num = [1,2,0,0], k = 34
Output: [1,2,3,4]
Explanation: 1200 + 34 = 1234

Example 2:
Input: num = [2,7,4], k = 181
Output: [4,5,5]
Explanation: 274 + 181 = 455

Example 3:
Input: num = [2,1,5], k = 806
Output: [1,0,2,1]
Explanation: 215 + 806 = 1021

Constraints:
    1 <= num.length <= 104
    0 <= num[i] <= 9
    num does not contain any leading zeros except for the zero itself.
    1 <= k <= 104
*/
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution
{
  public IList<int> AddToArrayForm(int[] num, int k)
  {
    List<int> res = new();
    int carry = 0;

    for (int i = num.Length - 1; i >= 0 || k > 0 || carry > 0; i--)
    {
      int digit1 = i >= 0 ? num[i] : 0;
      int digit2 = k % 10;
      k /= 10;
      int sum = digit1 + digit2 + carry;
      carry = sum / 10;
      res.Insert(0, sum % 10);
    }

    return res;   
  }
}
/* 
Iterate from the rightmost digit of the array num and the rightmost digit of k
Keep adding the corresponding digits along with any carry from the previous iteration
until all the digits of both numbers have been processed

Extract the current digit of num (if there are any left)

Extract the current digit of k (if there are any left)

Remove the last digit of k

Add the current digits along with the carry from the previous iteration

Compute the carry for the next iteration

Insert the ones digit of the sum at the beginning of the list res
*/