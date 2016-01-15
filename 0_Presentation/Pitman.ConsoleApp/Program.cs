using Pitman.Application.DataCollection;
using Pitman.Distributed.WebApi;
using System;
using System.Threading;

namespace Pitman.ConsoleApp
{
    class Program
    {
        #region Field
        private static Mutex mutex = new Mutex(true, "Pitman.OnlyRun");

        private static WebApiServer _webApiServer;
        private static int _webApiPort = 9999;

        private static ServiceManager _collectionServiceManager;
        #endregion

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
            // 启动数据收集服务
            _collectionServiceManager = new ServiceManager();
            _collectionServiceManager.StartService();
            Console.WriteLine("Collection Service is started...");

            // 启动WebApi
            _webApiServer = new WebApiServer(_webApiPort);
            if(_webApiServer.Open())
            {
                Console.WriteLine(string.Format("WebApi is listening at {0}", _webApiServer.BasicAddress));
            }
        }
    }
}
