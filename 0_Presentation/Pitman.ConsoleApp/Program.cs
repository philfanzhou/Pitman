using System;
using System.Diagnostics;

namespace Pitman.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("");
            Console.WriteLine("=================================");

            if (Process.GetProcessesByName("Pitman.ConsoleApp").Length > 1)
            {
                Console.WriteLine("Pitman.ConsoleApp is already running");
                Console.WriteLine("Press any key to exit....");
                Console.Read();
            }
            else
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
                Console.WriteLine("service start sucessfully.");
                Console.Read();
            }
        }
    }
}
