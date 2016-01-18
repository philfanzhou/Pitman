using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ore.Infrastructure.MarketData;

namespace Pitman.Infrastructure.EF.Repository
{
    internal class StockBonusConfig : EntityTypeConfiguration<StockBonusDbo>
    {
        public StockBonusConfig()
        {
            /// <summary>
            /// 公告日期
            /// </summary>
            this.HasKey(p => p.DateOfDeclaration);
            /// <summary>
            /// 分红配股类型
            /// </summary>
            this.Property(p => p.Type).IsRequired();
            /// <summary>
            /// 除权除息日
            /// </summary>
            this.Property(p => p.ExdividendDate).IsRequired();
            /// <summary>
            /// 股权登记日
            /// </summary>
            this.Property(p => p.RegisterDate).IsRequired();

            /// <summary>
            /// 税前红利（10派）（报价币种）
            /// </summary>
            this.Property(p => p.PreTaxDividend).IsRequired();
            /// <summary>
            /// 税后红利（10派）（报价币种）
            /// </summary>
            this.Property(p => p.DividendAfterTax).IsRequired();
            /// <summary>
            /// B、H股税前红利（人民币）
            /// </summary>
            this.Property(p => p.BAndHPreTaxDividend).IsRequired();
            /// <summary>
            /// B、H股税后红利（人民币）
            /// </summary>
            this.Property(p => p.BAndHDividendAfterTax).IsRequired();
            /// <summary>
            /// 送股比例（10送）
            /// </summary>
            this.Property(p => p.BonusRate).IsRequired();
            /// <summary>
            /// 转增比例（10转增）
            /// </summary>
            this.Property(p => p.IncreaseRate).IsRequired();
            /// <summary>
            /// 盈余公积金转增比例（10转增）
            /// </summary>
            this.Property(p => p.ReserveSurplusIncreaseRate).IsRequired();
            /// <summary>
            /// 资本公积金转增比例（10转增）
            /// </summary>
            this.Property(p => p.CapitalSurplusIncreaseRate).IsRequired();
            /// <summary>
            /// 发放对象string
            /// </summary>
            this.Property(p => p.IssuingObject).IsRequired().HasMaxLength(64);
            /// <summary>
            /// 股本基准日
            /// </summary>
            this.Property(p => p.CapitalStockBaseDate).IsRequired();
            /// <summary>
            /// 最后交易日
            /// </summary>
            this.Property(p => p.LastTradingDay).IsRequired();

            /// <summary>
            /// 红利/配股起始日（送、转股到账日)
            /// </summary>
            this.Property(p => p.StartOrArriveDate).IsRequired();
            /// <summary>
            /// 红利/配股终止日
            /// </summary>
            this.Property(p => p.ExpirationDate).IsRequired();
            /// <summary>
            /// 股东大会决议公告日期
            /// </summary>
            this.Property(p => p.ResolutionOfShareholdersMeetingDate).IsRequired();
            /// <summary>
            /// 可转债享受权益转股截止日
            /// </summary>
            this.Property(p => p.ConvertibleBondDate).IsRequired();

            /// <summary>
            /// 配股上市日
            /// </summary>
            this.Property(p => p.DispatchListingDate).IsRequired();
            /// <summary>
            /// 配股比例（10配）
            /// </summary>
            this.Property(p => p.DispatchRate).IsRequired();
            /// <summary>
            /// 配股价
            /// </summary>
            this.Property(p => p.DispatchPrice).IsRequired();
            /// <summary>
            /// 转配比例
            /// </summary>
            this.Property(p => p.TransferredAllottedRate).IsRequired();
            /// <summary>
            /// 转配价
            /// </summary>
            this.Property(p => p.TransferredAllottedPrice).IsRequired();
            /// <summary>
            /// 配股有效期
            /// </summary>
            this.Property(p => p.DispatchExpiryDate).IsRequired();
            /// <summary>
            /// 实际配股数 (万股)
            /// </summary>
            this.Property(p => p.TotalDispatch).IsRequired();
            /// <summary>
            /// 配股前总股本 (万股)
            /// </summary>
            this.Property(p => p.CapitalStockBeforeDispatch).IsRequired();
            /// <summary>
            /// 实际配股比例
            /// </summary>
            this.Property(p => p.ActualDispatchRate).IsRequired();
            /// <summary>
            /// 每股拆细数
            /// </summary>
            this.Property(p => p.ShareSplitCount).IsRequired();
            /// <summary>
            /// 外币折算汇率
            /// </summary>
            this.Property(p => p.ExchangeRate).IsRequired();

            /// <summary>
            /// 权息说明string
            /// </summary>
            this.Property(p => p.Description).IsRequired().HasMaxLength(64);
        }
    }
}
