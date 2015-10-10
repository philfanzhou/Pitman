/****************************************************
一：获取股票的基本信息，包含股票交易代码及其简称、股票类型、上市状态、上市板块、上市日期等；上市状态为最新数据，不显示历史变动信息
名称	类型	必填	描述
equTypeCD	String	3选1	股票分类编码，输入A或B可查询获取到A股或B股
secID	String	3选1	证券内部编码，可通过交易代码和交易市场在getSecurityID获取到。
ticker	String	3选1	股票交易代码，如'000001'
listStatusCD	String	否	上市状态，可选状态有:L-上市，S-暂停，DE-终止上市，UN-未上市，默认为L。
field	string	是	可选参数，用","分隔,默认为空，返回全部字段，不选即为默认值。返回字段见下方
 
 * 
****************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Ore.Infrastructure.MarketData.Implementation
{
    public class WmcloudDataReader : IProfileReader
    {
        //股票基本信息URL
        private static string EquUrl = "https://api.wmcloud.com:443/data/v1/api/equity/getEqu.json?field=&listStatusCD=L&secID=&ticker=&equTypeCD=A";

        //指数日线行情URL
        private static string MktIdxdUrl = "https://api.wmcloud.com:443/data/v1/api/market/getMktIdxd.json?field=&beginDate={0}&endDate={1}&indexID=&ticker={2}&tradeDate=";

        //股票日线数据URL
        private static string MktEqudUrl = "https://api.wmcloud.com:443/data/v1/api/market/getMktEqud.json?field=&beginDate={0}&endDate={1}&secID=&ticker={2}&tradeDate=";

        private static string GetDataFromUrl(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Timeout = 5000;
            request.Proxy = null;
            request.Headers.Add("Authorization: Bearer 4e4851b6b5d3c33c84fa82f28e93fa403c422b10bb4cb60bead35734a82288eb");

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader streamReader
                    = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        private static string GetJsonStrByMessage(string message)
        {
            message = message.Split(new string[] { "data\":" }, StringSplitOptions.RemoveEmptyEntries)[1];
            return message.Substring(0, message.Length - 1);
        }

        public IEnumerable<ISecurityProfile> GetAll()
        {
            string message = GetDataFromUrl(EquUrl);
            message = GetJsonStrByMessage(message);
            List<Equ> equList = JsonHelper.JsonToList<Equ>(message);

            return equList;
        }

        public IEnumerable<MktEqud> GetDailyStockData(string code, DateTime beginDay, DateTime endDay)
        {
            string strBeginDate = beginDay.ToString("yyyyMMdd");
            string strEndDate = endDay.ToString("yyyyMMdd");
            string mktEqudUrl = string.Format(MktEqudUrl, strBeginDate, strEndDate, code);

            string message = GetDataFromUrl(mktEqudUrl);
            message = GetJsonStrByMessage(message);
            List<MktEqud> mktEqudList = JsonHelper.JsonToList<MktEqud>(message);

            return mktEqudList;
        }

        public IEnumerable<MktIdxd> GetDailyIndexData(string code, DateTime beginDay, DateTime endDay)
        {
            string strBeginDate = beginDay.ToString("yyyyMMdd");
            string strEndDate = endDay.ToString("yyyyMMdd");
            string mktIdxdUrl = string.Format(MktIdxdUrl, strBeginDate, strEndDate, code);
            string message = GetDataFromUrl(mktIdxdUrl);

            message = GetJsonStrByMessage(message);
            List<MktIdxd> mktIdxdList = JsonHelper.JsonToList<MktIdxd>(message);

            return mktIdxdList;
        }
    }
}
