using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Øvelse_1
{
    class Program
    {
        static void Main(string[] args)
        {


            Thread t = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("C# trådning er nemt!");
                }
            })
            {
                Name = "worker_thread_1",
                Priority = ThreadPriority.Lowest
            };

            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Også med flere tråde!");
                }
            })
            {
                Name = "worker_thread_2",
                Priority = ThreadPriority.Highest
            };

            t.Start();
            t2.Start();

            t.Join();
            t2.Join();

            Console.ReadLine();





        }
    }
}
