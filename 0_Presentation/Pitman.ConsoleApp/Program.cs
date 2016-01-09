using Framework.DistributedService;
using Pitman.WebApi;
using System;
using System.Reflection;
using System.Threading;
using System.Web.Http.SelfHost;

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
                //serviceManager = new DistributedHostManager();
                //serviceManager.Initialize();
                //serviceManager.HostStatusReportEvent += ServiceManager_HostStatusReportEvent;
                //serviceManager.OpenAllService();

                Assembly.Load("Pitman.WebApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken = null");
                var configuration = new HttpSelfHostConfiguration("http://localhost:9999");
                var httpServer = new HttpSelfHostServer(configuration);

                RouteConfig.Register(httpServer.Configuration);

                httpServer.OpenAsync();

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
