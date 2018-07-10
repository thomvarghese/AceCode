using System;

namespace DSConcepts
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = MBallsNBins.AssignBalls(4, 3);
            Console.WriteLine(res);
            Console.ReadLine();


            var nums = new int[] { 2, 3, 6, 4, 8, 9, 11, 13, 14, 17 };
            var result = ThreeSum.FindTriplets(nums, 14);
            foreach(int i in result)
            {
                Console.WriteLine(nums[i]);
            }
            Console.ReadLine();
        }

    }
    
}
