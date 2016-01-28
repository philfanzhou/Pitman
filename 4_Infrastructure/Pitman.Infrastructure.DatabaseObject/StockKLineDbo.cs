using Ore.Infrastructure.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pitman.Infrastructure.DatabaseObject
{
    public class StockKLineDbo : IStockKLine
    {
        public DateTime Time { get; set; }

        public double Amount { get; set; }

        public double Close { get; set; }

        public double High { get; set; }

        public double Low { get; set; }

        public double Open { get; set; }

        public double Volume { get; set; }
    }

    public static class KLineConverter
    {
        public static IEnumerable<StockKLineDbo> ToDbo(this IEnumerable<IStockKLine> self)
        {
            return self.Select(p => p.ToDbo());
        }

        public static StockKLineDbo ToDbo(this IStockKLine self)
        {
            StockKLineDbo outputData = new StockKLineDbo
            {
                //
                // 摘要:
                //     成交额
                Amount = self.Amount,
                //
                // 摘要:
                //     收盘
                Close = self.Close,
                //
                // 摘要:
                //     最高
                High = self.High,
                //
                // 摘要:
                //     最低
                Low = self.Low,
                //
                // 摘要:
                //     今开
                Open = self.Open,
                //
                // 摘要:
                //     日期与时间
                Time = self.Time,
                //
                // 摘要:
                //     成交量
                Volume = self.Volume
            };

            return outputData;
        }
    }
}
