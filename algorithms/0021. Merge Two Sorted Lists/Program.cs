/*
You are given the heads of two sorted linked lists list1 and list2.

Merge the two lists in a one sorted list. The list should be made by splicing together the nodes of the first two lists.

Return the head of the merged linked list.

Example 1:
Input: list1 = [1,2,4], list2 = [1,3,4]
Output: [1,1,2,3,4,4]

Example 2:
Input: list1 = [], list2 = []
Output: []

Example 3:
Input: list1 = [], list2 = [0]
Output: [0]

Constraints:
    The number of nodes in both lists is in the range [0, 50].
    -100 <= Node.val <= 100
    Both list1 and list2 are sorted in non-decreasing order.
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
public class Solution
{
  public ListNode MergeTwoLists(ListNode list1, ListNode list2)
  {
    ListNode list3 = new();
    ListNode tail = list3;
    while (list1 != null && list2 != null)
    {
      if (list1.val > list2.val)
      {
        list3.next = list2;
        list2 = list2.next;
      }
      else
      {
        list3.next = list1;
        list1 = list1.next;
      }

      list3 = list3.next;
    }
    
    if (list1 != null)
      list3.next = list1;
    else
      list3.next = list2;

    return tail.next;
  }
}
// Recursion
public class Solution {
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        if(list1 == null)
            return list2;

        if(list2 == null)
            return list1;

        if(list1.val < list2.val)
        {
            list1.next = MergeTwoLists(list1.next, list2);
            return list1;
        }
        else
        {
            list2.next = MergeTwoLists(list2.next, list1);
            return list2;
        }
    }
}