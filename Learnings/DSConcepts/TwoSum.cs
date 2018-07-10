using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSConcepts
{
    public class TwoSumSolution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[2];
            Dictionary<int, int> compliments = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (compliments.ContainsKey(target - nums[i]))
                {
                    result[0] = compliments[target - nums[i]];
                    result[1] = i;
                    return result;
                }
                if (!compliments.ContainsKey(nums[i]))
                    compliments.Add(nums[i], i);
            }
            return result;
        }
    }

   
}
