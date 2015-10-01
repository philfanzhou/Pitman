using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Infrastructure.MarketData.API
{
    /// <summary>
    /// 股票基本信息
    /// </summary>
    public class BasicInfo
    {
        /// <summary>
        /// 证券内部编码
        /// </summary>
        public string secID
        {
            get;
            set;
        }

        /// <summary>
        /// 交易代码
        /// </summary>
        public string ticker
        {
            get;
            set;
        }

        /// <summary>
        /// 交易市场
        /// </summary>
        public string exchangeCD
        {
            get;
            set;
        }

        /// <summary>
        /// 上市板块编码
        /// </summary>
        public string ListSectorCD
        {
            get;
            set;
        }

        /// <summary>
        /// 上市板块
        /// </summary>
        public string ListSector
        {
            get;
            set;
        }

        /// <summary>
        /// 交易货币
        /// </summary>
        public string transCurrCD
        {
            get;
            set;
        }

        /// <summary>
        /// 证券简称
        /// </summary>
        public string secShortName
        {
            get;
            set;
        }

        /// <summary>
        /// 证券全称
        /// </summary>
        public string secFullName
        {
            get;
            set;
        }

        /// <summary>
        /// 上市状态
        /// </summary>
        public string listStatusCD
        {
            get;
            set;
        }

        /// <summary>
        /// 上市时间
        /// </summary>
        public string listDate
        {
            get;
            set;
        }

        /// <summary>
        /// 摘牌时间
        /// </summary>
        public string delistDate
        {
            get;
            set;
        }

        /// <summary>
        /// 股票分类编码
        /// </summary>
        public string equTypeCD
        {
            get;
            set;
        }

        /// <summary>
        /// 股票类别
        /// </summary>
        public string equType
        {
            get;
            set;
        }

        /// <summary>
        /// 交易市场所属地区
        /// </summary>
        public string exCountryCD
        {
            get;
            set;
        }

        /// <summary>
        /// 机构内部ID
        /// </summary>
        public string partyID
        {
            get;
            set;
        }

        /// <summary>
        /// 总股本(最新)
        /// </summary>
        public double totalShares
        {
            get;
            set;
        }

        /// <summary>
        /// 公司无限售流通股份合计(最新)
        /// </summary>
        public double nonrestFloatShares
        {
            get;
            set;
        }

        /// <summary>
        /// 无限售流通股本(最新)。如果为A股，该列为最新无限售流通A股股本数量；如果为B股，该列为最新流通B股股本数量
        /// </summary>
        public double nonrestfloatA
        {
            get;
            set;
        }

        /// <summary>
        /// 办公地址
        /// </summary>
        public string officeAddr
        {
            get;
            set;
        }

        /// <summary>
        /// 主营业务范围
        /// </summary>
        public string primeOperating
        {
            get;
            set;
        }
    }
}
