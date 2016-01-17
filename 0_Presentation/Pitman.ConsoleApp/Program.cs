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

        private static int _webApiPort = 9999;

        private static WebApiServer _webApiServer;
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
                Start();
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

        private static void Start()
        {
            // 启动数据收集服务
            _collectionServiceManager = new ServiceManager();
            _collectionServiceManager.StartService();
            CollectionServiceHandler.Manager = _collectionServiceManager;
            Console.WriteLine("Collection Service is started...");

            // 启动WebApi
            _webApiServer = new WebApiServer(_webApiPort);
            if(_webApiServer.Open())
            {
                Console.WriteLine(string.Format("WebApi is listening at {0}", _webApiServer.BasicAddress));
            }
            else
            {
                Console.WriteLine(string.Format("WebApi startup failed at port:{0}", _webApiPort));
            }
        }

        private static void Stop()
        {
            /*Stop操作顺序与启动顺序相反*/

            if(_webApiServer != null)
            {
                _webApiServer.Close();
                _webApiServer.Dispose();
                _webApiServer = null;
            }

            CollectionServiceHandler.Manager = null;
            if(_collectionServiceManager != null)
            {
                _collectionServiceManager.StopService();
                _collectionServiceManager.Dispose();
                _collectionServiceManager = null;
            }
        }
    }
}
