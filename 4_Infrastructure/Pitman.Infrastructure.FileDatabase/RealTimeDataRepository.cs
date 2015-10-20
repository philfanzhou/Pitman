using Ore.Infrastructure.MarketData;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Pitman.Infrastructure.FileDatabase
{
    public class RealTimeDataRepository
    {
        public void Add(ISecurity securityInfo, IStockRealTimePrice data)
        {
            using (var file = RealTimeFile.CreateOrOpen(securityInfo, data.Time))
            {
                RealTimeItem dataItem = data.Convert();
                file.Add(dataItem);
            }
        }

        public IEnumerable<IStockRealTimePrice> GetOneDayData(ISecurity securityInfo, DateTime day)
        {
            using (var file = RealTimeFile.Open(securityInfo, day))
            {
                var data = file.ReadAll().ToList();
                string code = data.Last().Code;
                return data.Cast<IStockRealTimePrice>();
            }
        }
    }

    internal static class StockRealTimePriceExt
    {
        public static RealTimeItem Convert(this IStockRealTimePrice self)
        {
            RealTimeItem outputData = new RealTimeItem
            {
                Code = self.Code,
                ShortName = self.ShortName,
                Market = self.Market,
                TodayOpen = self.TodayOpen,
                YesterdayClose = self.YesterdayClose,
                Current = self.Current,
                High = self.High,
                Low = self.Low,
                Volume = self.Volume,
                Amount = self.Amount,
                Time = self.Time,

                Buy1Price = self.Buy1Price,
                Buy1Volume = self.Buy1Volume,
                Buy2Price = self.Buy2Price,
                Buy2Volume = self.Buy2Volume,
                Buy3Price = self.Buy3Price,
                Buy3Volume = self.Buy3Volume,
                Buy4Price = self.Buy4Price,
                Buy4Volume = self.Buy4Volume,
                Buy5Price = self.Buy5Price,
                Buy5Volume = self.Buy5Volume,

                Sell1Price = self.Sell1Price,
                Sell1Volume = self.Sell1Volume,
                Sell2Price = self.Sell2Price,
                Sell2Volume = self.Sell2Volume,
                Sell3Price = self.Sell3Price,
                Sell3Volume = self.Sell3Volume,
                Sell4Price = self.Sell4Price,
                Sell4Volume = self.Sell4Volume,
                Sell5Price = self.Sell5Price,
                Sell5Volume = self.Sell5Volume
            };

            return outputData;
        }
    }
}
