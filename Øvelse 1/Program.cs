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

            t.Start();

            t.Join();

            Console.ReadLine();





        }
    }
}
