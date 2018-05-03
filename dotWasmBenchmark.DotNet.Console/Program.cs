using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Linq;
using BakkBenchmark.DotNet;

class Program
{
    static void Main(string[] args)
    {
        int n = args?.Length > 0 ? Int32.Parse(args[0]) : 5_000_000;
        Benchmark.StartAndPrint(n);

        /*var results = new List<BenchmarkResult>();
        for (int i = 10_000; i <= 10_000_000; i += (int)Math.Pow(10, (int)Math.Log10(i))) {
            Console.Write(i + ";");
            results.Add(Benchmark.Start(i));
        }
        Console.WriteLine();

        foreach (var entry in results.Select(x => x.Generate)) {
            Console.Write(entry + ";");
        }
        Console.WriteLine();

        foreach (var entry in results.Select(x => x.Sort)) {
            Console.Write(entry + ";");
        }
        Console.WriteLine();

        foreach (var entry in results.Select(x => x.Calculate)) {
            Console.Write(entry + ";");
        }
        Console.WriteLine();*/
    }
}