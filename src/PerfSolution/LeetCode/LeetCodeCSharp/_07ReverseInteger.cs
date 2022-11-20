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
    public class _07ReverseInteger
    {
        public int ReverseInteger(int x)
        {
            long result = 0;
            while (x != 0)
            {
                result = result * 10 + x % 10;
                x = x / 10;
            }

            if (result > int.MaxValue || result < int.MinValue)
                return 0;

            return (int)result;
        }

        //[Benchmark]
        //public int[] Case2() => AddTwoNumbers(new[] { 4, 2, 7, 11, 15 }, 36);
    }
}
