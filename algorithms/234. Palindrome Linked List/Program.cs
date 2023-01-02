/*
Given the head of a singly linked list, return true if it is a palindrome or false otherwise.

Example 1:
Input: head = [1,2,2,1]
Output: true

Example 2:
Input: head = [1,2]
Output: false

Constraints:
    The number of nodes in the list is in the range [1, 105].
    0 <= Node.val <= 9

Follow up: Could you do it in O(n) time and O(1) space?
*/
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
 
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution {
    public bool IsPalindrome(ListNode head) {
        List<int> nums = new();
        while (head != null)
        {
            nums.Add(head.val);
            head = head.next;
        }

        for (int i = 0; i < nums.Count / 2; i++)
            if (nums[i] != nums[nums.Count - i - 1])
                return false;

        return true;
    }
}