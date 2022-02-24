using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnderstandingTaskApplication
{
    class UnderstandingTask
    {
        void PrintTillAnotherNumber()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " " + i);
                Thread.Sleep(1000);
            }
        }
        int SampleGiveNumber()
        {
            Thread.Sleep(1000);
            return new Random().Next(100, 200);
        }
        public void UnderstandTaskBasic()
        {
            Task t = new Task(PrintTillAnotherNumber);
            t.Start();
            Task t1 = new Task(PrintTillAnotherNumber);
            t1.Start();
            //PrintTillAnotherNumber();
            Console.WriteLine("after the second print-direct");
        }
        public void UnderstandingWait()
        {
            Task t = new Task(PrintTillAnotherNumber);
            t.Start();
            //Task<int> t1 = Task.Run(SampleGiveNumber);
            //var muNumber = t1.Result;
            Task<int> t1 = Task.Run(()=>
            {
                Thread.Sleep(1000);
                return new Random().Next(100, 200);
            });
            var muNumber = t1.Result;
            //var muNumber = SampleGiveNumber();
            t.Wait();
            Console.WriteLine("THe number is "+muNumber);
        }
    }
}
