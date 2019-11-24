using System;
using System.Collections.Generic;
using System.Text;

namespace Lab16
{
    public class Matrix
    {
        private int[,] _matrix;

        public int[,] matrix {get { return _matrix; } set { _matrix = value; } }

        private int _str;
        private int _col;

        private static Random random = new Random();

        public int[] getParameters()
        {
            int[] parametrs = new int[2];
            parametrs[0] = _str;
            parametrs[1] = _col;
            return parametrs;
        }

        public int getNumber(int s, int c) => _matrix[s, c];
        public void setNumber(int s, int c, int n) => _matrix[s, c] = n;

        public Matrix(int s, int c)
        {
            _matrix = new int[s, c];
            _str = s;
            _col = c;
            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    _matrix[i, j] = random.Next(-5, 5);
                }
            }
        }

        public Matrix()
        {
            _matrix = new int[5, 5];
            _str = 5;
            _col = 5;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    _matrix[i, j] = random.Next(-5, 5);
                }
            }
        }

        public void PrintMatrix()
        {
            string outstr = "";
            outstr += $"Print matrix {_str}x{_col}\n\n";
            for (int i = 0; i < _str; i++)
            {
                for (int j = 0; j < _col; j++)
                {
                    if (_matrix[i, j] < 0)
                        outstr += '\t' + _matrix[i, j].ToString() + '\t';
                    else
                        outstr += "\t " + _matrix[i, j].ToString() + '\t';
                }
                outstr += '\n';
            }
            Console.WriteLine(outstr);
        }
    }
}
