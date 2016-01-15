using Pitman.Distributed.WebApi;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Linq;

namespace Pitman.ConsoleApp
{
    class Program
    {
        private static Mutex mutex = new Mutex(true, "Pitman.OnlyRun");

        private static WebApiServer _webApiServer;
        private static int _webApiPort = 9999;

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            if (IsAlreadyRunning())
            {
                return;
            }

            Console.WriteLine("=================================");
            Console.WriteLine("Pitman.ConsoleApp");
            Console.WriteLine("=================================");

            try
            {
                StarService();
            }
            catch(Exception e)
            {
                Console.Write(e.ToString());
            }

            WaitingForExit();
        }

        private static bool IsAlreadyRunning()
        {
            if (!mutex.WaitOne(0, false))
            {
                Console.WriteLine("Pitman is already running, please don't run the application again.");
                Console.WriteLine("Press any key to exit....");
                Console.ReadKey();
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void WaitingForExit()
        {
            Console.WriteLine("\r\npress exit to close the application....");
            while (true)
            {
                if (Console.ReadLine().ToLower() == "exit")
                {
                    break;
                }
            }
        }

        private static void StarService()
        {
            _webApiServer = new WebApiServer(_webApiPort);
            if(_webApiServer.Open())
            {
                Console.WriteLine(string.Format("Service is listening at {0}", _webApiServer.BasicAddress));
            }
        }
    }
}
