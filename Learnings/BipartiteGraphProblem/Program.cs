namespace BipartiteGraphProblem
{
    // A C# program to find maximal
    // Bipartite matching.
    using System;

    class FindMaxPossible
    {
        // M is number of applicants 
        // and N is number of jobs
        static int M = 6;
        static int N = 6;

        // A DFS based recursive function 
        // that returns true if a matching 
        // for vertex u is possible
        bool bpm(bool[,] bpGraph, int applicant,
                 bool[] seen, int[] matchR)
        {
            // Try every job one by one
            for (int job = 0; job < N; job++)
            {
                // If applicant u is interested 
                // in job v and v is not visited
                if (bpGraph[applicant, job] && !seen[job])
                {
                    // Mark v as visited
                    seen[job] = true;

                    // If job is not assigned to
                    // an applicant OR previously assigned 
                    // applicant for job v (which is matchR[v])
                    // has an alternate job available.
                    // Since v is marked as visited in the above 
                    // line, matchR[v] in the following recursive 
                    // call will not get job 'v' again
                    if (matchR[job] < 0 || bpm(bpGraph, matchR[job],
                                             seen, matchR))
                    {
                        matchR[job] = applicant;
                        return true;
                    }
                }
            }
            return false;
        }

        // Returns maximum number of 
        // matching from M to N
        int MaxBPM(bool[,] bpGraph)
        {
            // An array to keep track of the 
            // applicants assigned to jobs. 
            // The value of matchR[i] is the 
            // applicant number assigned to job i, 
            // the value -1 indicates nobody is assigned.
            int[] matchR = new int[N];

            // Initially all jobs are available
            for (int i = 0; i < N; ++i)
                matchR[i] = -1;

            // Count of jobs assigned to applicants
            int result = 0;
            for (int applicant = 0; applicant < M; applicant++)
            {
                // Mark all jobs as not
                // seen for next applicant.
                bool[] seen = new bool[N];
                for (int job = 0; job < N; ++job)
                    seen[job] = false;

                // Find if the applicant 
                // 'u' can get a job
                if (bpm(bpGraph, applicant, seen, matchR))
                    result++;
            }
            return result;
        }

        // Driver Code
        public static void Main()
        {
            // Let us create a bpGraph shown 
            // in the above example
            bool[,] bpGraph = new bool[,]
                              {{false, true, true,
                            false, false, false},
                           {true, false, false,
                            true, false, false},
                           {false, false, true,
                            false, false, false},
                           {false, false, true,
                            true, false, false},
                           {false, false, false,
                            false, false, false},
                           {false, false, false,
                            false, false, true}};
            FindMaxPossible m = new FindMaxPossible();
            Console.Write("Maximum number of applicants that can" +
                                    " get job is " + m.MaxBPM(bpGraph));
        }
    }
}
