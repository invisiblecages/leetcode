// Time complexity: O(n)
// Space complexity: O(1)
public class Solution 
{
  public class Graph
  {
    private const int IMPOSSIBLE = 1000001 * 2;
    private const int MAXNODES = 26;
    private int[,] _matrix;

    public Graph(char[] original, char[] changed, int[] cost)
    {
      _matrix = new int[MAXNODES, MAXNODES];
      InitializeMatrix();
      AddEdges(original, changed, cost);
    }

    private void InitializeMatrix()
    {
      for (int i = 0; i < MAXNODES; i++) 
      {
        for (int j = 0; j < MAXNODES; j++) 
        {
          _matrix[i, j] = (i == j) ? 0 : IMPOSSIBLE;
        }
      }
    }

    private void AddEdges(char[] original, char[] changed, int[] cost)
    {
      for (int i = 0; i < original.Length; i++)
      {
        int from = original[i] - 'a';
        int to = changed[i] - 'a';

        _matrix[from, to] =  Math.Min(_matrix[from, to], cost[i]);
      }
    }

    public void FloydWarshall()
    {
      for (int k = 0; k < MAXNODES; k++) 
      {
        for (int i = 0; i < MAXNODES; i++) 
        {
          for (int j = 0; j < MAXNODES; j++) 
          {
            _matrix[i, j] = Math.Min(_matrix[i, j], _matrix[i, k] + _matrix[k, j]);
          }
        }
      }
    }

    public long GetMinimumCostToConvertString(string source, string target)
    {
      long cost = 0;

      for (int i = 0; i < source.Length; i++)
      {
        int src = source[i] - 'a';
        int tar = target[i] - 'a';

        if (_matrix[src, tar] == IMPOSSIBLE)
        {
          return -1;
        }

        cost += _matrix[src, tar];
      }

      return cost;
    }
  }

  public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost) 
  {
    var graph = new Graph(original, changed, cost);
    graph.FloydWarshall();

    return graph.GetMinimumCostToConvertString(source, target);
  }
}