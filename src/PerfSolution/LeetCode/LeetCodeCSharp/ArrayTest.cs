using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace LeetCodeCSharp
{
    [MemoryDiagnoser]
    public class ArrayTest
    {
        public static readonly int[] Case01Parameter;
        public static readonly int[] Case02Parameter = new int[] { 1, 3, 5 , 8, 5, 9, 2, 4, 5, 6 };

        private static readonly IntPtr _dll;
        private static readonly CppDelegate _sumArrayTest;

        static ArrayTest()
        {
            using (var reader = new StreamReader( Assembly.GetExecutingAssembly().
                                                    GetManifestResourceStream("LeetCodeCSharp.10Case01.json")))
            {
                Case01Parameter = JsonConvert.DeserializeObject<int[]>(reader.ReadToEnd());
            }

            var loader = new WindowsDllLoader();
            _dll = loader.LoadDll(@"D:\Projects\Github\Ray\Performances\src\PerfSolution\x64\Debug\LeetCpp.dll");
            _sumArrayTest = loader.LoadFunction<CppDelegate>(_dll, "SumArrayTest");
        }

        public long Sum(int[] height)
        {
            long sum = 0;
            for (int i = 0; i < height.Length; i++)
                sum += height[i];

            return sum;
        }


        public long SumUnsafePointer(int[] height)
        {
            long sum = 0;

            unsafe 
            { 
                var p1 = (int*)Unsafe.AsPointer(ref height[0]);
                var last = (int*)Unsafe.AsPointer(ref height[height.Length - 1]);

                do
                {
                    sum = sum + *p1;
                    p1 = p1 + 1;
                }
                while (p1 <= last);
            }

            return sum;
        }


        public long SumMarshalIntPtr(int[] height)
        {
            long sum = 0;

            unsafe
            {
                var p1 = new IntPtr(Unsafe.AsPointer(ref height[0]));
                var last = new IntPtr(Unsafe.AsPointer(ref height[height.Length - 1]));

                do
                {
                    sum = sum + Marshal.ReadInt32(p1);
                    p1 = p1 + sizeof(int);
                }
                while (((long)p1) <= ((long)last));
            }

            return sum;
        }


        public unsafe long SumCpp(int[] height)
        {
            var p1 = (int*)Unsafe.AsPointer(ref height[0]);
            long sum = _sumArrayTest(p1, height.Length);        

            return sum;
        }


        public unsafe delegate long CppDelegate(int* height, int size);


        public long SumLinq(int[] height)
        { 
            return height.Sum();
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
        public long Case01NormalSum() => Sum(Case02Parameter);

        [Benchmark]
        public long Case02LinqSum() => SumLinq(Case02Parameter);

        [Benchmark]
        public long Case03Cpp() => SumCpp(Case02Parameter);

        [Benchmark]
        public long Case04UnsafePointer() => SumUnsafePointer(Case02Parameter);

        [Benchmark]
        public long Case05MarshalIntPtr() => SumMarshalIntPtr(Case02Parameter);

    }
}
