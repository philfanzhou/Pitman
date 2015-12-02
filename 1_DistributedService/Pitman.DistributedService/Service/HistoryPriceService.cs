using Ore.Infrastructure.MarketData;
using Pitman.Application.MarketData;
using Pitman.DistributedService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace Pitman.DistributedService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [AspNetCompatibilityRequirements(
        RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    internal class HistoryPriceService : IHistoryPrice
    {
        [WebInvoke(UriTemplate = HistoryPriceConst.Uri_1MinuteData,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public IEnumerable<StockKLineDto> Get1MinuteData(string stockCode, DateTime startTime, DateTime endTime)
        {
            HistoryPriceAppService appService = new HistoryPriceAppService();
            var result = appService.GetMinutesData(stockCode, startTime, endTime);
            return result.Select(t => ConvertToDto(t));
        }

        private static StockKLineDto ConvertToDto(IStockKLine priceData)
        {
            return new StockKLineDto
            {
                Amount = priceData.Amount,
                Code = priceData.Code,
                Current = priceData.Current,
                High = priceData.High,
                Low = priceData.Low,
                MarketStr = priceData.Market.ToString(),
                ShortName = priceData.ShortName,
                Time = priceData.Time,
                Open = priceData.Open,
                Volume = priceData.Volume,
                PreClose = priceData.PreClose
            };
        }
    }
}
