using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeCSharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(ArrayTest));
            //var test = new ArrayTest();

            //test.SumCpp(new[] { 1,2,3});
        }
    }
}
