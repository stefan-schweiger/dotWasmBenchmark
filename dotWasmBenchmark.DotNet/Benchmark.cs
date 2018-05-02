using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BakkBenchmark.DotNet
{
    public static class Benchmark
    {
        public static void Start(int n = 1000, int length = 500)
        {
            Console.WriteLine("Start");

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

            Console.WriteLine($"Generate:  {stopWatch.ElapsedMilliseconds}ms");

            // deactivate with DNAGenerator
            /*stopWatch.Restart();
            var list = Sequencer.SequenceMatch(seq);
            stopWatch.Stop();

            Console.WriteLine($"Match: {stopWatch.ElapsedMilliseconds}ms");*/

            stopWatch.Restart();
            Sort.QuickSort(list);
            stopWatch.Stop();
        
            Console.WriteLine($"Sort:      {stopWatch.ElapsedMilliseconds}ms");

            stopWatch.Restart();
            var res = Calc.Calculate(list);
            stopWatch.Stop();

            Console.WriteLine($"Calculate: {stopWatch.ElapsedMilliseconds}ms");

            Console.WriteLine("----------------------------------------------");

            Console.WriteLine($"Q1     {res.Q1}");
            Console.WriteLine($"Median {res.Median}");
            Console.WriteLine($"Q3     {res.Q3}");
            Console.WriteLine($"Avg.   {res.Avg}");
            Console.WriteLine($"StDev  {res.StDev}");
        }
    }
}
