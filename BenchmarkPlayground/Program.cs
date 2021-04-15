using BenchmarkDotNet.Running;
using System;

namespace BenchmarkPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmarks>();
        }
    }
}
