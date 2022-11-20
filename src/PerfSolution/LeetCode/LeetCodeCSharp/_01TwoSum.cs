using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace LeetCodeCSharp
{
    /// <summary>
    /// https://leetcode.cn/problems/two-sum/
    /// 
    /// </summary>
    [SimpleJob(RuntimeMoniker.Net70)]
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [SimpleJob(RuntimeMoniker.NativeAot70)]
    [MemoryDiagnoser]
    public class _01TwoSum
    {
        /// <summary>
        /// 执行用时：152 ms, 在所有 C# 提交中击败了61.99%的用户
        /// 内存消耗：43.1 MB, 在所有 C# 提交中击败了73.64%的用户
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            var ret = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                ret[0] = i;
                for (int j = i + 1; j < nums.Length; j++)
                    if (nums[j] == target - nums[i])
                    {
                        ret[1] = j;
                        return ret;
                    }
            }

            ret[0] = 0;
            ret[1] = 0;
            return ret;
        }


        public int[] TwoSumDic(int[] nums, int target)
        {
            var dic = new Dictionary<int, int>(nums.Length);
            for (int i = 0; i < nums.Length; i++)
            {
                var num1 = nums[i];
                var num2 = target - num1;

                int index;
                if (dic.TryGetValue(num2, out index))
                    return new[] { index, i };

                dic[num1] = i;
            }

            return null;
        }

        public int[] TwoSumVector(int[] nums, int target)
        {
            Vector<int> v = new Vector<int>(nums);

            var ret = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                ret[0] = i;
                for (int j = i + 1; j < nums.Length; j++)
                    if (v[j] == target - v[i])
                    {
                        ret[1] = j;
                        return ret;
                    }
            }

            ret[0] = 0;
            ret[1] = 0;
            return ret;
        }



        [Benchmark]
        public int[] TwoSum() => TwoSum( new[] { 4, 2, 7, 11, 15 }, 36);

        public int[] Case2() => TwoSumVector(new[] { 4, 2, 7, 11, 15 }, 36);

        [Benchmark]
        public int[] TwoSumDic() => TwoSumDic(new[] { 4, 2, 7, 11, 15 }, 36);
    }
}
