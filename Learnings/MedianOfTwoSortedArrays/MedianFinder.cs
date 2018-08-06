using System;

namespace MedianOfTwoSortedArrays
{
    public class MedianFinder
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            //always take the smallest array as the first one

            int x, y;
            int[] input1, input2;
            if (nums1.Length > nums2.Length)
            {
                x = nums2.Length;
                y = nums1.Length;
                input1 = nums2;
                input2 = nums1;
            }
            else
            {
                x = nums1.Length;
                y = nums2.Length;
                input1 = nums1;
                input2 = nums2;
            }

            //we will do a binary search on the smaller array(which is of length x)
            int low = 0;
            int high = x;

            while (low <= high)
            {
                int partitionX = (low + high) / 2;
                int partitionY = (x + y + 1) / 2 - partitionX;

                //if partitionX is 0, then there is nothing on the left side and in that case use Int.Min
                //if partitionX is same as the length, then there is nothing on the right side and in that case use Int.Max

                int maxLeftX = (partitionX == 0) ? Int32.MinValue : input1[partitionX - 1];
                int minRightX = (partitionX == x) ? Int32.MaxValue : input1[partitionX];

                int maxLeftY = (partitionY == 0) ? Int32.MinValue : input2[partitionY - 1];
                int minRightY = (partitionY == y) ? Int32.MaxValue : input2[partitionY];

                if (maxLeftX <= minRightY && maxLeftY <= minRightX)
                {
                    //this means, the partitions are correct and we just need to find the median
                    //if the combined length of the arrays is even, then we get the max of left and min of right and get the average
                    //if the combined length is odd, then it will on the leff - get the max of left side
                    if ((x + y) % 2 == 0)
                    {
                        double maxLeft = (double)(Math.Max(maxLeftX, maxLeftY));
                        double minRight = (double)(Math.Min(minRightX, minRightY));
                        return (maxLeft + minRight) / 2;
                    }
                    else
                        return (double)(Math.Max(maxLeftX, maxLeftY));
                }
                else if (maxLeftX > minRightY)
                {
                    //this means we more on the right and need to move more to left
                    high = partitionX - 1;
                }
                else
                    low = partitionX + 1;
            }
            return (double)(Int32.MinValue);
        }
    }
}
