using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnderstandingTaskApplication
{
    class UnderstandingAsync
    {
        public async void CallMethods()
        {
            Task<int> task = Method1();
            Method2();
            int value = await task;
            Method3(value);
        }

        private void Method3(int value)
        {
            Console.WriteLine("The reult is "+value);
        }

        private void Method2()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine(i);
            }
        }

        private async Task<int> Method1()
        {
            int result = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(100);
                    result += result + new Random().Next(10, 100);
                }
            });
            
            return result;
        }

    }
}
