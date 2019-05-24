using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Øvelse_0
{
    // Some class with some work method that will run in its own thread.
    class Program
    {

        /*
         * Worker method that will run apart from the main thread.
         */
        public void WorkThreadFunction()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"[{Thread.CurrentThread.Name}] Doing some work...");
                TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
                int secondsSinceEpoch = (int) t.TotalSeconds;
                Thread.Sleep(new Random(secondsSinceEpoch).Next(0, 250));
            }
        }
    }

    class ThreadProg
    {

        // Program Entrypoint
        public static void Main()
        {
            
            Program pg = new Program();

            // Make a new thread pointing to the new program instance methods' entrypoint.
            Thread thread = new Thread(new ThreadStart(pg.WorkThreadFunction));
            Thread thread2 = new Thread(new ThreadStart(pg.WorkThreadFunction));
            thread.Name = "worker_thread_1";
            thread2.Name = "worker_thread_2";

            // Start the worker threads.
            thread.Start();
            thread2.Start();

            // Make calling Thread (Main UI Thread) join our two Worker Threads.
            thread.Join();
            thread2.Join();

            // Block Console from exiting.
            Console.Read();

        }
    }
}
