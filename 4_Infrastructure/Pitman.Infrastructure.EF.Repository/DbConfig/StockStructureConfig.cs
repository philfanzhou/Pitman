using Ore.Infrastructure.MarketData;
using System.Data.Entity.ModelConfiguration;

namespace Pitman.Infrastructure.EF.Repository
{
    internal class StockStructureConfig : EntityTypeConfiguration<StockStructure>
    {
        public StockStructureConfig()
        {
            /// <summary>
            /// 变动日期
            /// </summary>
            this.HasKey(p => p.DateOfChange);
            /// <summary>
            /// 公告日期
            /// </summary>
            this.Property(p => p.DateOfDeclaration).IsRequired();
            /// <summary>
            /// 变更原因
            /// </summary>
            this.Property(p => p.Reason).IsRequired().HasMaxLength(128);

            /// <summary>
            /// 总股本
            /// </summary>
            this.Property(p => p.TotalShares).IsRequired();
            /// <summary>
            /// 流通A股
            /// </summary>
            this.Property(p => p.SharesA).IsRequired();
            /// <summary>
            /// 高管股
            /// </summary>
            this.Property(p => p.ExecutiveShares).IsRequired();
            /// <summary>
            /// 限售A股
            /// </summary>
            this.Property(p => p.RestrictedSharesA).IsRequired();
            /// <summary>
            /// 流通B股
            /// </summary>
            this.Property(p => p.SharesB).IsRequired();
            /// <summary>
            /// 限售B股
            /// </summary>
            this.Property(p => p.RestrictedSharesB).IsRequired();
            /// <summary>
            /// 流通H股
            /// </summary>
            this.Property(p => p.SharesH).IsRequired();
            /// <summary>
            /// 国家股
            /// </summary>
            this.Property(p => p.StateShares).IsRequired();
            /// <summary>
            /// 国有法人股
            /// </summary>
            this.Property(p => p.StateOwnedLegalPersonShares).IsRequired();
            /// <summary>
            /// 境内法人股
            /// </summary>
            this.Property(p => p.DomesticLegalPersonShares).IsRequired();
            /// <summary>
            /// 境内发起人股
            /// </summary>
            this.Property(p => p.DomesticSponsorsShares).IsRequired();
            /// <summary>
            /// 募集法人股
            /// </summary>
            this.Property(p => p.RaiseLegalPersonShares).IsRequired();
            /// <summary>
            /// 一般法人股
            /// </summary>
            this.Property(p => p.GeneralLegalPersonShares).IsRequired();
            /// <summary>
            /// 战略投资者持股
            /// </summary>
            this.Property(p => p.StrategicInvestorsShares).IsRequired();
            /// <summary>
            /// 基金持股
            /// </summary>
            this.Property(p => p.FundsShares).IsRequired();
            /// <summary>
            /// 转配股
            /// </summary>
            this.Property(p => p.TransferredAllottedShares).IsRequired();
            /// <summary>
            /// 内部职工股
            /// </summary>
            this.Property(p => p.InternalStaffShares).IsRequired();
            /// <summary>
            /// 优先股
            /// </summary>
            this.Property(p => p.PreferredStock).IsRequired();            
        }
    }
}
