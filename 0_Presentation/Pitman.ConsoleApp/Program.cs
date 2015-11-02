using Pitman.DistributedService;
using System;
using System.Diagnostics;
using System.Threading;

namespace Pitman.ConsoleApp
{
    class Program
    {
        private static Mutex mutex;

        private static ServiceManager serviceManager;

        static void Main(string[] args)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("Pitman.ConsoleApp");
            Console.WriteLine("=================================");

            mutex = new Mutex(true, "OnlyRun");
            if (mutex.WaitOne(0, false))
            {
                //ServiceInitialize.Init();

                //var serviceManager =
                //    new ServiceManager(new List<object>
                //    {
                //        typeof (AuthenticationService),
                //        typeof (OAuth2AuthorizationServer),
                //        typeof (CrosscuttingService),
                //        typeof (FinanceDataService),
                //        typeof (PriceDataService)
                //    });
                //serviceManager.Open();

                serviceManager = new ServiceManager();
                serviceManager.OpenAllService();



                Console.WriteLine("service start sucessfully.");
                Console.Read();
            }
            else
            {
                Console.WriteLine("Pitman.ConsoleApp is already running");
                Console.WriteLine("Press any key to exit....");
                Console.Read();
            }
        }
    }
}
