using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BakkBenchmark.DotNet
{
    public static class Sequencer
    {
        public static IList<double> SequenceMatch(IList<string> seq)
        {
            var n = seq.Count;
            var list = new double[n];

            //var regex = new Regex("tta|ttg|ctt|ctc|cta|ctg", RegexOptions.Compiled);

            for (int i = 0; i < n; i++)
            {
                //var matches = regex.Matches(seq[j]);

                var gen = seq[i];
                list[i] = 1.0;

                for (int j = 0; j < gen.Length - 3; j++) {
                    var s = gen.Substring(j, 3);

                    switch (s)
                    {
                        case "tta":
                            list[i] *= 1.2345;
                            break;
                        case "ttg":
                            list[i] *= 0.9485;
                            break;
                        case "ctt":
                            list[i] *= 1.9323;
                            break;
                        case "ctc":
                            list[i] *= 1.0033;
                            break;
                        case "cta":
                            list[i] *= 0.9999;
                            break;
                        case "ctg":
                            list[i] *= 0.8242;
                            break;
                    }
                }

                /*foreach (var match in matches)
                {
                    switch (match.ToString())
                    {
                        case "tta":
                            list[i] *= 1.2345;
                            break;
                        case "ttg":
                            list[i] *= 0.9485;
                            break;
                        case "ctt":
                            list[i] *= 1.9323;
                            break;
                        case "ctc":
                            list[i] *= 1.0033;
                            break;
                        case "cta":
                            list[i] *= 0.9999;
                            break;
                        case "ctg":
                            list[i] *= 0.8242;
                            break;
                    }
                }*/
            }

            return list;
        }
    }
}