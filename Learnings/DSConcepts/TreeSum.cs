using System;
using System.Collections.Generic;

namespace DSConcepts
{
    public static class ThreeSum
    {

        public static List<int> FindTriplets(int[] nums, int sum)
        {
            var result = new List<int>();
            if (nums.Length < 3) return result;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                var remainTwoSum = sum - nums[i];
                Dictionary<int, int> compliments = new Dictionary<int, int>();
                for (int j = i +1; j < nums.Length; j++)
                {
                    if (compliments.ContainsKey(remainTwoSum - nums[j]))
                        return new List<int>() { i, compliments[remainTwoSum - nums[j]], j };
                    else
                    {
                        if (!compliments.ContainsKey(nums[j]))
                            compliments.Add(nums[j], j);
                    }
                            
                }
            }
            return result;
        }
        public static IList<IList<int>> ThreeSumToZero(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (nums.Length < 3) return result;
            Array.Sort(nums);

            if (nums[0] > 0) return result;

            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;

                int start = i + 1;
                int last = nums.Length - 1;
                while (start < last)
                {
                    if (nums[i] + nums[start] + nums[last] == 0)
                    {
                        List<int> newList = new List<int>() { nums[i], nums[start], nums[last] };
                        result.Add(newList);
                        while (start < last && nums[last] == nums[last - 1]) last--;
                        while (start < last && nums[start] == nums[start + 1]) start++;
                    }
                    last--;
                    if (start == last)
                    {
                        last = nums.Length - 1;
                        start++;
                    }
                }
            }
            return result;
        }
    }
}
