using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Pitman.Presentation.RESTfulClient
{
    internal class RestfulClient : HttpClient
    {
        public RestfulClient()
        {
            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public T GetAndReadAs<T>(string uri)
        {
            HttpResponseMessage response = this.GetAsync(uri).Result.EnsureSuccessStatusCode();
            string jsonStr = response.Content.ReadAsStringAsync().Result;
            return ToJsonObject<T>(jsonStr);
        }

        private static string ToJsonString<T>(T obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                serializer.WriteObject(ms, obj);
                StringBuilder sb = new StringBuilder();
                sb.Append(Encoding.UTF8.GetString(ms.ToArray()));
                return sb.ToString();
            }
        }
        internal static T ToJsonObject<T>(string jsonString)
        {
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                T returnOjbect = (T)serializer.ReadObject(ms);
                return returnOjbect;
            }
        }
    }
}
