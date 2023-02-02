/*
Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:
    Each row must contain the digits 1-9 without repetition.
    Each column must contain the digits 1-9 without repetition.
    Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.

Note:
    A Sudoku board (partially filled) could be valid but is not necessarily solvable.
    Only the filled cells need to be validated according to the mentioned rules.

Example 1:
Input: board = 
[["5","3",".",".","7",".",".",".","."]
,["6",".",".","1","9","5",".",".","."]
,[".","9","8",".",".",".",".","6","."]
,["8",".",".",".","6",".",".",".","3"]
,["4",".",".","8",".","3",".",".","1"]
,["7",".",".",".","2",".",".",".","6"]
,[".","6",".",".",".",".","2","8","."]
,[".",".",".","4","1","9",".",".","5"]
,[".",".",".",".","8",".",".","7","9"]]
Output: true

Example 2:
Input: board = 
[["8","3",".",".","7",".",".",".","."]
,["6",".",".","1","9","5",".",".","."]
,[".","9","8",".",".",".",".","6","."]
,["8",".",".",".","6",".",".",".","3"]
,["4",".",".","8",".","3",".",".","1"]
,["7",".",".",".","2",".",".",".","6"]
,[".","6",".",".",".",".","2","8","."]
,[".",".",".","4","1","9",".",".","5"]
,[".",".",".",".","8",".",".","7","9"]]
Output: false
Explanation: Same as Example 1, except with the 5 in the top left corner being modified to 8. 
Since there are two 8's in the top left 3x3 sub-box, it is invalid.

Constraints:
    board.length == 9
    board[i].length == 9
    board[i][j] is a digit 1-9 or '.'.
*/
// Time complexity: O(n^2)
// Space complexity: O(n)
public class Solution
{
  public void PrintBoard(char[][] board)
  {
    for (int i = 0; i < board.Length; i++)
    {
      for (int j = 0; j < board[i].Length; j++)
      { 
        if (j < board[i].Length - 1)
          Console.Write(board[i][j] + " ");
        else
          Console.Write(board[i][j]);

        if ((j + 1) % 3 == 0 && j < board[i].Length - 1)
          Console.Write("| ");
      }

      Console.WriteLine();
      if ((i + 1) % 3 == 0 && i < board.Length - 1)
        Console.WriteLine("---------------------");
    }
  }

  public bool IsValidSudoku(char[][] board)
  {
    //PrintBoard(board);

    // check rows/cols
    for (int i = 0; i < board.Length; i++)
    {
      Dictionary<char, int> rows = new();
      Dictionary<char, int> cols = new();
      for (int j = 0; j < board[i].Length; j++)
      {
        if (rows.ContainsKey(board[i][j]))
        {
          //Console.WriteLine($"row: found duplicate ({board[i][j]}) at ({i},{j})");
          return false;
        }
        else if (board[i][j] != '.')
          rows[board[i][j]] = 1;

        if (cols.ContainsKey(board[j][i]))
        {
          //Console.WriteLine($"col: found duplicate ({board[j][i]}) at ({i},{j})");
          return false;
        }
        else if (board[j][i] != '.')
          cols[board[j][i]] = 1;
      }
    }

    // check 3x3 sub-box
    for (int i = 0; i < board.Length; i += 3)
    {
      for (int j = 0; j < board[i].Length; j += 3)
      {
        Dictionary<char, int> square = new();
        for (int k = i; k < i + 3; k++)
        {
          for (int l = j; l < j + 3; l++)
          {
            if (square.ContainsKey(board[k][l]))
            {
              //Console.WriteLine($"square: found duplicate ({board[k][l]}) at ({k},{l})");
              return false;
            }
            else if (board[k][l] != '.')
              square[board[k][l]] = 1;
          }
        }
      }
    }

    return true;
  }
}