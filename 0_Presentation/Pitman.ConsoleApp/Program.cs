using Framework.DistributedService;
using Pitman.DistributedService;
using System;
using System.Threading;

namespace Pitman.ConsoleApp
{
    class Program
    {
        private static Mutex mutex;

        private static DistributedHostManager serviceManager;

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
                serviceManager = new DistributedHostManager();
                serviceManager.Initialize();
                serviceManager.HostStatusReportEvent += ServiceManager_HostStatusReportEvent;
                serviceManager.OpenAllService();

                while (true)
                {
                    if(Console.ReadLine().ToLower() == "exit")
                    {
                        break;
                    }
                }
            }
        }

        private static void ServiceManager_HostStatusReportEvent(object sender, HostStatusReportEventArgs e)
        {
            Console.SetCursorPosition(0, 3);
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------");
            foreach(var item in e.Items)
            {
                Console.WriteLine("{0}          {1}         {2}", item.HostName.PadRight(20, ' '), item.HostStatus, item.Time.ToString("HH:mm:ss"));
            }
            Console.WriteLine();
        }
    }
}
