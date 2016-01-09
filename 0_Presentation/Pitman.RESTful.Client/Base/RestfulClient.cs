using System;

namespace Pitman.RESTful.Client
{
    internal class RestfulClient
    {
        private string _serverAddress;
        private string _serviceName;

        protected RestfulClient(string serverAddress, string serviceName)
        {
            this._serverAddress = serverAddress;
            this._serviceName = serviceName;
        }

        protected string HostName
        {
            get { return _serverAddress; }
        }

        protected string ServiceName
        {
            get { return _serviceName; }
        }

        protected HttpClientEx GetHttpClient()
        {
            var client = new HttpClientEx();
            client.BaseAddress = GetBaseUri();
            return client;
        }

        private Uri GetBaseUri()
        {
            string uriString = string.Format("{0}/{1}/", _serverAddress, _serviceName);
            return new Uri(uriString);
        }
    }
}
