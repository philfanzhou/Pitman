using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Pitman.RESTful.Client
{
    internal class HttpClientEx : HttpClient
    {
        private readonly JsonSerializer _jsonSerializer = new JsonSerializer();

        public HttpClientEx(string serverAddress)
        {
            string address = CorrectionAddress(serverAddress);
            BaseAddress = new Uri(address);

            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public T GetAndReadAs<T>(string requestUri)
        {
            using (HttpResponseMessage response = this.GetAsync(requestUri).Result.EnsureSuccessStatusCode())
            {
                string jsonStr = response.Content.ReadAsStringAsync().Result;
                return _jsonSerializer.Deserialize<T>(jsonStr);
            }
        }

        public TResult PostAndReadAs<TResult, TPostData>(string requestUri, TPostData postData)
        {
            string jsonStr = _jsonSerializer.Serialize(postData);
            return PostAndReadAs<TResult>(requestUri, jsonStr);
        }

        #region Private Method
        private string CorrectionAddress(string serverAddress)
        {
            string result = serverAddress;
            if (!serverAddress.EndsWith("/"))
            {
                result = serverAddress + "/";
            }

            return result;
        }

        private TResult PostAndReadAs<TResult>(string requestUri, string jsonStr)
        {
            using (HttpContent content = new StringContent(jsonStr))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return PostAndReadAs<TResult>(requestUri, content);
            }
        }

        private TResult PostAndReadAs<TResult>(string requestUri, HttpContent content)
        {
            using (HttpResponseMessage response
                    = this.PostAsync(requestUri, content).Result.EnsureSuccessStatusCode())
            {
                string jsonStr = response.Content.ReadAsStringAsync().Result;
                return _jsonSerializer.Deserialize<TResult>(jsonStr);
            }
        }
        #endregion
    }
}
