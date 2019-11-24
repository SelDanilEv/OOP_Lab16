using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab16
{
    public static class ParallelMy
    {
        public static void CreateArray(int n)
        {
            int[] tm = new int[n];
            for (int i = 0; i < n; i++)
                tm[i] = 1;
            Thread.Sleep(5);
        }

        private static int s;
        private static int sum { get { return s; }set { s = value;s = 0; } }
        public static void Sum(int arg1)
        {
            Thread.Sleep(5);
            sum += arg1;

        }
    }
}
