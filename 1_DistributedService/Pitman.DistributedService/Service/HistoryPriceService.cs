using Ore.Infrastructure.MarketData;
using Pitman.Application.MarketData;
using Pitman.DistributedService.Contracts;
using Pitman.DistributedService.Dto;
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
        [WebInvoke(UriTemplate = HistoryPriceConst.Uri_GetData, 
            ResponseFormat = WebMessageFormat.Json, 
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public IEnumerable<StockHistoryPriceDto> GetData(
            IEnumerable<string> stockCodes, 
            PriceDataTypeDto dataType, 
            DateTime startDate, 
            DateTime endDate)
        {
            HistoryPriceAppService appService = new HistoryPriceAppService();
            var result = appService.GetMinutesData(stockCodes, startDate, endDate);
            return result.Select(t => ConvertToDto(t));
        }

        private static StockHistoryPriceDto ConvertToDto(IStockHistoryPrice priceData)
        {
            return new StockHistoryPriceDto
            {
                Amount = priceData.Amount,
                Code = priceData.Code,
                Current = priceData.Current,
                High = priceData.High,
                Low = priceData.Low,
                Market = (MarketDto)Enum.Parse(typeof(MarketDto), priceData.Market.ToString()),
                ShortName = priceData.ShortName,
                Time = priceData.Time,
                TodayOpen = priceData.TodayOpen,
                Volume = priceData.Volume,
                YesterdayClose = priceData.YesterdayClose
            };
        }
    }
}
