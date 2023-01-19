/*
You are playing the Bulls and Cows game with your friend.

You write down a secret number and ask your friend to guess what the number is. 
When your friend makes a guess, you provide a hint with the following info:

    The number of "bulls", which are digits in the guess that are in the correct position.
    The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. 
	Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.

Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.

The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. 
Note that both secret and guess may contain duplicate digits.

Example 1:
Input: secret = "1807", guess = "7810"
Output: "1A3B"
Explanation: Bulls are connected with a '|' and cows are underlined:
"1807"
  |
"7810"

Example 2:
Input: secret = "1123", guess = "0111"
Output: "1A1B"
Explanation: Bulls are connected with a '|' and cows are underlined:
"1123"        "1123"
  |      or     |
"0111"        "0111"
Note that only one of the two unmatched 1s is counted as a cow since the non-bull digits can only be rearranged to allow one 1 to be a bull.

Constraints:
    1 <= secret.length, guess.length <= 1000
    secret.length == guess.length
    secret and guess consist of digits only.
*/
// First solution
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution
{
  public string GetHint(string secret, string guess)
  {
    Dictionary<char, int> sDict = new();
    Dictionary<char, int> gDict = new();
    string newSecret = "";
    string newGuess = "";
    int bulls = 0;
    int cows = 0;

    for (int i = 0; i < secret.Length; i++)
    {
      if (secret[i] == guess[i])
      {
        bulls++;
        continue;
      }

      newSecret += secret[i];
      newGuess += guess[i];
    }

    foreach (char c in newSecret)
      if (sDict.ContainsKey(c))
        sDict[c]++;
      else
        sDict[c] = 1;

    foreach (char c in newGuess)
      if (gDict.ContainsKey(c))
        gDict[c]++;
      else
        gDict[c] = 1;

    foreach (var kvp in gDict)
    {
      if (sDict.ContainsKey(kvp.Key))
      {
        int secretValue = sDict[kvp.Key];
        int guessValue = kvp.Value;

        while (secretValue != 0 && guessValue != 0)
        {
          secretValue--;
          guessValue--;
          cows++;
        }
      }
    }

    return $"{bulls}A{cows}B";
  }
}
/*
1807 7810 1A
107 710
0 = 1	0 = 1
1 = 1	1 = 1
7 = 1	7 = 1
3B
1A3B

1123 0111 1A
123 011
		0 = 1
1 = 1	1 = 2
2 = 1	
3 = 1
1B
1A3B
*/