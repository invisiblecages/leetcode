/*
Given an integer array nums and an integer k, return the kth largest element in the array.
Note that it is the kth largest element in the sorted order, not the kth distinct element.
You must solve it in O(n) time complexity.

Example 1:
Input: nums = [3,2,1,5,6,4], k = 2
Output: 5

Example 2:
Input: nums = [3,2,3,1,2,4,5,5,6], k = 4
Output: 4

Constraints:
    1 <= k <= nums.length <= 105
    -104 <= nums[i] <= 104
*/
// Time complexity: O(n * log n)
// Space complexity: O(n)
public class Solution
{
  public int FindKthLargest(int[] nums, int k)
  {
    PriorityQueue<int, int> pq = new();
    foreach (int num in nums)
      pq.Enqueue(num, -num);

    int res = 0;
    for (int i = 0; i < k; i++)
      res = pq.Dequeue();

    return res;  
  }
}
// Time complexity: O(n * log n)
// Space complexity: O(n)
public class Solution
{
  public int FindKthLargest(int[] nums, int k)
  {
    PriorityQueue<int, int> pq = new();
    foreach (int num in nums)
      pq.Enqueue(num, num);

    while (pq.Count > k)
      pq.Dequeue();

    return pq.Peek();
  }
}

// Time complexity: O(n * log k)
// Space complexity: O(k)
public class Solution
{
  public int FindKthLargest(int[] nums, int k)
  {
    PriorityQueue<int, int> pq = new();
    foreach (int num in nums)
        if (pq.Count < k)
            pq.Enqueue(num, num);
        else
        {
            if (num <= pq.Peek())
                continue;
            
            pq.Dequeue();
            pq.Enqueue(num, num);
        }

    return pq.Dequeue();
  }
}