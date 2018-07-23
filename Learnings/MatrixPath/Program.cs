using System;

namespace MatrixPath
{
    class Program
    {
        static void Main(string[] args)
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


            int[,] input = new int[,]
                {
                        {9, 1, 1, 6, 9, 1, 4, 8, 5, 3, 2, 5, 9, 4, 4},
                        {7, 1, 6, 6, 3, 6, 9, 3, 3, 7, 0, 9, 3, 0, 1},
                        {9, 2, 6, 7, 3, 7, 0, 7, 8, 1, 6, 7, 0, 7, 5},
                        {0, 3, 3, 3, 4, 2, 9, 4, 8, 5, 4, 5, 0, 9, 0},
                        {4, 3, 1, 4, 4, 4, 5, 0, 6, 9, 5, 7, 8, 7, 5},
                        {4, 7, 1, 4, 6, 5, 4, 0, 1, 9, 0, 1, 8, 6, 0},
                        {6, 8, 5, 9, 7, 8, 3, 6, 7, 5, 5, 1, 0, 4, 4},
                        {1, 6, 2, 9, 8, 2, 5, 9, 7, 4, 9, 9, 7, 5, 5},
                        {9, 1, 9, 9, 0, 9, 5, 6, 4, 9, 4, 4, 9, 9, 9},
                        {4, 1, 5, 3, 1, 5, 9, 0, 2, 4, 1, 2, 8, 4, 3}
                };
            int sum = 34;
            int[,] output = new int[input.GetLength(0), input.GetLength(1)];

            if (SumInMatrix.FindPath(input, output, sum, 0, 0))
                SumInMatrix.PrintMatrix(output);

            Console.ReadLine();
        }
    }


        
    

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
            output[r,c] = 1;
            if (sum - matrix[r,c] == 0)
            {
                return true;
            }
            else if (sum - matrix[r,c] < 0){
                output[r,c] = 0;
                return false;
            }

            if (r + 1 < matrix.GetLength(0) && output[r + 1, c] != 1)
            {
                bool bottom = FindPath(matrix, output, sum - matrix[r,c], r + 1, c);
                if (bottom) return bottom;
            }
            if (r - 1 > -1 && output[r - 1, c] != 1)
            {
                bool top = FindPath(matrix, output, sum - matrix[r,c], r - 1, c);
                if (top) return top;
            }
            if (c - 1 > -1 && output[r, c - 1] != 1)
            {
                bool left = FindPath(matrix, output, sum - matrix[r,c], r, c - 1);
                if (left) return left;
            }
            if (c + 1 < matrix.GetLength(1) && output[r, c + 1] != 1)
            {
                bool right = FindPath(matrix, output, sum - matrix[r,c], r, c + 1);
                if (right) return right;
            }

            output[r,c] = 0;
            return false;
        }
    }
}
