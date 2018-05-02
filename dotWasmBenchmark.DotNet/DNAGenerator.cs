using System;
using System.Collections.Generic;
using System.Text;

namespace BakkBenchmark.DotNet
{
    public static class DNAGenerator
    {
        private const int IM = 139968;
        private const int IA = 3877;
        private const int IC = 29573;
        private static int seed = 42;

        private static Frequency[] frequencies = {
            new Frequency ('a', 0.3029549426680),
            new Frequency ('c', 0.1979883004921),
            new Frequency ('g', 0.1975473066391),
            new Frequency ('t', 0.3015094502008)
        };

        static DNAGenerator()
        {
            MakeCumulative(frequencies);
        }

        private static void MakeCumulative(Frequency[] a)
        {
            int cp = 0;
            for (int i = 0; i < a.Length; i++)
            {
                cp += a[i].p;
                a[i].p = cp;
            }
        }

        public static IList<string> Generate(int n, int length)
        {
            var res = new string[n];

            for (int i = 0; i < n; i++)
            {
                var sb = new StringBuilder(length);

                for (int j = 0; j < length; j++)
                {
                    sb.Append(GetRandomCode());
                }

                res[i] = sb.ToString();
            }

            return res;
        }

        private static char GetRandomCode()
        {
            var r = Random();

            /*for (int i = 0; i < frequencies.Length; i++)
            {
                if (r < frequencies[i].p)
                {
                    return frequencies[i].c;
                }
            }

            return frequencies[frequencies.Length - 1].c;*/

            if (r < 0.3 * IM) {
                return 'a';
            } else if (r < 0.5 * IM) {
                return 'c';
            } else if (r < 0.7 * IM) {
                return 'g';
            } else {
                return 't';
            }
        }


        private static int Random()
        {
            seed = (seed * IA + IC) % IM;
            return seed;
        }


        private struct Frequency
        {
            public readonly char c;
            public int p;

            public Frequency(char c, double p)
            {
                this.c = c;
                this.p = (int)(p * IM);
            }
        }
    }
}