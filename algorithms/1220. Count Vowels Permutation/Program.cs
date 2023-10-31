/*

*/
// First solution
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution 
{
  private readonly int mod = 1000000000 + 7;
  private int[,] cache;

  private int DFS(int n, Vowel vowel)
  {
    if (n == 0)
      return 1;
    
    int index = (int)vowel;

    if (cache[n, index] != 0)
      return cache[n, index];

    int result = 0;

    // vowel 'a' may only be followed by an 'e'.
    if (vowel == Vowel.a)
      result = DFS(n - 1, Vowel.e);
    // vowel 'e' may only be followed by an 'a' or an 'i'.
    else if (vowel == Vowel.e)
      result = (DFS(n - 1, Vowel.a) + DFS(n - 1, Vowel.i)) % mod;
    // vowel 'i' may not be followed by another 'i'.
    else if (vowel == Vowel.i)
      result = ((DFS(n - 1, Vowel.a) + DFS(n - 1, Vowel.e)) % mod + 
        (DFS(n - 1, Vowel.o) + DFS(n - 1, Vowel.u)) % mod) % mod;
    // vowel 'o' may only be followed by an 'i' or a 'u'.
    else if (vowel == Vowel.o)
      result = (DFS(n - 1, Vowel.i) + DFS(n - 1, Vowel.u)) % mod;
    // vowel 'u' may only be followed by an 'a'.
    else
      result = DFS(n - 1, Vowel.a);

    cache[n, index] = result;
    return result;
  }

  public enum Vowel
  {
    a, e, i, o, u
  }

  public int CountVowelPermutation(int n) 
  {
    int vowels = Enum.GetNames(typeof(Vowel)).Length;
    cache = new int[n, vowels];
    int count = 0;

    for (int i = 0; i < vowels; i++)
    {
      count = (count + DFS(n - 1, (Vowel) i)) % mod;
    }

    return count;
  }
}
// "Nicer" solution
// Time complexity: O(n)
// Space complexity: O(1)
public class Solution 
{
  private readonly int _mod = (int) Math.Pow(10, 9) + 7;

  public int CountVowelPermutation(int n) 
  {
    // vowel 'a' may only be followed by an 'e'.
    // possible strings ending with a: e, i, u

    // vowel 'e' may only be followed by an 'a' or an 'i'.
    // possible strings ending with e: a, i

    // vowel 'i' may not be followed by another 'i'.
    // possible strings ending with i: e, o

    // vowel 'o' may only be followed by an 'i' or a 'u'.
    // possible strings ending with o: i

    // vowel 'u' may only be followed by an 'a'.
    // possible strings ending with u: i, o

    long a = 1, e = 1, i = 1, o = 1, u = 1;

    for (int index = 1; index < n; index++)
    {
      long endsWithA = (e + i + u) % _mod;
      long endsWithE = (a + i) % _mod;
      long endsWithI = (e + o) % _mod;
      long endsWithO = i;
      long endsWithU = (i + o) % _mod;

      a = endsWithA;
      e = endsWithE;
      i = endsWithI;
      o = endsWithO;
      u = endsWithU;
    }

    return (int) ((a + e + i + o + u) % _mod);
  }
}