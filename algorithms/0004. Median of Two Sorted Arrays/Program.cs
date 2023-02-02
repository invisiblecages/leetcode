/*
Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.

The overall run time complexity should be O(log (m+n)).

Example 1:
Input: nums1 = [1,3], nums2 = [2]
Output: 2.00000
Explanation: merged array = [1,2,3] and median is 2.

Example 2:
Input: nums1 = [1,2], nums2 = [3,4]
Output: 2.50000
Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.

Constraints:
    nums1.length == m
    nums2.length == n
    0 <= m <= 1000
    0 <= n <= 1000
    1 <= m + n <= 2000
    -106 <= nums1[i], nums2[i] <= 106
*/
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution
{
  public double FindMedianSortedArrays(int[] nums1, int[] nums2) 
  { 
    int[] res = new int[nums1.Length + nums2.Length];
    int idx = 0;
    int n1 = 0;
    int n2 = 0;

    while (n1 < nums1.Length && n2 < nums2.Length)
      if (nums1[n1] < nums2[n2])
        res[idx++] = nums1[n1++];
      else
        res[idx++] = nums2[n2++];
    
    while (n1 < nums1.Length)
      res[idx++] = nums1[n1++];
    
    while (n2 < nums2.Length)
      res[idx++] = nums2[n2++];

    if (res.Length % 2 != 0)
      return (double)res[res.Length / 2];
    else
      return (double)(res[(res.Length / 2) - 1]  + res[res.Length / 2]) / 2;
  }
}
// Follow up
// Time complexity: O(log n + m)
// Space complexity: O(?)