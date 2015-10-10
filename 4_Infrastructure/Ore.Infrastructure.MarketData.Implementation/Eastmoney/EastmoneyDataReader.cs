using System.IO;
using System.Net;
using System.Text;

namespace Ore.Infrastructure.MarketData.Implementation
{
    public class EastmoneyDataReader
    {
        private static string OrgPercentUrl = "http://data.eastmoney.com/stockcomment/{0}.html";

        private static string GetDataFromUrl(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Timeout = 5000;
            request.Proxy = null;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader streamReader
                    = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("gb2312")))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        public OrgPercentData Get(string code)
        {
            string url = string.Format(OrgPercentUrl, code);
            string message = GetDataFromUrl(url);
            
            return new OrgPercentData(code, message);
        }
    }
}
