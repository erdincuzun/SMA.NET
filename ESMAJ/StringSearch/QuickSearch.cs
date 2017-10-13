﻿using System.Collections.Generic;
using System.Diagnostics;

namespace ESMAJ.StringSearch
{    
    public class QuickSearch
    {
        public static double preProcessTime;
        public static double searchTime;

        public static int Search(string pattern, string source, int startIndex)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray(startIndex, source.Length - startIndex);
            int j, m = x.Length, n = y.Length;
            List<int> result = new List<int>();

            int[] qsBc = new int[65536];
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            PreQsBc(x, ref qsBc);
            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching */
            j = 0;
            while (j < n - m)
            {
                if (ArrayCmp(x, 0, y, j, m) == 0)
                {
                    stopwatch.Stop();
                    searchTime = stopwatch.Elapsed.TotalMilliseconds;
                    return j + startIndex;
                }
                j += qsBc[y[j + m]]; /* shift */
            }
            if (j == n - m && ArrayCmp(x, 0, y, j, m) == 0)
                result.Add(j);

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return -1;
        }

        public static List<int> Search(string pattern, string source)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray();
            int j, m = x.Length, n = y.Length;
            List<int> result = new List<int>();

            int[] qsBc = new int[65536];
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            PreQsBc(x, ref qsBc);
            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching */
            j = 0;
            while (j < n - m)
            {
                if (ArrayCmp(x, 0, y, j, m) == 0)
                    result.Add(j);
                j += qsBc[y[j + m]]; /* shift */
            }
            if (j == n - m && ArrayCmp(x, 0, y, j, m) == 0)
                result.Add(j);

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return result;
        }
        private static void PreQsBc(char[] x, ref int[] qsBc)
        {
            int i, m = x.Length;

            for (i = 0; i < qsBc.Length; ++i)
                qsBc[i] = m + 1;
            for (i = 0; i < m; ++i)
                qsBc[x[i]] = m - i;
        }

        private static int ArrayCmp(char[] a, int aIdx, char[] b, int bIdx, int Length)
        {
            int i = 0;

            for (i = 0; i < Length && aIdx + i < a.Length && bIdx + i < b.Length; i++)
            {
                if (a[aIdx + i] == b[bIdx + i])
                    ;
                else if (a[aIdx + i] > b[bIdx + i])
                    return 1;
                else
                    return 2;
            }

            if (i < Length)
                if (a.Length - aIdx == b.Length - bIdx)
                    return 0;
                else if (a.Length - aIdx > b.Length - bIdx)
                    return 1;
                else
                    return 2;
            else
                return 0;
        }        
    }
}
