using System.Net.Http;
using System.Net.Http.Headers;

namespace Pitman.Presentation.RESTfulClient
{
    internal class HttpClientEx : HttpClient
    {
        private readonly JsonSerializer _jsonSerializer = new JsonSerializer();

        public HttpClientEx()
        {
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

        public TResult PostAndReadAs<TResult>(string requestUri, HttpContent content)
        {
            using (HttpResponseMessage response
                    = this.PostAsync(requestUri, content).Result.EnsureSuccessStatusCode())
            {
                string jsonStr = response.Content.ReadAsStringAsync().Result;
                return _jsonSerializer.Deserialize<TResult>(jsonStr);
            }
        }

        public TResult PostAndReadAs<TResult>(string requestUri, string jsonStr)
        {
            using (HttpContent content = CreateContentWithJsonString(jsonStr))
            {
                return PostAndReadAs<TResult>(requestUri, content);
            }
        }

        public TResult PostAndReadAs<TResult, TPostData>(string requestUri, TPostData postData)
        {
            string jsonStr = _jsonSerializer.Serialize(postData);
            return PostAndReadAs<TResult>(requestUri, jsonStr);
        }

        private StringContent CreateContentWithJsonString(string jsonStr)
        {
            StringContent content = new StringContent(jsonStr);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return content;
        }
    }
}
