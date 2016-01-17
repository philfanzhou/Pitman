using Ore.Infrastructure.MarketData;
using Pitman.Distributed.Dto;

namespace Pitman.Distributed.WebApi
{
    internal static class KLineConverter
    {
        internal static StockKLineDto ConvertToDto(this IStockKLine data)
        {
            return new StockKLineDto
            {
                Amount = data.Amount,
                Close = data.Close,
                High = data.High,
                Low = data.Low,
                Open = data.Open,
                Time = data.Time,
                Volume = data.Volume
            };
        }
    }
}
