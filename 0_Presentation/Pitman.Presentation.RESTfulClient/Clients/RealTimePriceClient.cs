using Pitman.DistributedService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitman.DistributedService.Dto;

namespace Pitman.Presentation.RESTfulClient
{
    internal class RealTimePriceClient : IRealTimePrice
    {
        public IEnumerable<StockRealTimePriceDto> GetLatest(IEnumerable<string> stockCodes)
        {
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://localhost:9999/");
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    // HTTP GET
            //    HttpContent content = new StringContent(ConvertToJson(serviceName));
            //    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //    HttpResponseMessage response = client.PostAsync("collectionservice/Status", content).Result.EnsureSuccessStatusCode();
            //    string jsonStr = response.Content.ReadAsStringAsync().Result;
            //    return JsonToModel<string>(jsonStr);
            //}

            throw new NotImplementedException();
        }
    }
}
