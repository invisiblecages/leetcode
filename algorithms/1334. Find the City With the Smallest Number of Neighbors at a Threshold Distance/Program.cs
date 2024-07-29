// Time complexity: O(n^3)
// Space complexity: O(n^2)
public class Solution 
{
  public class Graph
  {
    private int[,] _matrix;
    private int _n;

    public Graph(int n, int[][] edges)
    {
      _n = n;
      InitializeMatrix();
      AddEdges(edges);
    }

    private void InitializeMatrix()
    {
      _matrix = new int[_n, _n];

      for (int i = 0; i < _n; i++) 
      {
        for (int j = 0; j < _n; j++) 
        {
          _matrix[i, j] = (i == j) ? 0 : 10001;
        }
      }
    }

    private void AddEdges(int[][] edges)
    {
      foreach (var edge in edges)
      {
        int from = edge[0];
        int to = edge[1];
        int weight = edge[2];

        _matrix[from, to] = weight;
        _matrix[to, from] = weight;
      }
    }

    public void FloydWarshall()
    {
      for (int k = 0; k < _n; k++) 
      {
        for (int i = 0; i < _n; i++) 
        {
          for (int j = 0; j < _n; j++) 
          {
            _matrix[i, j] = Math.Min(_matrix[i, j], _matrix[i, k] + _matrix[k, j]);
          }
        }
      }
    }

    public int FindNodeWithMinNeighbors(int distanceThreshold)
    {
      int node = 0;
      int minNeighbors = _n;

      for (int i = 0; i < _n; i++)
      {
        int neighbors = 0;

        for (int j = 0; j < _n; j++)
        {
          if (_matrix[i, j] <= distanceThreshold)
          {
            neighbors++;
          }
        }

        if (neighbors <= minNeighbors)
        {
          minNeighbors = neighbors;
          node = i;
        }
      }

      return node;
    }
  }

  public int FindTheCity(int n, int[][] edges, int distanceThreshold) 
  {
    var graph = new Graph(n, edges);
    graph.FloydWarshall();

    return graph.FindNodeWithMinNeighbors(distanceThreshold);
  }
}