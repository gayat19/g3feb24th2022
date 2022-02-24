using System;
using System.Threading;

namespace UnderstandingTaskApplication
{
    class Program
    {
        void PrintTillANumber()
        {
            lock (this)
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " " + i);
                    Thread.Sleep(1000);
                }
            }
        }
        void PrintTillAnotherNumber()
        {
            for (int i = 10; i < 100; i=i+10)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
        }

        static void Main(string[] args)
        {
            //Program program = new Program();
            //Thread t1 = new Thread(program.PrintTillANumber);
            //t1.Name = "You";
            //Thread t2 = new Thread(program.PrintTillANumber);
            //t2.Name = "Me";
            ////program.PrintTillANumber();
            ////program.PrintTillAnotherNumber();
            //t1.Start();
            //t2.Start();
            //UnderstandingTask ut = new UnderstandingTask();
            //ut.UnderstandingWait();
            UnderstandingAsync ua = new UnderstandingAsync();
            ua.CallMethods();
            Console.ReadKey();
        }
    }
}
