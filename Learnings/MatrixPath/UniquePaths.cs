namespace MatrixPath
{
    public class UniquePaths
    {
        /*
         * A robot is located at the top-left corner of a m x n grid 
         * The robot can only move either down or right at any point in time. 
         * The robot is trying to reach the bottom-right corner of the grid 
         * Now consider if some obstacles are added to the grids(marked by 1 in the grid). 
         * How many unique paths would there be?
         * */

        public int UniquePathsWithObstacles(int[,] obstacleGrid)
        {

            //Empty case
            if (obstacleGrid.Length == 0) return 0;

            int rows = obstacleGrid.GetLength(0);
            int cols = obstacleGrid.GetLength(1);
            //As we loop through, update the count of paths
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (obstacleGrid[i, j] == 1)
                        obstacleGrid[i, j] = 0;
                    else if (i == 0 && j == 0)
                        obstacleGrid[i, j] = 1;
                    else if (i == 0)
                        obstacleGrid[i, j] = obstacleGrid[i, j - 1] * 1;// For row 0, if there are no paths to left cell, then its 0,else 1
                    else if (j == 0)
                        obstacleGrid[i, j] = obstacleGrid[i - 1, j] * 1;// For col 0, if there are no paths to upper cell, then its 0,else 1
                    else
                        obstacleGrid[i, j] = obstacleGrid[i - 1, j] + obstacleGrid[i, j - 1];
                }
            }

            return obstacleGrid[rows - 1, cols - 1];
        }
    }
}
