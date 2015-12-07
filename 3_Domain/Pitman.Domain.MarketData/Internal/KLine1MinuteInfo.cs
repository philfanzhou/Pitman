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

        private readonly List<StockMinutesKLine> _items = new List<StockMinutesKLine>();

        private DateTime currentDate = new DateTime();

        public IEnumerable<IStockKLine> Items
        {
            get
            {
                return _items;
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
            AddNewItemIfNeeded(realTimeItem);

            UpdateLastItemInfo(realTimeItem);
        }

        private void AddNewItemIfNeeded(IStockRealTime realTimeItem)
        {
            if (currentDate.Date != realTimeItem.Time.Date ||
                            realTimeItem.Time - _items.Last().Time > span)
            {
                var newItem = new StockMinutesKLine
                {
                    Time = new DateTime(
                        realTimeItem.Time.Year,
                        realTimeItem.Time.Month,
                        realTimeItem.Time.Day,
                        realTimeItem.Time.Hour,
                        realTimeItem.Time.Minute,
                        0),

                    Code = realTimeItem.Code,
                    ShortName = realTimeItem.ShortName,
                    Market = realTimeItem.Market,

                    // 当前分析周期的开盘价 = 第一条数据的成交价
                    Open = realTimeItem.Current,

                    // 构造第一条数据的时候，就设定好最高、最低的值
                    High = realTimeItem.Current,
                    Low = realTimeItem.Current,
                };

                _items.Add(newItem);
                currentDate = realTimeItem.Time.Date;
            }
        }

        private void UpdateLastItemInfo(IStockRealTime realTimeItem)
        {
            StockMinutesKLine currentItem = _items.Last();

            currentItem.Current = realTimeItem.Current;

            // 取得最高价和最低价
            if(realTimeItem.Current > currentItem.High)
            {
                currentItem.High = realTimeItem.Current;
            }
            else if(realTimeItem.Current < currentItem.Low)
            {
                currentItem.Low = realTimeItem.Current;
            }

            //currentItem.PreClose
        }
    }
}
