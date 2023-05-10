/*
Given a string s and an integer k, return the maximum number of vowel letters in any substring of s with length k.

Vowel letters in English are 'a', 'e', 'i', 'o', and 'u'.

Example 1:

Input: s = "abciiidef", k = 3
Output: 3
Explanation: The substring "iii" contains 3 vowel letters.

Example 2:

Input: s = "aeiou", k = 2
Output: 2
Explanation: Any substring of length 2 contains 2 vowels.

Example 3:

Input: s = "leetcode", k = 3
Output: 2
Explanation: "lee", "eet" and "ode" contain 2 vowels.

Constraints:

    1 <= s.length <= 105
    s consists of lowercase English letters.
    1 <= k <= s.length

*/
// Time complexity: O(n)
// Space complexity: O(1)
public class Solution 
{
  public int MaxVowels(string s, int k) 
  {
    HashSet<char> vowels = new() { 'a', 'e', 'i', 'o', 'u' };
    int maxSubstringVowels = 0;
    int countVowels = 0;
    int left = 0;
    string substring = s.Substring(left, k);

    while (left <= s.Length - k)
    {
      if (left == 0)
        countVowels = substring.Where(chr => vowels.Contains(chr)).Count();
      else if (vowels.Contains(s[left + k - 1]))
        countVowels++;
          
      maxSubstringVowels = Math.Max(maxSubstringVowels, countVowels);

      if (vowels.Contains(s[left]))
          countVowels--;

      left++;
    }
    
    return maxSubstringVowels;
  }
}