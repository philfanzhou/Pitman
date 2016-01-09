using Pitman.Distributed.WebApi;
using System;
using System.Threading;

namespace Pitman.ConsoleApp
{
    class Program
    {
        private static Mutex mutex;
        
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("=================================");
            Console.WriteLine("Pitman.ConsoleApp");
            Console.WriteLine("=================================");

            mutex = new Mutex(true, "Pitman.OnlyRun");
            if (!mutex.WaitOne(0, false))
            {
                Console.WriteLine("Pitman.ConsoleApp is already running");
                Console.WriteLine("Press any key to exit....");
                Console.ReadKey();
            }
            else
            {
                WebApiServer server = new WebApiServer();
                server.Open(9999);

                while (true)
                {
                    if(Console.ReadLine().ToLower() == "exit")
                    {
                        break;
                    }
                }
            }
        }
    }
}
