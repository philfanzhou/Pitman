using Pitman.DistributedService.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Presentation.RESTfulClient
{
    internal class CollectionStatusClient : ICollectionStatus
    {
        public IEnumerable<string> GetAllServiceName()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9999/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = client.GetAsync("collectionservice/allservicename").Result.EnsureSuccessStatusCode();
                string jsonStr = response.Content.ReadAsStringAsync().Result;
                return JsonToModel<IEnumerable<string>>(jsonStr);
            }
        }

        public string GetStatus(string serviceName)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9999/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = client.GetAsync(string.Format("collectionservice/Status/{0}", serviceName)).Result.EnsureSuccessStatusCode();
                string jsonStr = response.Content.ReadAsStringAsync().Result;
                return JsonToModel<string>(jsonStr);
            }
        }

        /// <summary>
        /// Json转换成实体类，返回对象
        /// </summary>
        /// <typeparam name="T">反序列化类型</typeparam>
        /// <param name="jsonString">反序列化字符串</param>
        /// <returns>反序列化后的值</returns>
        private static T JsonToModel<T>(string jsonString)
        {
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                T returnOjbect = (T)serializer.ReadObject(ms);
                return returnOjbect;
            }
        }

        private static string ConvertToJson<T>(T obj)
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
    }
}
