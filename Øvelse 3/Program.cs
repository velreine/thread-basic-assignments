using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Øvelse_3
{
    class Program
    {
        private static int heatLimitHitCounter = 0;
        private static object heatLimitLockObj = new object();


        static void Main(string[] args)
        {



            Thread t = new Thread(() =>
            {
                TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1);
                var timeSinceEpoch = (int)ts.TotalSeconds;
                Random rnd = new Random(timeSinceEpoch);


                while (true)
                {
                    
                    int temperatureGenerated = rnd.Next(-20, 120);
                    Console.WriteLine($"Temperatur generet er: {temperatureGenerated}");

                    if (temperatureGenerated > 100 || temperatureGenerated < 0)
                    {
                        Console.WriteLine("Temperature is outside of allowed bounds: 0 degrees to 100 degrees!");
                        
                        try
                        {
                            Monitor.Enter(heatLimitLockObj);
                            heatLimitHitCounter++;

                            // Break out of while loop if limit hit too many times.
                            if(heatLimitHitCounter >= 3) break;

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            Monitor.Exit(heatLimitLockObj);
                        }


                    }

                    Thread.Sleep(750);

                }
            });

            t.Start();

            while (true)
            {

                try
                {
                    if (Monitor.TryEnter(heatLimitLockObj, 3000))
                    {

                        if (heatLimitHitCounter >= 3) break;

                    }
                    else
                    {
                        Console.WriteLine("Timeout for tilgangen til heatLimitLockObj nået (3sekunder)");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Monitor.Exit(heatLimitLockObj);
                }


            }

            Thread.Sleep(10000);

            Console.WriteLine("Genereret fejlagtigt temperatur 3 gange eller over programmet er stoppet.");
            Console.ReadLine();

        }
    }
}
