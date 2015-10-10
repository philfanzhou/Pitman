using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Ore.Infrastructure.MarketData.Implementation
{
    public class SinaDataReader
    {
        private const string WebApiAddress = @"http://hq.sinajs.cn/list=";

        /// <summary>
        /// 获取单个分时数据
        /// </summary>
        /// <param name="code"></param>
        /// <example>code = "sh600036"</example>
        /// <returns></returns>
        public SinaRealTimeData GetData(string code)
        {
            string url = WebApiAddress + code;
            string strData = GetStringData(url);
            SinaRealTimeData data = new SinaRealTimeData(strData);
            return data;
        }

        public IEnumerable<SinaRealTimeData> GetData(IEnumerable<string> codes)
        {
            StringBuilder codesBuilder = new StringBuilder();
            foreach(string code in codes)
            {
                if(codesBuilder.Length > 0)
                {
                    codesBuilder.Append(',');
                }
                codesBuilder.Append(code);
            }

            string strData = GetStringData(WebApiAddress + codesBuilder.ToString());
            string[] strDatas = strData.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            List<SinaRealTimeData> datas = new List<SinaRealTimeData>();
            foreach (string item in strDatas)
            {
                SinaRealTimeData data = new SinaRealTimeData(item);
                datas.Add(data);
            }

            return datas;
        }

        private string GetStringData(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader myreader
                    = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("GBK")))
                {
                    return myreader.ReadToEnd();
                }
            }
        }
    }
}
