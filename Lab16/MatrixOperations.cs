using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab16
{
    public static class MatrixOperations
    {
        public static Matrix Multiplication(Matrix one,Matrix two,ref Matrix result, CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Операция прервана токеном");
                return null;
            }
            result = new Matrix(one.getParameters()[0],two.getParameters()[1]);
            int[,] a = one.matrix;
            int[,] b = two.matrix;
            if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Unreal operation(myltiply)");
            int[,] r = new int[a.GetLength(0), b.GetLength(1)];
            Parallel.For(0, a.GetLength(0), (i) =>
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            });
            result.matrix = r;
            return result;
        }
    }
}
