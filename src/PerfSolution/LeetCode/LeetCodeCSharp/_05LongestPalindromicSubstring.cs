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
    public class _05LongestPalindromicSubstring
    {
        public string LongestPalindrome(string s)
        {
            var str = s.AsSpan();
            for (int length = str.Length; length >= 1; length--)
            {
                for (int i = 0; i + length <= str.Length; i++)
                {
                    int start = i;
                    int end = i + length - 1;

                    while (start <= end)
                    {
                        if (str[start] != str[end])
                            break;

                        start++;
                        end--;
                    }

                    if (start >= end)
                        return s.Substring(i, length);
                }
            }

            return null;
        }

        //[Benchmark]
        //public int[] Case2() => AddTwoNumbers(new[] { 4, 2, 7, 11, 15 }, 36);
    }
}
