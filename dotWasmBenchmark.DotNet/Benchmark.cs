using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BakkBenchmark.DotNet
{
    public static class Benchmark
    {
        public static BenchmarkResult Start(int n = 1000, int length = 500)
        {
            var result = new BenchmarkResult();

            var stopWatch = new Stopwatch();

            stopWatch.Start();
            // for now skip the DNAGenerator and just use a random double list
            //var seq = DNAGenerator.Generate(n, length);
            var list = new double[n];
            var rand = new Random();

            for (int i = 0; i < n; i++) {
                list[i] = rand.NextDouble();
            }
            stopWatch.Stop();

            result.Generate = stopWatch.Elapsed.TotalMilliseconds;

            

            // deactivate with DNAGenerator
            /*stopWatch.Restart();
            var list = Sequencer.SequenceMatch(seq);
            stopWatch.Stop();

            Console.WriteLine($"Match: {stopWatch.ElapsedMilliseconds}ms");*/

            stopWatch.Restart();
            Sort.QuickSort(list);
            stopWatch.Stop();

            result.Sort = stopWatch.Elapsed.TotalMilliseconds;

            stopWatch.Restart();
            var res = Calc.Calculate(list);
            stopWatch.Stop();

            result.Calculate = stopWatch.Elapsed.TotalMilliseconds;
            result.CalculationResult = res;

            return result;
        }

        public static void StartAndPrint(int n = 1000, int length = 500) {
            var result = Start(n, length);
            Console.WriteLine($"Generate:  {result.Generate:N2}ms");
            Console.WriteLine($"Sort:      {result.Sort:N2}ms");
            Console.WriteLine($"Calculate: {result.Calculate:N2}ms");

            Console.WriteLine("----------------------------------------------");

            Console.WriteLine($"Q1     {result.CalculationResult.Q1:N3}");
            Console.WriteLine($"Median {result.CalculationResult.Median:N3}");
            Console.WriteLine($"Q3     {result.CalculationResult.Q3:N3}");
            Console.WriteLine($"Avg.   {result.CalculationResult.Avg:N3}");
            Console.WriteLine($"StDev  {result.CalculationResult.StDev:N3}");
        }
    }

    public struct BenchmarkResult {
        public double Generate { get; set; }
        public double Sort { get; set; }
        public double Calculate { get; set; }
        public StatResult CalculationResult { get; set; }
    }
}
