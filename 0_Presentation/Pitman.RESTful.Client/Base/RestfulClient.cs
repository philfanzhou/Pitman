using System;

namespace Pitman.RESTful.Client
{
    internal class RestfulClient : IClient
    {
        private string _serverAddress;
        private string _serviceName;

        protected RestfulClient(string serverAddress, string serviceName)
        {
            this._serverAddress = serverAddress;
            this._serviceName = serviceName;
        }

        public string ServerAddress
        {
            get { return _serverAddress; }
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
