using System;
using System.Collections.Generic;
using System.Text;

namespace Lab16
{
    public static class Formuls
    {
        public static int formula1(int first, int second, int third) => (first + second) % third - second * third + first;
        public static int formula2(int first, int second, int third) => (first + second) / third - second % third + first / 2;
        public static int formula3(int first, int second, int third) => (first + third - second) * third % 12 + first * 2;
        public static void Display(int result)
        {
            Console.WriteLine($"Result: {result}");
        }
    }
}
