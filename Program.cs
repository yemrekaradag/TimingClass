using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimingClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[100000];
            BuildArray(arr);
            DisplayNums(arr);
            Console.ReadLine();
        }
        static void BuildArray(int[] arr)
        {
            for (int i = 0; i < 100000; i++)
                arr[i] = i;
        }
        static void DisplayNums(int[] arr)
        {
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
                Console.Write(arr[i] + " ");

            //foreach (int i in arr)
            //{
            //    Console.WriteLine(i);
            //}
        }
    }
}
