using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ore.Infrastructure.MarketData
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
        /// 总股本（最新）
        /// </summary>
        double TotalShares { get; }

        /// <summary>
        /// 无限售流通股份合计(最新)
        /// </summary>
        double NonrestFloatShares { get; }

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
}
