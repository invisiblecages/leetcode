/*
Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:
    Open brackets must be closed by the same type of brackets.
    Open brackets must be closed in the correct order.
    Every close bracket has a corresponding open bracket of the same type.

Example 1:
Input: s = "()"
Output: true

Example 2:
Input: s = "()[]{}"
Output: true

Example 3:
Input: s = "(]"
Output: false

Constraints:
    1 <= s.length <= 104
    s consists of parentheses only '()[]{}'.
*/
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution
{
  public bool IsValid(string s)
  {
    Stack<char> stack = new();
    foreach (char c in s)
    {
        if (c == '(') { stack.Push(')'); continue; }
        if (c == '{') { stack.Push('}'); continue; }
        if (c == '[') { stack.Push(']'); continue; }
        if (stack.Count == 0 || c != stack.Pop()) return false;
    }
    
    return stack.Count == 0;
  }
}
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution
{
  public bool IsValid(string s)
  {
    Stack<char> stack = new();
    Dictionary<char, char> dict = new()
    {
      { '(', ')' },
      { '[', ']' },
      { '{', '}' }
    };

    foreach (char c in s)
      if (dict.ContainsKey(c))
        stack.Push(c);
      else if (stack.Count == 0 || c != dict[stack.Pop()])
        return false;

    return stack.Count == 0;
  }
}
// First solution
// Time complexity: O(n * n(replace)) ?
// Space complexity: O(n)
public class Solution
{
  public bool IsValid(string s)
  {
    while (s.Contains("()") || s.Contains("[]") || s.Contains("{}"))
      s = s.Replace("()", "").Replace("[]", "").Replace("{}", "");

    return string.IsNullOrEmpty(s);
  }
}