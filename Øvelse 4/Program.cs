using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Øvelse_4
{
    class Program
    {
        private static char ch = '*';

        static void Main(string[] args)
        {

            Thread t = new Thread(() =>
            {
                while (true)
                {
                    char ch = '*';
                    Console.Write(ch);
                    Thread.Sleep(150);
                }
            });

            Thread t2 = new Thread(() =>
            {
                while (true)
                {
                    ch = Console.ReadKey().KeyChar;
                }
            });

            t.Start();
            t2.Start();

            t.Join();
            t2.Join();

            Console.WriteLine("Press enter to close!");
            Console.ReadLine();


        }
    }
}
