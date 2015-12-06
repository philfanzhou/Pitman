using Ore.Infrastructure.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Domain.MarketData
{
    /// <summary>
    /// 一分钟K线信息类
    /// </summary>
    public class KLine1MinuteInfo
    {
        private static readonly TimeSpan span = new TimeSpan(0, 1, 0);

        private readonly List<StockKLine> _1MinuteItems = new List<StockKLine>();

        public IEnumerable<IStockKLine> Items
        {
            get
            {
                return _1MinuteItems;
            }
        }
        public void Add(IEnumerable<IStockRealTime> realTimeItems)
        {
            foreach (var realTimeItem in realTimeItems)
            {
                Add(realTimeItem);
            }
        }

        public void Add(IStockRealTime realTimeItem)
        {

        }
    }
}
