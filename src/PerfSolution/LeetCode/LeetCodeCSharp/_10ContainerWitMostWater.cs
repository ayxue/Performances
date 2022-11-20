using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;

namespace LeetCodeCSharp
{
    [MemoryDiagnoser]
    public class _10ContainerWitMostWater
    {
        static readonly int[] Case01Parameter;

        static _10ContainerWitMostWater()
        {
            using (var reader = new StreamReader( Assembly.GetExecutingAssembly().
                                                    GetManifestResourceStream("LeetCodeCSharp.10Case01.json")))
            {
                Case01Parameter = JsonConvert.DeserializeObject<int[]>(reader.ReadToEnd());
            }
        }

        public int MaxArea(int[] height)
        {
            int maxArea = 0;
            int i = 0;
            int j = height.Length - 1;

            while (i < j)
            {
                maxArea = Math.Max(maxArea, Math.Min(height[i], height[j]) * (j - i));
                if (height[i] < height[j])
                    i++;
                else
                    j--;
            }

            return maxArea;
        }


        public int MaxAreaFast(int[] height)
        {
            int maxArea = 0;
            int i = 0;
            int j = height.Length - 1;

            var arrayData = Unsafe.As<RawArrayData>(height);
            ref var arrayHead = ref arrayData.Data;

            while (i < j)
            {
                var heightI = GetItem(ref arrayData.Data, i);
                var heightJ = GetItem(ref arrayData.Data, j);

                maxArea = Math.Max(maxArea, Math.Min(height[i], height[j]) * (j - i));
                if (height[i] < height[j])
                    i++;
                else
                    j--;
            }

            return maxArea;
        }


        public ref T GetItem<T>(ref T array, int index)
        {
            return ref Unsafe.Add(ref array, index);
        }


        private sealed class RawArrayData
        {
            public IntPtr Length;
            public byte Data;
        }


        [Benchmark]
        public int Case01() => MaxArea(Case01Parameter);

        [Benchmark]
        public int Case02NoBoundCheck() => MaxAreaFast(Case01Parameter);
    }
}
