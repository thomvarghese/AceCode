using System;
using System.Collections.Generic;

namespace NQueens
{
    public class NQueens
    {
        public IList<IList<string>> SolveNQueens(int n)
        {
            IList<IList<string>> result = new List<IList<string>>();

            char[,] backtrack = new char[n, n];
            for (int i = 0; i < backtrack.GetLength(0); i++)
                for (int j = 0; j < backtrack.GetLength(1); j++)
                    backtrack[i, j] = '.';

            NQueensHelper(result, backtrack, 0, n); //Start backtracking from row 1 to n
            return result;
        }


        private void NQueensHelper(IList<IList<String>> result, char[,] backtrack, int row, int n)
        {
            //if recursed all the way, that means we have a valid solution, add that to result
            if (row == n)
            {
                IList<String> solution = new List<string>();
                for (int i = 0; i < n; i++)
                {
                    string s = "";
                    for (int j = 0; j < n; j++)
                        s = s + backtrack[i, j];
                    solution.Add(s);
                }
                result.Add(solution);   //out put this solution
                return;
            }

            //check every col at each row to see if that position is valid
            for (int col = 0; col < n; col++)
            {
                if (IsValid(backtrack, row, col, n))
                {
                    //place Q at (row,col) and go to the next row recursively
                    backtrack[row, col] = 'Q';
                    NQueensHelper(result, backtrack, row + 1, n);
                    //withdraw Q at (row,col)
                    backtrack[row, col] = '.';
                }
            }
        }

        private bool IsValid(char[,] backtrack, int row, int col, int n)
        {
            // check if there is a Q in the same column and diagonal
            int cur_goleft = col, cur_goright = col;
            for (int r = row - 1; r >= 0; r--)
            {
                // if Q exists in the same column
                if (backtrack[r, col] == 'Q')
                    return false;

                //check backwards through diagonal towards left/0
                if (cur_goleft > 0)
                {
                    cur_goleft--;
                    if (backtrack[r, cur_goleft] == 'Q')
                        return false;
                }

                //check backwards through diagonal towards right/n
                if (cur_goright < n - 1)
                {
                    cur_goright++;
                    if (backtrack[r, cur_goright] == 'Q')
                        return false;
                }
            }
            return true;
        }
    }
}
