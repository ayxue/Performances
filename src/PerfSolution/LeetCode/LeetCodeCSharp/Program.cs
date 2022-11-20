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
            var summary = BenchmarkRunner.Run(typeof(_01TwoSum));
            //var question = new _10ContainerWitMostWater();
            //var result = question.Case02NoBoundCheck();
        }
    }
}
