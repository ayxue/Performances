using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;

namespace LeetCodeCSharp
{
    [MemoryDiagnoser]
    public class _08StringToInteger
    {
        public int MyAtoi(string s)
        {
            long result = 0;
            int sign = 1;

            bool allowSpace = true;
            bool allowSign = true;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ' && allowSpace)
                    continue;
                else if ((s[i] == '+' || s[i] == '-') && allowSign)
                {
                    allowSpace = false;
                    allowSign = false;
                    sign = (s[i] == '-' ? -1 : 1);
                    continue;
                }

                int val = s[i] - '0';
                if (val < 0 || val > 10)
                    break;

                allowSpace = false;
                allowSign = false;
                result = result * 10 + val;
                if (sign * result > int.MaxValue)
                    return int.MaxValue;

                if (sign * result < int.MinValue)
                    return int.MinValue;
            }

            result = sign * result;
            return (int)result;
        }



        //[Benchmark]
        //public int[] Case2() => AddTwoNumbers(new[] { 4, 2, 7, 11, 15 }, 36);
    }
}
