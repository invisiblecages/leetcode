/*
You're given strings jewels representing the types of stones that are jewels, and stones representing the stones you have. 
Each character in stones is a type of stone you have. You want to know how many of the stones you have are also jewels.

Letters are case sensitive, so "a" is considered a different type of stone from "A".

Example 1:

Input: jewels = "aA", stones = "aAAbbbb"
Output: 3

Example 2:

Input: jewels = "z", stones = "ZZ"
Output: 0

Constraints:

    1 <= jewels.length, stones.length <= 50
    jewels and stones consist of only English letters.
    All the characters of jewels are unique.
*/
// First solution
// Time complexity: O(n * m)
// Space complexity: O(1)
public class Solution 
{
  public int NumJewelsInStones(string jewels, string stones) 
    => stones.Count(s => jewels.Contains(s));
}
// Faster solution
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution 
{
  public int NumJewelsInStones(string jewels, string stones) 
  {
    HashSet<char> jewelSet = new(jewels);
    int numJewelsInStones = 0;

    foreach (char stone in stones)
      if (jewelSet.Contains(stone))
        numJewelsInStones++;

    return numJewelsInStones;
  }
}