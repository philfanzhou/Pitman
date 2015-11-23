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
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    internal class RealTimePriceService : IRealTimePrice
    {
        [WebInvoke(UriTemplate = RealTimePriceConst.Uri_GetLatest, 
            ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<StockRealTimePriceDto> GetLatest(IEnumerable<string> stockCodes)
        {
            RealTimePriceAppService appService = new RealTimePriceAppService();
            var result = appService.GetLatest(stockCodes);
            return result.Select(t => ConvertToDto(t));
        }

        [WebInvoke(UriTemplate = RealTimePriceConst.Uri_GetData,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public IEnumerable<StockRealTimePriceDto> GetData(
            IEnumerable<string> stockCodes, 
            DateTime startDate, 
            DateTime endDate)
        {
            RealTimePriceAppService appService = new RealTimePriceAppService();
            var result = appService.GetData(stockCodes, startDate, endDate);
            return result.Select(t => ConvertToDto(t));
        }

        private static StockRealTimePriceDto ConvertToDto(IStockRealTimePrice priceData)
        {
            return new StockRealTimePriceDto
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
                YesterdayClose = priceData.YesterdayClose,

                 Buy1Price = priceData.Buy1Price,
                 Buy1Volume = priceData.Buy1Volume,
                 Buy2Price = priceData.Buy2Price,
                 Buy2Volume = priceData.Buy2Volume,
                 Buy3Price = priceData.Buy3Price,
                 Buy3Volume = priceData.Buy3Volume,
                 Buy4Price = priceData.Buy4Price,
                 Buy4Volume = priceData.Buy4Volume,
                 Buy5Price = priceData.Buy5Price,
                 Buy5Volume = priceData.Buy5Volume,

                 Sell1Price = priceData.Sell1Price,
                 Sell1Volume = priceData.Sell1Volume,
                 Sell2Price = priceData.Sell2Price,
                 Sell2Volume = priceData.Sell2Volume,
                 Sell3Price = priceData.Sell3Price,
                 Sell3Volume = priceData.Sell3Volume,
                 Sell4Price = priceData.Sell4Price,
                 Sell4Volume = priceData.Sell4Volume,
                 Sell5Price = priceData.Sell5Price,
                 Sell5Volume = priceData.Sell5Volume
            };
        }
    }
}
