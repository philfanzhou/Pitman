using Ore.Infrastructure.MarketData;
using Pitman.Application.MarketData;
using Pitman.DistributedService.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace Pitman.DistributedService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    internal class RealTimeService : IRealTimeService
    {
        [WebInvoke(UriTemplate = Contracts.RealTimeService.Uri_GetLatest, 
            ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<StockRealTimeDto> GetLatest(IEnumerable<string> stockCodes)
        {
            RealTimeAppService appService = new RealTimeAppService();
            var result = appService.GetLatest(stockCodes);
            return result.Select(t => ConvertToDto(t));
        }

        private static StockRealTimeDto ConvertToDto(IStockRealTime priceData)
        {
            return new StockRealTimeDto
            {
                Amount = priceData.Amount,
                Code = priceData.Code,
                Current = priceData.Current,
                High = priceData.High,
                Low = priceData.Low,
                MarketStr = priceData.Market.ToString(),
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
