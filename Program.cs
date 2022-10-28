using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimingClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Timing tObj = new Timing();
            int[] nums = new int[100000];
            DateTime startTimeDT; //wrong measurement code
            TimeSpan endTimeDT; //wrong measurement code

            BuildArray(nums);

            startTimeDT = DateTime.Now; //wrong measurement code
            tObj.StartTime();
            DisplayNums(nums);
            tObj.StopTime();
            endTimeDT = DateTime.Now.Subtract(startTimeDT); //wrong measurement code

            Console.WriteLine($"\nTime (.NET): {tObj.Duration()}");
            Console.WriteLine($"Time by DateTime (see the difference :)) ): {endTimeDT}"); //wrong measurement code
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
    public class Timing
    {
        TimeSpan startingTime;
        TimeSpan duration;

        public Timing()
        {
            startingTime = new TimeSpan(0);
            duration = new TimeSpan(0);
        }
        public void StartTime()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            startingTime = Process.GetCurrentProcess().Threads[0].UserProcessorTime;
        }
        public void StopTime()
        {
            duration = Process.GetCurrentProcess().Threads[0].UserProcessorTime.Subtract(startingTime);
            //duration = Process.GetCurrentProcess().Threads[0].UserProcessorTime - startingTime;
        }
        public TimeSpan Duration()
        {
            return duration;
        }
    }
}
