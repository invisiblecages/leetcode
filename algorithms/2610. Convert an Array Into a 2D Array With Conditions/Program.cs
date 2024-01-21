/*
You are given an integer array nums. You need to create a 2D array from nums satisfying the following conditions

    The 2D array should contain only the elements of the array nums.
    Each row in the 2D array contains distinct integers.
    The number of rows in the 2D array should be minimal.

Return the resulting array. If there are multiple answers, return any of them.

Note that the 2D array can have a different number of elements on each row.

Example 1

Input nums = [1,3,4,1,2,3,1]
Output [[1,3,4,2],[1,3],[1]]
Explanation We can create a 2D array that contains the following rows
- 1,3,4,2
- 1,3
- 1
All elements of nums were used, and each row of the 2D array contains distinct integers, so it is a valid answer.
It can be shown that we cannot have less than 3 rows in a valid array.

Example 2

Input nums = [1,2,3,4]
Output [[4,3,2,1]]
Explanation All elements of the array are distinct, so we can keep all of them in the first row of the 2D array.

Constraints

    1 = nums.length = 200
    1 = nums[i] = nums.length
*/
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution 
{
  public IList<IList<int>> FindMatrix(int[] nums) 
  {
    Dictionary<int, int> numbers = [];
    IList<IList<int>> nums2D = [];

    foreach (int num in nums)
    {
      if (numbers.ContainsKey(num))
        numbers[num]++;
      else
        numbers[num] = 1;

      int row = numbers[num];

      if (nums2D.Count < row)
      {
        nums2D.Add([]);
      }

      nums2D[row - 1].Add(num);
    }

    return nums2D;
  }
}
// First solution
// Time complexity: O(n^2)
// Space complexity: O(n)
public class Solution 
{
  public IList<IList<int>> FindMatrix(int[] nums) 
  {
    Dictionary<int, int> numbers = [];
    IList<IList<int>> nums2D = [];
    int n = nums.Length;

    foreach (int num in nums)
    {
      if (numbers.ContainsKey(num))
        numbers[num]++;
      else
        numbers[num] = 1;
    }

    while (n > 0)
    {
      List<int> row = [];

      foreach (var kvp in numbers)
      {
        var key = kvp.Key;

        if (kvp.Value > 0)
        {
          row.Add(key);
          numbers[key]--;
          n--;
        }
      }

      nums2D.Add(row);
    }

    return nums2D;
  }
}