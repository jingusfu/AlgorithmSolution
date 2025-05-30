/*
Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.
An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.
Example 1:
Input: grid = [
  ["1","1","1","1","0"],
  ["1","1","0","1","0"],
  ["1","1","0","0","0"],
  ["0","0","0","0","0"]
]
Output: 1
Example 2:
Input: grid = [
  ["1","1","0","0","0"],
  ["1","1","0","0","0"],
  ["0","0","1","0","0"],
  ["0","0","0","1","1"]
]
Output: 3

Constraints:
m == grid.length
n == grid[i].length
1 <= m, n <= 300
grid[i][j] is '0' or '1'.
*/

public class Solution {
    public int NumIslands(char[][] grid) {
        int islands = 0;
        if ((grid==null) || (grid.Length==0))
            return 0;
        for (int i=0; i<grid.Length; i++)
        {
            for (int j=0; j<grid[0].Length; j++)
            {
                if (grid[i][j]=='1')
                {
                    islands++;
                    TraverseGrid(grid, i, j);
                }
            }
        }
        return islands;
    }

    private void TraverseGrid(char[][] grid, int i, int j)
    {
        if ((i<0) || (i>=grid.Length) || (j<0) || (j>=grid[i].Length) || grid[i][j]=='0')
            return;
        grid[i][j] = '0';
        TraverseGrid(grid, i-1, j);
        TraverseGrid(grid, i+1, j);
        TraverseGrid(grid, i, j-1);
        TraverseGrid(grid, i, j+1);
    }
}
