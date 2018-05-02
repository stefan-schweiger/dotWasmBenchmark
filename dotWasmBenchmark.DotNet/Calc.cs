using System;
using System.Linq;
using System.Collections.Generic;

namespace BakkBenchmark.DotNet
{
    public static class Calc
    {
        public static StatResult Calculate(IList<double> list)
        {
            var q1 = list[list.Count / 4];
            var median = list[list.Count / 2];
            var q3 = list[list.Count / 4 * 3];

            var avg = list.Average();
            var stDevSum = list.Sum(d => (d - avg) * (d - avg));
            var stDev = Math.Sqrt(stDevSum / list.Count);

            return new StatResult() {
                Q1 = q1,
                Median = median,
                Q3 = q3,
                Avg = avg,
                StDev = stDev
            };
        }
    }

    public struct StatResult {
        public double Q1 { get; set; }
        public double Median { get; set; }
        public double Q3 { get; set; }
        public double Avg { get; set; }
        public double StDev { get; set; }
    }
}