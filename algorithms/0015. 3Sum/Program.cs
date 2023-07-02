/*
Given an integer array nums, 
return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

Notice that the solution set must not contain duplicate triplets.

Example 1:

Input: nums = [-1,0,1,2,-1,-4]
Output: [[-1,-1,2],[-1,0,1]]
Explanation: 
nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
The distinct triplets are [-1,0,1] and [-1,-1,2].
Notice that the order of the output and the order of the triplets does not matter.

Example 2:

Input: nums = [0,1,1]
Output: []
Explanation: The only possible triplet does not sum up to 0.

Example 3:

Input: nums = [0,0,0]
Output: [[0,0,0]]
Explanation: The only possible triplet sums up to 0.

Constraints:

    3 <= nums.length <= 3000
    -105 <= nums[i] <= 105
*/
// Time complexity: O(n^2)
// Space complexity: O(n)
public class Solution 
{
  public IList<IList<int>> ThreeSum(int[] nums) 
  {
    List<IList<int>> result = new List<IList<int>>();
    Array.Sort(nums);

    for (int i = 0; i < nums.Length; i++)
    {
      if (i > 0 && nums[i - 1] == nums[i])
        continue;

      int left = i + 1;
      int right = nums.Length - 1;

      while (left < right)
      {
        int sum = nums[i] + nums[left] + nums[right];

        if (sum < 0)
          left++;
        else if (sum == 0)
        {
          result.Add(new List<int> { nums[i], nums[left++], nums[right--] });

          while (nums[left - 1] == nums[left] && left < right)
            left++;
        }
        else
          right--;
      }
    }

    return result;
  }
}
// Just for fun but it's slow (1400+ ms)
// Time complexity: O(?)
// Space complexity: O(?)
public class Solution 
{
  private class ListComparer<T> : IEqualityComparer<IList<T>>
  {
    public bool Equals(IList<T> x, IList<T> y) => x.SequenceEqual(y);

    public int GetHashCode(IList<T> obj)
    {
      int hash = 17;
      
      foreach (var item in obj)
        hash *= 23 + item.GetHashCode();

      return hash;
    }
  }

  public IList<IList<int>> ThreeSum(int[] nums) 
  {
    HashSet<IList<int>> result = new HashSet<IList<int>>(new ListComparer<int>());
    Dictionary<int, int> dict = new();

    for (int i = 0; i < nums.Length; i++)
    {
      for (int j = i + 1; j < nums.Length; j++)
      {
        int complement = -1 * (nums[i] + nums[j]);

        if (dict.ContainsKey(complement))
        {
          if (dict[complement] != i && dict[complement] != j)
          {
            List<int> triplets = new List<int> { nums[i], nums[j], complement };
            triplets.Sort();
            result.Add(triplets);
          }
        }
      }
      
      dict[nums[i]] = i;
    }
    
    return result.ToList();
  }
}
// TLE
// Time complexity: O(n^3)
// Space complexity: O(n)
public class Solution 
{
  public IList<IList<int>> ThreeSum(int[] nums) 
  {
    List<IList<int>> result = new List<IList<int>>();
    Array.Sort(nums);

    for (int i = 0; i < nums.Length; i++)
    {
      if (i > 0 && nums[i] == nums[i - 1]) continue;

      for (int j = i + 1; j < nums.Length; j++)
      {
        if (j > i + 1 && nums[j] == nums[j - 1]) continue;

        for (int k = j + 1; k < nums.Length; k++)
        {
          if (k > j + 1 && nums[k] == nums[k - 1]) continue;

          int sum = nums[i] + nums[j] + nums[k];

          if (sum == 0)
            result.Add(new List<int> { nums[i], nums[j], nums[k] });
        }
      }
    }

    return result;
  }
}