/*
Given an array arr, replace every element in that array with the greatest element among the elements to its right, and replace the last element with -1.

After doing so, return the array.

Example 1:
Input: arr = [17,18,5,4,6,1]
Output: [18,6,6,6,1,-1]
Explanation: 
- index 0 --> the greatest element to the right of index 0 is index 1 (18).
- index 1 --> the greatest element to the right of index 1 is index 4 (6).
- index 2 --> the greatest element to the right of index 2 is index 4 (6).
- index 3 --> the greatest element to the right of index 3 is index 4 (6).
- index 4 --> the greatest element to the right of index 4 is index 5 (1).
- index 5 --> there are no elements to the right of index 5, so we put -1.

Example 2:
Input: arr = [400]
Output: [-1]
Explanation: There are no elements to the right of index 0.

Constraints:
    1 <= arr.length <= 104
    1 <= arr[i] <= 105
*/
// Time complexity: O(n)
// Space complexity: O(1)
public class Solution
{
  public int[] ReplaceElements(int[] arr)
  {
    int max = -1;
    for (int i = arr.Length - 1; i >= 0; i--)
    {
      int newMax = Math.Max(max, arr[i]);
      arr[i] = max;
      max = newMax;
    }

    return arr;
  }
}
// Time complexity: O(n^2)
// Space complexity: O(1)
public class Solution
{
  public int[] ReplaceElements(int[] arr)
  {
    for (int i = 0; i < arr.Length; i++)
    {
      if (i == arr.Length - 1)
      {
        arr[i] = -1;
        break;
      }

      int idx = i + 1;
      int maxValue = arr[idx];
      while (idx < arr.Length)
      {
        maxValue = Math.Max(arr[idx], maxValue);
        idx++;
      }

      arr[i] = maxValue;
    }

    return arr;
  }
}