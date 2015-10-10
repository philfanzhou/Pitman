using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ore.Infrastructure.MarketData.Implementation
{
    /// <summary>
    /// 沪深股票日线行情
    /// </summary>
    public class MktEqud
    {
        /// <summary>
        /// 证券内部编码 600726.XSHG
        /// </summary>
        public string secID
        {
            get;
            set;
        }

        /// <summary>
        /// 交易日 2015-06-26
        /// </summary>
        public string tradeDate
        {
            get;
            set;
        }

        /// <summary>
        /// 证券代码 600726
        /// </summary>
        public string ticker
        {
            get;
            set;
        }

        /// <summary>
        /// 证券简称 华电能源
        /// </summary>
        public string secShortName
        {
            get;
            set;
        }

        /// <summary>
        /// 交易所代码 XSHG
        /// </summary>
        public string exchangeCD
        {
            get;
            set;
        }

        /// <summary>
        /// 昨收盘：已除权后的价格
        /// </summary>
        public float preClosePrice
        {
            get;
            set;
        }

        /// <summary>
        /// 实际昨收盘：未除权
        /// </summary>
        public float actPreClosePrice
        {
            get;
            set;
        }

        /// <summary>
        /// 今开盘
        /// </summary>
        public float openPrice
        {
            get;
            set;
        }

        /// <summary>
        /// 最高价
        /// </summary>
        public float highestPrice
        {
            get;
            set;
        }

        /// <summary>
        /// 最低价
        /// </summary>
        public float lowestPrice
        {
            get;
            set;
        }

        /// <summary>
        /// 今收盘
        /// </summary>
        public float closePrice
        {
            get;
            set;
        }

        /// <summary>
        /// 成交量
        /// </summary>
        public double turnoverVol
        {
            get;
            set;
        }

        /// <summary>
        /// 成交金额
        /// </summary>
        public double turnoverValue
        {
            get;
            set;
        }

        /// <summary>
        /// 成交笔数
        /// </summary>
        public double dealAmount
        {
            get;
            set;
        }

        /// <summary>
        /// 日换手率
        /// </summary>
        public float turnoverRate
        {
            get;
            set;
        }

        /// <summary>
        /// 累积复权因子：前复权
        /// </summary>
        public float accumAdjFactor
        {
            get;
            set;
        }

        /// <summary>
        /// 流通市值
        /// </summary>
        public double negMarketValue
        {
            get;
            set;
        }

        /// <summary>
        /// 总市值
        /// </summary>
        public double marketValue
        {
            get;
            set;
        }

        /// <summary>
        /// 滚动市盈率
        /// </summary>
        public float PE
        {
            get;
            set;
        }

        /// <summary>
        /// 市盈率
        /// </summary>
        public float PE1
        {
            get;
            set;
        }

        /// <summary>
        /// 市净率
        /// </summary>
        public float PB
        {
            get;
            set;
        }
    }
}
