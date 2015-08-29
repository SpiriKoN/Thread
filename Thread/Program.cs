using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Thread1
{
    class Program
    {
        private static long totalSum = 0;
        private static int[,] arr = new int[10, 10];
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[,] arr = new int[10,10];

            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    arr[i, j] = rnd.Next(1, 100);
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Thread t = new Thread(Sum);
            t.Start(arr);
            while (t.IsAlive)
            {
                Thread.Sleep(100);
            }
            
            
            Console.WriteLine("\nTotal Sum = {0}", totalSum);
        }

        private static void Sum(object obj)
        {
            int[,] n = (int[,])obj;
            long s = 0;

            for (int i = 0; i < 10; ++i)
            {
                int[] m = n.Cast<int>().ToArray();
                s += i;
                Thread c = new Thread(SumCol);
                c.Start(m);
                Thread.Sleep(1);
            }
            
        }
        private static void SumCol(object obj)
        {
            int[] n = (int[])obj;
            int sum = 0;

            for (int i = 0; i < n.Length; ++i)
            {
                sum += n[i];
            }
            totalSum = sum;
            Console.WriteLine("Sum: {0}", sum);
        }
    }
}
