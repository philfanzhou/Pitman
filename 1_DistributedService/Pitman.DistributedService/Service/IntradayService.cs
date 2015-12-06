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
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    internal class IntradayService : IIntradayService
    {
        [WebInvoke(UriTemplate = IntradayServiceConst.Uri_GetData,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public IEnumerable<StockIntradayDto> GetData(string stockCode, DateTime startDate, DateTime endDate)
        {
            IntradayAppService appService = new IntradayAppService();

            /*test code for communication*************************************/
            List<IStockIntraday> result = new List<IStockIntraday>();
            StockIntradayDto item = new StockIntradayDto();
            item.Code = stockCode;
            result.Add(item);
            return result.Select(t => ConvertToDto(t));
            /*test code for communication*************************************/
            
            //var result = appService.GetData(stockCode, startDate, endDate);
            //return result.Select(t => ConvertToDto(t));
        }

        private StockIntradayDto ConvertToDto(IStockIntraday data)
        {
            return new StockIntradayDto
            {
                Amount = data.Amount,
                AveragePrice = data.AveragePrice,
                Code = data.Code,
                YesterdayClose = data.YesterdayClose,
                Current = data.Current,
                Market = data.Market,
                ShortName = data.ShortName,
                Time = data.Time,
                Volume = data.Volume,
                BuyVolume = data.BuyVolume,
                SellVolume = data.SellVolume
            };
        }
    }
}
