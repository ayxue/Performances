using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;

namespace LeetCodeCSharp
{
    /// <summary>
    /// https://leetcode.cn/problems/two-sum/
    /// 
    /// </summary>
    [MemoryDiagnoser]
    public class _04MedianofTwoSortedArrays
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int i = 0;
            int j = 0;

            int count = 0;
            int current = 0;
            int prev = 0;
            while( count <= (nums1.Length + nums2.Length)/2 )
            {
                prev = current;
                if( i < nums1.Length && j < nums2.Length)
                {
                    if (nums1[i] > nums2[j])
                    {
                        current = nums2[j];
                        j++;
                    }
                    else
                    {
                        current = nums1[i];
                        i++;
                    }
                }
                else if ( j < nums2.Length)
                {                
                    current = nums2[j];
                    j++;
                }
                else if( i < nums1.Length)
                {
                    current = nums1[i];
                    i++;
                }
                count ++;
            }

            if ((nums1.Length + nums2.Length) % 2 == 0)
                return (current + prev) / 2.0;
            
            return current;
        }

        //[Benchmark]
        //public int[] Case2() => AddTwoNumbers(new[] { 4, 2, 7, 11, 15 }, 36);
    }
}
