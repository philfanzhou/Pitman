using Ore.Infrastructure.MarketData;
using System.Data.Entity.ModelConfiguration;

namespace Pitman.Infrastructure.EF.Repository
{
    internal class StockProfileConfig : EntityTypeConfiguration<StockProfile>
    {
        public StockProfileConfig()
        {
            /// <summary>
            /// A股交易代码
            /// </summary>
            this.HasKey(p => p.CodeA);
            /// <summary>
            /// A股证券简称
            /// </summary>
            this.Property(p => p.ShortNameA).IsRequired().HasMaxLength(12);
            /// <summary>
            /// 公司名称
            /// </summary>
            this.Property(p => p.FullName).IsRequired().HasMaxLength(64);
            /// <summary>
            /// 公司英文名称
            /// </summary>
            this.Property(p => p.EnglishName).IsRequired().HasMaxLength(64);
            /// <summary>
            /// 曾用名
            /// </summary>
            this.Property(p => p.NameUsedBefore).IsRequired().HasMaxLength(64);
            /// <summary>
            /// B股交易代码
            /// </summary>
            this.Property(p => p.CodeB).IsRequired().HasMaxLength(12);
            /// <summary>
            /// B股证券简称
            /// </summary>
            this.Property(p => p.ShortNameB).IsRequired().HasMaxLength(12);
            /// <summary>
            /// H股交易代码
            /// </summary>
            this.Property(p => p.CodeH).IsRequired().HasMaxLength(12);
            /// <summary>
            /// B股证券简称
            /// </summary>
            this.Property(p => p.ShortNameH).IsRequired().HasMaxLength(12);
            /// <summary>
            /// 证券交易所
            /// </summary>
            this.Property(p => p.Exchange).IsRequired();
            /// <summary>
            /// 所属行业
            /// </summary>
            this.Property(p => p.Industry).IsRequired().HasMaxLength(128);
            /// <summary>
            /// 总经理
            /// </summary>
            this.Property(p => p.GeneralManager).IsRequired().HasMaxLength(16);
            /// <summary>
            /// 法人代表
            /// </summary>
            this.Property(p => p.LegalRepresentative).IsRequired().HasMaxLength(16);
            /// <summary>
            /// 董秘
            /// </summary>
            this.Property(p => p.BoardSecretary).IsRequired().HasMaxLength(16);
            /// <summary>
            /// 董事长
            /// </summary>
            this.Property(p => p.Chairman).IsRequired().HasMaxLength(16);
            /// <summary>
            /// 证券事务代表
            /// </summary>
            this.Property(p => p.SecuritiesAffairsRepresentatives).IsRequired().HasMaxLength(128);
            /// <summary>
            /// 独立董事
            /// </summary>
            this.Property(p => p.IndependentDirectors).IsRequired().HasMaxLength(64);
            /// <summary>
            /// 联系电话
            /// </summary>
            this.Property(p => p.ContactNumber).IsRequired().HasMaxLength(16);
            /// <summary>
            /// 电子信箱
            /// </summary>
            this.Property(p => p.Email).IsRequired().HasMaxLength(64);
            /// <summary>
            /// 传真
            /// </summary>
            this.Property(p => p.Fax).IsRequired().HasMaxLength(16);
            /// <summary>
            /// 公司网址
            /// </summary>
            this.Property(p => p.Website).IsRequired().HasMaxLength(64);
            /// <summary>
            /// 办公地址
            /// </summary>
            this.Property(p => p.OfficeAddress).IsRequired().HasMaxLength(128);
            /// <summary>
            /// 注册地址
            /// </summary>
            this.Property(p => p.RegisteredAddress).IsRequired().HasMaxLength(128);
            /// <summary>
            /// 区域
            /// </summary>
            this.Property(p => p.Area).IsRequired().HasMaxLength(64);
            /// <summary>
            /// 邮政编码
            /// </summary>
            this.Property(p => p.ZipCode).IsRequired().HasMaxLength(8);
            /// <summary>
            /// 注册资本(元)
            /// </summary>
            this.Property(p => p.RegisteredCapital).IsRequired().HasMaxLength(64);
            /// <summary>
            /// 工商登记
            /// </summary>
            this.Property(p => p.BusinessRegistration).IsRequired().HasMaxLength(16);
            /// <summary>
            /// 雇员人数
            /// </summary>
            this.Property(p => p.NumberOfEmployees).IsRequired();
            /// <summary>
            /// 管理人员人数
            /// </summary>
            this.Property(p => p.NumberOfManagement).IsRequired();
            /// <summary>
            /// 律师事务所
            /// </summary>
            this.Property(p => p.LawOffice).IsRequired().HasMaxLength(64);
            /// <summary>
            /// 会计师事务所
            /// </summary>
            this.Property(p => p.AccountingFirm).IsRequired().HasMaxLength(64);
            /// <summary>
            /// 公司简介
            /// </summary>
            this.Property(p => p.CompanyProfile).IsRequired().HasMaxLength(1024);
            /// <summary>
            /// 主营业务范围
            /// </summary>
            this.Property(p => p.PrimeBusiness).IsRequired().HasMaxLength(1024);
            /// <summary>
            /// 成立日期
            /// </summary>
            this.Property(p => p.EstablishmentDate).IsRequired();
            /// <summary>
            /// 上市日期
            /// </summary>
            this.Property(p => p.ListDate).IsRequired();
        }
    }
}
