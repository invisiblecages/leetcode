/*
You are given an integer array arr. 
Sort the integers in the array in ascending order by the number of 1's in their binary representation 
and in case of two or more integers have the same number of 1's you have to sort them in ascending order.

Return the array after sorting it.

Example 1:

Input: arr = [0,1,2,3,4,5,6,7,8]
Output: [0,1,2,4,8,3,5,6,7]
Explantion: [0] is the only integer with 0 bits.
[1,2,4,8] all have 1 bit.
[3,5,6] have 2 bits.
[7] has 3 bits.
The sorted array by bits is [0,1,2,4,8,3,5,6,7]

Example 2:

Input: arr = [1024,512,256,128,64,32,16,8,4,2,1]
Output: [1,2,4,8,16,32,64,128,256,512,1024]
Explantion: All integers have 1 bit in the binary representation, you should just sort them in ascending order.

Constraints:

    1 <= arr.length <= 500
    0 <= arr[i] <= 104
*/
// Time complexity: O(n * log n)
// Space complexity: O(n)
public class Solution 
{
  public int[] SortByBits(int[] arr) 
  {
    SortedDictionary<int, List<int>> sortedDict = new();

    for (int i = 0; i < arr.Length; i++)
    {
      string binary = Convert.ToString(arr[i], 2);
      int bits = binary.Count(b => b == '1');

      if (!sortedDict.ContainsKey(bits))
        sortedDict[bits] = new List<int>();

      sortedDict[bits].Add(arr[i]);
    }

    int index = 0;

    foreach (var kvp in sortedDict)
    {
      kvp.Value.Sort();
      kvp.Value.CopyTo(arr, index);
      index += kvp.Value.Count;
    }

    return arr;  
  }
}