/*
Alice has some number of cards and she wants to rearrange the cards into groups so that each group is of size groupSize, 
and consists of groupSize consecutive cards.

Given an integer array hand where hand[i] is the value written on the ith card and an integer groupSize, 
return true if she can rearrange the cards, or false otherwise.

Example 1:

Input: hand = [1,2,3,6,2,3,4,7,8], groupSize = 3
Output: true
Explanation: Alice's hand can be rearranged as [1,2,3],[2,3,4],[6,7,8]

Example 2:

Input: hand = [1,2,3,4,5], groupSize = 4
Output: false
Explanation: Alice's hand can not be rearranged into groups of 4.

Constraints:

    1 <= hand.length <= 10^4
    0 <= hand[i] <= 10^9
    1 <= groupSize <= hand.length
*/
// Time complexity: O(n * log n)
// Space complexity: O(n)
public class Solution 
{
  public bool IsNStraightHand(int[] hand, int groupSize) 
  {
    if (hand.Length % groupSize != 0)
    {
      return false;
    }

    Dictionary<int, int> cards = [];

    Array.Sort(hand);

    foreach (int card in hand)
    {
      cards[card] = cards.ContainsKey(card) ? cards[card] + 1 : 1;
    }
    
    while (cards.Count > 0)
    {
      int smallestCard = cards.FirstOrDefault().Key;

      for (int i = 0; i < groupSize; i++)
      {
        int card = smallestCard + i;

        if (!cards.ContainsKey(card))
        {
          return false;
        }

        cards[card]--;

        if (cards[card] == 0)
        {
          cards.Remove(card);
        }
      }
    }

    return true; 
  }
}