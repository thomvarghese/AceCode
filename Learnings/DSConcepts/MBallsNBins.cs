namespace DSConcepts
{
    public static class MBallsNBins
    {
        public static int AssignBalls(int m, int n)
        {
            if (m == 0 || n == 1)
            {
                return 1;
            }
            if (n > m)
            {
                return AssignBalls(m, m);
            }
            else
            {
                return AssignBalls(m, n - 1) + AssignBalls(m - n, n);
            }
        }
    }
}
