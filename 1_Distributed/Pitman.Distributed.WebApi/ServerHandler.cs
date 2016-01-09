using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.SelfHost;

namespace Pitman.Distributed.WebApi
{
    public class ServerHandler
    {
        private HttpSelfHostServer _httpServer;

        public void CreateServer()
        {
            var configuration = new HttpSelfHostConfiguration("http://localhost:9999");
            _httpServer = new HttpSelfHostServer(configuration);

            RouteConfig.Register(_httpServer.Configuration);

            _httpServer.OpenAsync();
        }
    }
}
