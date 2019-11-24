using System;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lab16
{

    class Program
    {
        public static void DisplayFor()
        {
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 999; i++)
            {
                ParallelMy.CreateArray(i);
            }
            sw.Stop();
            Console.WriteLine("Simple for. Milliseconds: " + sw.ElapsedMilliseconds + '\n');
            sw.Restart();
            Parallel.For(0, 999, ParallelMy.CreateArray);
            sw.Stop();
            Console.WriteLine("Parallel for. Milliseconds: " + sw.ElapsedMilliseconds + '\n');
        }

        public static void DisplayForEach()
        {
            var sw = new Stopwatch();

            List<int> tempList = new List<int>() { 1, 3, 5, 7, 9, 11, 13, 15 };

            for (int i = 0; i < 999; i++)
            {
                tempList.Add(i);
            }

            sw.Restart();
            foreach (int numb in tempList)
            {
                ParallelMy.Sum(numb);
            }
            sw.Stop();
            Console.WriteLine("Simple foreach. Milliseconds: " + sw.ElapsedMilliseconds + '\n');

            sw.Restart();
            ParallelLoopResult result = Parallel.ForEach<int>(tempList, ParallelMy.Sum);
            sw.Stop();
            Console.WriteLine("Parallel foreach. Milliseconds: " + sw.ElapsedMilliseconds + '\n');
        }

        public static async void Task8(string path, string info)
        {
            Console.WriteLine("Is it realy async?");
            await Task.Run(() =>
            {
                long x = long.MaxValue;
                while (x > 0)
                {
                    x /= 10;
                    info += Convert.ToString(x, 2);
                }
                for (int i = 0; i < 10; i++)
                    info += info;
            });
            await Task.Run(() => FileManager.WriteToFile(path, info));
            string outstr = await Task.Run(() => FileManager.ReadFromFile(path));

            Console.WriteLine("It was realy async");

            Console.WriteLine(outstr);
        }

        static void Main(string[] args)
        {
            ////Task task1 = new Task(() => Console.WriteLine("Task1 is executed"));
            ////task1.Start();

            ////Task task2 = Task.Factory.StartNew(() => Console.WriteLine("Task2 is executed"));

            ////Task task3 = Task.Run(() => Console.WriteLine("Task3 is executed"));

            //Matrix matrix1 = new Matrix(4, 2);
            //Matrix matrix2 = new Matrix(2, 2);
            //Matrix matrix3 = null;
            //var sw = new Stopwatch();
            //long maxTicks = long.MinValue;
            //long minTicks = long.MaxValue;

            //matrix1.PrintMatrix();
            //matrix2.PrintMatrix();

            //CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            //CancellationToken token = cancelTokenSource.Token;

            //Task task4 = new Task(() => MatrixOperations.Multiplication(matrix1, matrix2,ref matrix3,token));

            ////Matrix matrix3 = MatrixOperations.Multiplication(matrix1, matrix2);
            ////Console.WriteLine("Task 4  id: " + task4.Id + ";  status: " + task4.Status);
            ////task4.Start();
            ////Console.WriteLine("Task 4  id: " + task4.Id + ";  status: " + task4.Status);
            ////task4.Wait();
            ////Console.WriteLine("Task 4  id: " + task4.Id + ";  status: " + task4.Status+'\n');
            ////matrix3.PrintMatrix();


            //for (int i = 0; i < 10; i++)
            //{
            //    sw.Start();
            //    task4 = new Task(() => MatrixOperations.Multiplication(matrix1, matrix2, ref matrix3,token));
            //    matrix1 = new Matrix(100, 100);
            //    matrix2 = new Matrix(100, 400);
            //    matrix3 = null;
            //    //cancelTokenSource.Cancel();//2task
            //    task4.Start();
            //    task4.Wait();
            //    sw.Stop();
            //    if (sw.ElapsedTicks > maxTicks) maxTicks = sw.ElapsedTicks;
            //    if (sw.ElapsedTicks < minTicks) minTicks = sw.ElapsedTicks;
            //}
            //Console.WriteLine($"Max ticks: {maxTicks}, Min ticks: {minTicks}, Different: {maxTicks-minTicks}");
            //-----------------------------------------------------------------------------------------------
            //              1             2 ^^

            //Task<int> task1 = new Task<int>(() => Formuls.formula1(140,-500,612));
            //Task<int> task2 = new Task<int>(() => Formuls.formula2(3432,3245,16));
            //Task<int> task3 = new Task<int>(() => Formuls.formula3(344,-54,677));

            //Task taskDisplay = task1.ContinueWith(res => Formuls.Display(task1.Result));
            //task1.Start();
            //taskDisplay.Wait();

            //taskDisplay = task2.ContinueWith(res => Formuls.Display(task2.Result));
            //task2.Start();
            //taskDisplay.Wait();

            //taskDisplay = task3.ContinueWith(res => Formuls.Display(task3.Result));
            //task3.Start();
            //taskDisplay.Wait();

            //task1.Start();
            //var awaiterForTask1 = task1.GetAwaiter();
            //awaiterForTask1.OnCompleted(() => { int res = awaiterForTask1.GetResult(); Formuls.Display(res); });
            //task1.Wait();
            //////-----------------------------------------------------------------------------------------------
            //////                    3             4 ^^

            //Parallel.Invoke(DisplayFor,DisplayForEach);
            //////-----------------------------------------------------------------------------------------------
            //////                  5          6         ^^
            //////-----------------------------------------------------------------------------------------------

            //EmulatorOfStore emulatorOfStore = new EmulatorOfStore();
            //emulatorOfStore.Start();
            //////                  7      ^^
            //////-----------------------------------------------------------------------------------------------

            Task8("file.txt", "1");

            //////                  8      ^^
            //////-----------------------------------------------------------------------------------------------

            Console.ReadLine();
        }
    }
}
