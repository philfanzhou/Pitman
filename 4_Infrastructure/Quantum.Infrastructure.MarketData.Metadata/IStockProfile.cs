using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Infrastructure.MarketData.Metadata
{
    /// <summary>
    /// 定义证券基本信息接口
    /// </summary>
    public interface ISecurityProfile
    {
        /// <summary>
        /// 证券编码
        /// </summary>
        string SecurityID { get; }

        /// <summary>
        /// 交易代码
        /// </summary>
        string SecurityCode { get; }

        /// <summary>
        /// 证券交易所
        /// </summary>
        Exchange Exchange { get; }

        /// <summary>
        /// 交易货币
        /// </summary>
        Currency Currency { get; }

        /// <summary>
        /// 证券简称
        /// </summary>
        string ShortName { get; }

        /// <summary>
        /// 证券全称
        /// </summary>
        string FullName { get; }

        /// <summary>
        /// 上市状态
        /// </summary>
        ListStatus ListStatus { get; }

        /// <summary>
        /// 上市日期
        /// </summary>
        DateTime ListDate { get; }

        /// <summary>
        /// 摘牌日期
        /// </summary>
        DateTime DelistDate { get; }

        /// <summary>
        /// 交易市场所属地区
        /// </summary>
        ExchangeCountry ExchangeCountry { get; }

        /// <summary>
        /// 总股本（最新）
        /// </summary>
        double TotalShares { get; }

        /// <summary>
        /// 办公地址
        /// </summary>
        string OfficeAddress { get; }

        /// <summary>
        /// 主营业务范围
        /// </summary>
        string PrimeBusiness { get; }

        /// <summary>
        /// 财报日期
        /// </summary>
        DateTime FinancialReportDate { get; }

        /// <summary>
        /// 所有者权益合计
        /// </summary>
        double ShareholderEquity { get; }
    }

    /// <summary>
    /// 交易所枚举
    /// </summary>
    public enum Exchange
    {
        /// <summary>
        /// 上海证券交易所
        /// </summary>
        XSHG = 1,

        /// <summary>
        /// 深圳证券交易所
        /// </summary>
        XSHE = 2,

        /// <summary>
        /// 中国金融期货交易所
        /// </summary>
        CCFX = 3,

        /// <summary>
        /// 大连商品交易所
        /// </summary>
        XDCE = 4,

        /// <summary>
        /// 上海期货交易所
        /// </summary>
        XSGE = 5,

        /// <summary>
        /// 郑州商品交易所
        /// </summary>
        XZCE = 6,

        /// <summary>
        /// 香港证券交易所
        /// </summary>
        XHKG = 7
    }

    /// <summary>
    /// 交易货币枚举
    /// </summary>
    public enum Currency
    {
        /// <summary>
        /// 人民币
        /// </summary>
        CNY = 1
    }

    /// <summary>
    /// 上市状态枚举
    /// </summary>
    public enum ListStatus
    {
        /// <summary>
        /// 上市
        /// </summary>
        List = 1,

        /// <summary>
        /// 暂停
        /// </summary>
        suspend = 2,

        /// <summary>
        /// 摘牌
        /// </summary>
        Delist = 3,

        /// <summary>
        /// 未上市
        /// </summary>
        Unlisted = 4
    }

    /// <summary>
    /// 交易市场所属地区
    /// </summary>
    public enum ExchangeCountry
    {
        /// <summary>
        /// 中国大陆
        /// </summary>
        CHN = 1
    }
}
