using Ore.Infrastructure.MarketData;
using Pitman.Infrastructure.EF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Application.MarketData
{
    class KLineAppService
    {
    }

    internal static class StockKLineExt
    {
        public static KLineDbo ConvertToDbo(this IStockKLine self)
        {
            KLineDbo outputData = new KLineDbo
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
