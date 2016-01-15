using Pitman.Application.DataCollection;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace Pitman.Distributed.WebApi
{
    public class WebApiServer : IDisposable
    {
        private readonly int _port;
        private HttpSelfHostServer _httpServer;

        private static IServiceManager _collectionServiceManager;

        public WebApiServer(int port, IServiceManager collectionServiceManager)
        {
            _port = port;
            _collectionServiceManager = collectionServiceManager;
        }

        public void Dispose()
        {
            if(_httpServer != null)
            {
                _httpServer.Dispose();
                _httpServer = null;
            }
        }

        public string BasicAddress
        {
            get
            {
                if (_httpServer == null)
                {
                    return string.Empty;
                }
                else
                {
                    return (_httpServer.Configuration as HttpSelfHostConfiguration).BaseAddress.ToString();
                }
            }
        }

        public bool Open()
        {
            var configuration = new HttpSelfHostConfiguration(string.Format("http://localhost:{0}", _port));
            _httpServer = new HttpSelfHostServer(configuration);

            configuration.MapHttpAttributeRoutes();

            configuration.Routes.MapHttpRoute(
                    name: "CollectionStatus",
                    routeTemplate: "api/CollectionStatus/{serviceName}",
                    defaults: new
                    {
                        controller = "CollectionStatus",
                        serviceName = RouteParameter.Optional
                    }
                );

            configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{stockCode}",
                defaults: new
                {
                    stockCode = RouteParameter.Optional
                }
            );

            _httpServer.OpenAsync().Wait();

            return IsListening();
        }

        public bool Close()
        {
            _httpServer.CloseAsync().Wait();
            return !IsListening();
        }

        /// <summary>
        /// 获取当前服务的监听状况
        /// </summary>
        /// <returns></returns>
        private bool IsListening()
        {
            //获取本地计算机的网络连接和通信统计数据的信息
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();

            //返回本地计算机上的所有Tcp监听程序
            IPEndPoint[] ipsTCP = ipGlobalProperties.GetActiveTcpListeners();

            //返回本地计算机上的所有UDP监听程序
            IPEndPoint[] ipsUDP = ipGlobalProperties.GetActiveUdpListeners();

            //返回本地计算机上的Internet协议版本4(IPV4 传输控制协议(TCP)连接的信息。
            TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();

            List<int> allPorts = new List<int>();
            foreach (IPEndPoint ep in ipsTCP) allPorts.Add(ep.Port);
            foreach (IPEndPoint ep in ipsUDP) allPorts.Add(ep.Port);
            foreach (TcpConnectionInformation conn in tcpConnInfoArray) allPorts.Add(conn.LocalEndPoint.Port);

            if(allPorts.Contains(_port))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal static IServiceManager CollectionServiceManager
        {
            get { return _collectionServiceManager; }
        }
    }
}
