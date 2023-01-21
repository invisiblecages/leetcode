/*
Given two strings s and t, return true if they are equal when both are typed into empty text editors. '#' means a backspace character.

Note that after backspacing an empty text, the text will continue empty.

Example 1:
Input: s = "ab#c", t = "ad#c"
Output: true
Explanation: Both s and t become "ac".

Example 2:
Input: s = "ab##", t = "c#d#"
Output: true
Explanation: Both s and t become "".

Example 3:
Input: s = "a#c", t = "b"
Output: false
Explanation: s becomes "c" while t becomes "b".

Constraints:
    1 <= s.length, t.length <= 200
    s and t only contain lowercase letters and '#' characters.

Follow up: Can you solve it in O(n) time and O(1) space?
*/
// Time complexity: O(n)
// Space complexity: O(n) s + t
public class Solution
{
  public bool BackspaceCompare(string s, string t)
  {
    Stack<char> sStack = new();
    Stack<char> tStack = new();
    foreach (char c in s)
    {
      if (c != '#')
        sStack.Push(c);
      else if (sStack.TryPop(out char result))
        continue;
    }

    foreach (char c in t)
    {
      if (c != '#')
        tStack.Push(c);
      else if (tStack.TryPop(out char result))
        continue;
    }

    if (sStack.Count != tStack.Count)
      return false;
    
    while (sStack.Count > 0)
      if (sStack.Pop() != tStack.Pop())
        return false;

    return true;
  }
}
// Follow up
// Time complexity: O(n)
// Space complexity: O(1)