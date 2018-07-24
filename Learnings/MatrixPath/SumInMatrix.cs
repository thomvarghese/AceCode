using System;

namespace MatrixPath
{
    /*Given a random MxN matrix and a positive integer, 
    * recursively Your program should then find a continuous path thought the matrix 
    * starting at position 0,0 that will sum to n.
    * Your program shouldomly move left(col - 1), right(col + 1), up(row - 1) and down(row+1)
    * and can only use a position once in the sum. 
    * If there is a such path in the matrix, 
    * create the path in a separate matrix with the same size, 
    * and replacing the indices used with 1 and the rest 0.
    */
    public static class SumInMatrix
    {

        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }
        }
        public static bool FindPath(int[,] matrix, int[,] output, int sum, int r, int c)
        {
            Console.WriteLine("Row: " + r + ", Col: " + c + " Target: " + sum);
            output[r, c] = 1;
            if (sum - matrix[r, c] == 0)
            {
                return true;
            }
            else if (sum - matrix[r, c] < 0)
            {
                output[r, c] = 0;
                return false;
            }

            if (r + 1 < matrix.GetLength(0) && output[r + 1, c] != 1)
            {
                bool bottom = FindPath(matrix, output, sum - matrix[r, c], r + 1, c);
                if (bottom) return bottom;
            }
            if (r - 1 > -1 && output[r - 1, c] != 1)
            {
                bool top = FindPath(matrix, output, sum - matrix[r, c], r - 1, c);
                if (top) return top;
            }
            if (c - 1 > -1 && output[r, c - 1] != 1)
            {
                bool left = FindPath(matrix, output, sum - matrix[r, c], r, c - 1);
                if (left) return left;
            }
            if (c + 1 < matrix.GetLength(1) && output[r, c + 1] != 1)
            {
                bool right = FindPath(matrix, output, sum - matrix[r, c], r, c + 1);
                if (right) return right;
            }

            output[r, c] = 0;
            return false;
        }
    }
}
