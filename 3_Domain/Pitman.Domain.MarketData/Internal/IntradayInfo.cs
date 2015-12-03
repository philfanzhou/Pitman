using Ore.Infrastructure.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pitman.Domain.MarketData
{
    /// <summary>
    /// 分时数据信息类
    /// </summary>
    internal class IntradayInfo
    {
        private static readonly TimeSpan span = new TimeSpan(0, 1, 0);

        private readonly List<StockIntraday> _intradayItems = new List<StockIntraday>();
        private readonly DateTime date;

        public IntradayInfo(DateTime date)
        {
            this.date = date.Date;
        }

        public override string ToString()
        {
            return this.date.ToString("yyyy-MM-dd");
        }

        public IEnumerable<IStockIntraday> Items
        {
            get
            {
                return _intradayItems;
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
            if (realTimeItem.Time.Date != this.date.Date)
                throw new ArgumentOutOfRangeException("item");

            AddNewIntradayItemIfNeeded(realTimeItem);
            UpdateLastIntradayItemInfo(realTimeItem);
        }

        private void UpdateLastIntradayItemInfo(IStockRealTime realTimeItem)
        {
            StockIntraday intradayItem = _intradayItems.Last();

            intradayItem.Current = realTimeItem.Current;
            intradayItem.Change = Math.Round(realTimeItem.Current - realTimeItem.TodayOpen, 2);
            intradayItem.TotalVolume = realTimeItem.Volume;
            intradayItem.TotalAmount = realTimeItem.Amount;

            // 需要进行特殊处理避免除0
            intradayItem.ChangeRate = Math.Abs(realTimeItem.TodayOpen) < 0.00001 ? 0 :
                Math.Round(intradayItem.Change / realTimeItem.TodayOpen * 100, 2);
            intradayItem.AveragePrice = Math.Abs(realTimeItem.Volume) < 0.00001 ? 0 :
                Math.Round(realTimeItem.Amount / realTimeItem.Volume, 2);

            // 根据前面的数据，求出分时成交量和成交额
            if (_intradayItems.Count > 1)
            {
                StockIntraday previousDate = _intradayItems[_intradayItems.Count - 2];
                intradayItem.IntradayVolume = realTimeItem.Volume - previousDate.TotalVolume;
                intradayItem.IntradayAmount = realTimeItem.Amount - previousDate.TotalAmount;
            }
            else
            {
                intradayItem.IntradayVolume = realTimeItem.Volume;
                intradayItem.IntradayAmount = realTimeItem.Amount;
            }
        }

        private void AddNewIntradayItemIfNeeded(IStockRealTime realTimeItem)
        {
            if (_intradayItems.Count < 1 ||
                            realTimeItem.Time - _intradayItems.Last().Time > span)
            {
                var newItem = new StockIntraday
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
                    Market = realTimeItem.Market
                };

                this._intradayItems.Add(newItem);
            }
        }
    }
}
