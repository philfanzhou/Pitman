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

        public TResult PostAndReasAs<TResult, TPostData>(string requestUri, TPostData postData)
        {
            using (HttpContent content = GetContentWithJson(postData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                using (HttpResponseMessage response
                    = this.PostAsync(requestUri, content).Result.EnsureSuccessStatusCode())
                {
                    string jsonStr = response.Content.ReadAsStringAsync().Result;
                    return _jsonSerializer.Deserialize<TResult>(jsonStr);
                }
            }
        }

        private StringContent GetContentWithJson<T>(T data)
        {
            string jsonStr = _jsonSerializer.Serialize(data);
            StringContent content = new StringContent(jsonStr);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return content;
        }
    }
}
