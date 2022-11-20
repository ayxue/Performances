using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;

namespace LeetCodeCSharp
{
    [MemoryDiagnoser]
    public class _09IsPalindrome
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0)
                return false;

            int val = x;
            long reversed = 0;
            while (val > 0)
            {
                reversed = reversed * 10 + val % 10;
                val = val / 10;
            }

            return reversed == x;
        }



        //[Benchmark]
        //public int[] Case2() => AddTwoNumbers(new[] { 4, 2, 7, 11, 15 }, 36);
    }
}
