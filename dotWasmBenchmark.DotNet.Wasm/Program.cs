using System;
using System.Collections.Generic;
using System.Diagnostics;
using BakkBenchmark.DotNet;

namespace BakkBenchmark.DotNet.Wasm
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = args?.Length > 0 ? Int32.Parse(args[0]) : 100000;

            Benchmark.Start(n);
        }
    }
}
