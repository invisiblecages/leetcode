﻿/*
There are n bulbs that are initially off. You first turn on all the bulbs, then you turn off every second bulb.

On the third round, you toggle every third bulb (turning on if it's off or turning off if it's on). 
For the ith round, you toggle every i bulb. For the nth round, you only toggle the last bulb.

Return the number of bulbs that are on after n rounds. 

Example 1:

Input: n = 3
Output: 1
Explanation: At first, the three bulbs are [off, off, off].
After the first round, the three bulbs are [on, on, on].
After the second round, the three bulbs are [on, off, on].
After the third round, the three bulbs are [on, off, off]. 
So you should return 1 because there is only one bulb is on.

Example 2:

Input: n = 0
Output: 0

Example 3:

Input: n = 1
Output: 1

Constraints:

    0 <= n <= 109
*/
// Time complexity: O(1)
// Space complexity: O(1)
public class Solution 
{
  public int BulbSwitch(int n) => (int)Math.Sqrt(n);
}
/*
As we know that there are n bulbs, let's name them as 1, 2, 3, 4, ..., n.

    You first turn on all the bulbs.
    Then, you turn off every second bulb.(2, 4, 6, ...)
    On the third round, you toggle every third bulb.(3, 6, 9, ...)
    For the ith round, you toggle every i bulb.(i, 2i, 3i, ...)
    For the nth round, you only toggle the last bulb.(n)

If n > 6, you can find that bulb 6 is toggled in round 2 and 3.

Later, it will also be toggled in round 6, and round 6 will be the last round when bulb 6 is toggled.

Here, 2,3 and 6 are all factors of 6 (except 1).
Prove:

We can come to the conclusion that the bulb i is toggled k times.

Here, k is the number of i's factors (except 1).

k + 1 will be the total number of i's factors

For example:

    Factors of 6: 1, 2, 3, 6 (3 factors except 1, so it will be toggled 3 times)
    Factors of 7: 1, 7 (1 factors except 1, so it will be toggled once)
    ....

Now, the key problem here is to judge whether k is even or odd.

Since all bulbs are on at the beginning, we can get:

    If k is odd, the bulb will be off in the end.(after odd times of toggling).
    If k is even, the bulb i will be on in the end (after even times of toggling).

As we all know, a natural number can divided by 1 and itself, and all factors appear in pairs.

When we know that p is i's factor, we are sure q = i/p is also i's factor.

If i has no factor p that makes p = i/p, k+ 1 is even.

If i has a factor p that makes p = i/p (i = p^2, i is a perfect square of p), k+ 1 is odd.

So we get that in the end:

    If i is a perfect square , k+ 1 is odd, k is even (bulb i is on).
    If i is NOT a perfect square , k+ 1 is even, k is odd (bulb i is off).

We want to find how many bulbs are on after n rounds (In the end).

That means we need to find out how many perfect square numbers are NO MORE than n.

The number of perfect square numbers which are no more than n, 
is the square root of the maximum perfect square number which is NO MORE than n
Result:

The square root of the maximum perfect square number which is NO MORE than n is the
integer part of sqrt(n).

(If i = 1, it will NEVER be toggled, k is 0 (even) here which meets the requirement.)
*/
// TLE
public class Solution 
{
  public int BulbSwitch(int n) 
  {
    int count = 0;
    bool[] bulbs = new bool[n];
    
    for (int i = 1; i <= n; i++)
      for (int j = i - 1; j < n; j += i)
        bulbs[j] = !bulbs[j];

    for (int i = 0; i < n; i++)
      if (bulbs[i])
        count++;

    return count;
  }
}