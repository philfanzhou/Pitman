using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ore.Infrastructure.MarketData.Implementation
{
    /// <summary>
    /// 指数日线行情
    /// </summary>
    public class MktIdxd
    {
        /// <summary>
        /// 指数内部编码 000001.ZICN
        /// </summary>
        public string indexID
        {
            get;
            set;
        }

        /// <summary>
        /// 交易日：2015-07-03
        /// </summary>
        public string tradeDate
        {
            get;
            set;
        }

        /// <summary>
        /// 指数代码：000001
        /// </summary>
        public string ticker
        {
            get;
            set;
        }

        /// <summary>
        /// 发布机构全称:上海证券交易所
        /// </summary>
        public string porgFullName
        {
            get;
            set;
        }

        /// <summary>
        /// 证券简称:上证综指
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
        /// 昨收盘指数
        /// </summary>
        public double preCloseIndex
        {
            get;
            set;
        }

        /// <summary>
        /// 今开盘指数
        /// </summary>
        public double openIndex
        {
            get;
            set;
        }

        /// <summary>
        /// 最低价指数
        /// </summary>
        public double lowestIndex
        {
            get;
            set;
        }

        /// <summary>
        /// 最高价指数
        /// </summary>
        public double highestIndex
        {
            get;
            set;
        }

        /// <summary>
        /// 今收盘指数
        /// </summary>
        public double closeIndex
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
        /// 涨跌
        /// </summary>
        public double CHG
        {
            get;
            set;
        }

        /// <summary>
        /// 涨跌幅
        /// </summary>
        public double CHGPct
        {
            get;
            set;
        }
    }
}
