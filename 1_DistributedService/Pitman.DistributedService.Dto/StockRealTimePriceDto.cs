﻿using System;
using System.Runtime.Serialization;

namespace Pitman.DistributedService.Dto
{
    [DataContract(Name = "stockRealTimePriceDto")]
    public class StockRealTimePriceDto
    {
        /// <summary>
        /// 交易代码
        /// </summary>
        [DataMember(Name = "code")]
        public string Code { get; set; }

        /// <summary>
        /// 股票简称
        /// </summary>
        [DataMember]
        public string ShortName { get; set; }

        /// <summary>
        /// 交易市场
        /// </summary>
        [DataMember]
        public MarketDto Market { get; set; }

        /// <summary>
        /// 今开
        /// </summary>
        [DataMember]
        public double TodayOpen { get; set; }

        /// <summary>
        /// 昨收
        /// </summary>
        [DataMember]
        public double YesterdayClose { get; set; }

        /// <summary>
        /// 当前成交价
        /// </summary>
        [DataMember]
        public double Current { get; set; }

        /// <summary>
        /// 最高
        /// </summary>
        [DataMember]
        public double High { get; set; }

        /// <summary>
        /// 最低
        /// </summary>
        [DataMember]
        public double Low { get; set; }

        /// <summary>
        /// 成交量
        /// </summary>
        [DataMember]
        public double Volume { get; set; }

        /// <summary>
        /// 成交额
        /// </summary>
        [DataMember]
        public double Amount { get; set; }

        [DataMember(Name = "time")]
        private string time = "1970-01-01 00:00:00";
        /// <summary>
        /// 日期与时间
        /// </summary>
        public DateTime Time
        {
            get { return DateTime.Parse(time); }
            set { time = value.ToString("yyyy-MM-dd hh:mm:ss"); }
        }

        #region 卖盘

        /// <summary>
        /// 卖五价
        /// </summary>
        [DataMember]
        public double Sell5Price { get; set; }

        /// <summary>
        /// 卖五量
        /// </summary>
        [DataMember]
        public double Sell5Volume { get; set; }

        /// <summary>
        /// 卖四价
        /// </summary>
        [DataMember]
        public double Sell4Price { get; set; }

        /// <summary>
        /// 卖四量
        /// </summary>
        [DataMember]
        public double Sell4Volume { get; set; }

        /// <summary>
        /// 卖三价
        /// </summary>
        [DataMember]
        public double Sell3Price { get; set; }

        /// <summary>
        /// 卖三量
        /// </summary>
        [DataMember]
        public double Sell3Volume { get; set; }

        /// <summary>
        /// 卖二价
        /// </summary>
        [DataMember]
        public double Sell2Price { get; set; }

        /// <summary>
        /// 卖二量
        /// </summary>
        [DataMember]
        public double Sell2Volume { get; set; }

        /// <summary>
        /// 卖一价
        /// </summary>
        [DataMember]
        public double Sell1Price { get; set; }

        /// <summary>
        /// 卖一量
        /// </summary>
        [DataMember]
        public double Sell1Volume { get; set; }

        #endregion

        #region 买盘

        /// <summary>
        /// 买一价
        /// </summary>
        [DataMember]
        public double Buy1Price { get; set; }

        /// <summary>
        /// 买一量
        /// </summary>
        [DataMember]
        public double Buy1Volume { get; set; }

        /// <summary>
        /// 买二价
        /// </summary>
        [DataMember]
        public double Buy2Price { get; set; }

        /// <summary>
        /// 买二量
        /// </summary>
        [DataMember]
        public double Buy2Volume { get; set; }

        /// <summary>
        /// 买三价
        /// </summary>
        [DataMember]
        public double Buy3Price { get; set; }

        /// <summary>
        /// 买三量
        /// </summary>
        [DataMember]
        public double Buy3Volume { get; set; }

        /// <summary>
        /// 买四价
        /// </summary>
        [DataMember]
        public double Buy4Price { get; set; }

        /// <summary>
        /// 买四量
        /// </summary>
        [DataMember]
        public double Buy4Volume { get; set; }

        /// <summary>
        /// 买五价
        /// </summary>
        [DataMember]
        public double Buy5Price { get; set; }

        /// <summary>
        /// 买五量
        /// </summary>
        [DataMember]
        public double Buy5Volume { get; set; }

        #endregion
    }
}
