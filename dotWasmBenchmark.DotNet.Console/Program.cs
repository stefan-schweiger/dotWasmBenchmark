using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using BakkBenchmark.DotNet;

class Program
{
    public static void Main(string[] args) {
        int n = args?.Length > 0 ? Int32.Parse(args[0]) : 100000;

        Benchmark.Start(n);
    }
}