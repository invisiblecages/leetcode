/*
You are given a sorted integer array arr containing 1 and prime numbers, where all the integers of arr are unique. You are also given an integer k.

For every i and j where 0 <= i < j < arr.length, we consider the fraction arr[i] / arr[j].

Return the kth smallest fraction considered. Return your answer as an array of integers of size 2, where answer[0] == arr[i] and answer[1] == arr[j].

Example 1:

Input: arr = [1,2,3,5], k = 3
Output: [2,5]
Explanation: The fractions to be considered in sorted order are:
1/5, 1/3, 2/5, 1/2, 3/5, and 2/3.
The third fraction is 2/5.

Example 2:

Input: arr = [1,7], k = 1
Output: [1,7]

Constraints:

    2 <= arr.length <= 1000
    1 <= arr[i] <= 3 * 10^4
    arr[0] == 1
    arr[i] is a prime number for i > 0.
    All the numbers of arr are unique and sorted in strictly increasing order.
    1 <= k <= arr.length * (arr.length - 1) / 2

Follow up: Can you solve the problem with better than O(n^2) complexity?
*/
// Time complexity: O(n^2 * log n)
// Space complexity: O(n^2)
public class Solution 
{
  public int[] KthSmallestPrimeFraction(int[] arr, int k) 
  {
    PriorityQueue<(int, int), double> pq = new();
    int[] answer = new int[2];

    for (int i = 0; i < arr.Length; i++)
    {
      for (int j = i + 1; j < arr.Length; j++)
      {
        double res = (double)arr[i] / arr[j];

        pq.Enqueue((arr[i], arr[j]), res);
      }
    }

    while (pq.Count > 0 && k-- > 0)
    {  
      (answer[0], answer[1]) = pq.Dequeue();
    }

    return answer;
  }
}
// Follow up
// Time complexity: O(?)
// Space complexity: O(?)
