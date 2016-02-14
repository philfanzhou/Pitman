using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Wmcloud;
using Pitman.Application.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Application.DataCollection.Services
{
    public class HistoryDataService
    {
        // 获取数据API
        private StockKLineApi wmcloudApi = new StockKLineApi();
        // 存储数据服务
        private KLineAppService appService = new KLineAppService();

        public void RefreshKLineData()
        {
            // 获取所有证券信息
            var securities = SecurityService.GetDataFromApi().ToList();

            // 检查并更新或增加
            foreach (var security in securities)
            {
                DateTime? lastTradeDate = appService.GetLastTradeDate(KLineType.Day, security.Code);
                List<StockKLine> stockKLines = null;

                if (lastTradeDate == null)
                {
                    try
                    {
                        stockKLines = wmcloudApi.GetKLineFromWmcloudApi(security.Code);
                    }
                    catch (Exception ex)
                    {
                        //此处异常通常是因为security.Code并不是真正的股票代码(如：166105)，此时通联数据并不支持
                        continue;
                    }
                }
                else
                {
                    string startDate = lastTradeDate.Value.AddDays(1).ToString("yyyyMMdd");
                    stockKLines = wmcloudApi.GetKLineFromWmcloudApi(security.Code, startDate);
                }

                appService.Add(KLineType.Day, security.Code, stockKLines);
            }
        }
    }
}
