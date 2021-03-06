﻿using Ore.Infrastructure.MarketData;
using System;
using System.Runtime.Serialization;

namespace Pitman.Distributed.DataTransferObject
{
    [DataContract(Name = "stockRealTime")]
    public class StockRealTimeDto : IStockRealTime
    {
        /// <summary>
        /// 交易代码
        /// </summary>
        [DataMember(Name = "code")]
        public string Code { get; set; }

        /// <summary>
        /// 股票简称
        /// </summary>
        [DataMember(Name = "shortName")]
        public string ShortName { get; set; }

        [DataMember(Name = "market")]
        private string market = Market.Unknown.ToString();
        public Market Market
        {
            get
            {
                return (Market)Enum.Parse(typeof(Market), market);
            }
            set
            {
                market = value.ToString();
            }
        }

        [DataMember(Name = "time")]
        private DateTimeDto time = new DateTimeDto();
        public DateTime Time
        {
            get { return time.Value; }
            set { time.Value = value; }
        }

        /// <summary>
        /// 今开
        /// </summary>
        [DataMember(Name = "todayOpen")]
        public double TodayOpen { get; set; }

        /// <summary>
        /// 昨收
        /// </summary>
        [DataMember(Name = "yesterdayClose")]
        public double YesterdayClose { get; set; }

        /// <summary>
        /// 当前成交价
        /// </summary>
        [DataMember(Name = "current")]
        public double Current { get; set; }

        /// <summary>
        /// 最高
        /// </summary>
        [DataMember(Name = "high")]
        public double High { get; set; }

        /// <summary>
        /// 最低
        /// </summary>
        [DataMember(Name = "low")]
        public double Low { get; set; }

        /// <summary>
        /// 成交量
        /// </summary>
        [DataMember(Name = "volume")]
        public double Volume { get; set; }

        /// <summary>
        /// 成交额
        /// </summary>
        [DataMember(Name = "amount")]
        public double Amount { get; set; }

        public override string ToString()
        {
            return this.time + string.Format("  Current:{0}", Current);
        }

        #region 卖盘

        /// <summary>
        /// 卖五价
        /// </summary>
        [DataMember(Name = "sell5Price")]
        public double Sell5Price { get; set; }

        /// <summary>
        /// 卖五量
        /// </summary>
        [DataMember(Name = "sell5Volume")]
        public double Sell5Volume { get; set; }

        /// <summary>
        /// 卖四价
        /// </summary>
        [DataMember(Name = "sell4Price")]
        public double Sell4Price { get; set; }

        /// <summary>
        /// 卖四量
        /// </summary>
        [DataMember(Name = "sell4Volume")]
        public double Sell4Volume { get; set; }

        /// <summary>
        /// 卖三价
        /// </summary>
        [DataMember(Name = "sell3Price")]
        public double Sell3Price { get; set; }

        /// <summary>
        /// 卖三量
        /// </summary>
        [DataMember(Name = "sell3Volume")]
        public double Sell3Volume { get; set; }

        /// <summary>
        /// 卖二价
        /// </summary>
        [DataMember(Name = "sell2Price")]
        public double Sell2Price { get; set; }

        /// <summary>
        /// 卖二量
        /// </summary>
        [DataMember(Name = "sell2Volume")]
        public double Sell2Volume { get; set; }

        /// <summary>
        /// 卖一价
        /// </summary>
        [DataMember(Name = "sell1Price")]
        public double Sell1Price { get; set; }

        /// <summary>
        /// 卖一量
        /// </summary>
        [DataMember(Name = "sell1Volume")]
        public double Sell1Volume { get; set; }

        #endregion

        #region 买盘

        /// <summary>
        /// 买一价
        /// </summary>
        [DataMember(Name = "buy1Price")]
        public double Buy1Price { get; set; }

        /// <summary>
        /// 买一量
        /// </summary>
        [DataMember(Name = "buy1Volume")]
        public double Buy1Volume { get; set; }

        /// <summary>
        /// 买二价
        /// </summary>
        [DataMember(Name = "buy2Price")]
        public double Buy2Price { get; set; }

        /// <summary>
        /// 买二量
        /// </summary>
        [DataMember(Name = "buy2Volume")]
        public double Buy2Volume { get; set; }

        /// <summary>
        /// 买三价
        /// </summary>
        [DataMember(Name = "buy3Price")]
        public double Buy3Price { get; set; }

        /// <summary>
        /// 买三量
        /// </summary>
        [DataMember(Name = "buy3Volume")]
        public double Buy3Volume { get; set; }

        /// <summary>
        /// 买四价
        /// </summary>
        [DataMember(Name = "buy4Price")]
        public double Buy4Price { get; set; }

        /// <summary>
        /// 买四量
        /// </summary>
        [DataMember(Name = "buy4Volume")]
        public double Buy4Volume { get; set; }

        /// <summary>
        /// 买五价
        /// </summary>
        [DataMember(Name = "buy5Price")]
        public double Buy5Price { get; set; }

        /// <summary>
        /// 买五量
        /// </summary>
        [DataMember(Name = "buy5Volume")]
        public double Buy5Volume { get; set; }

        #endregion
    }
}
