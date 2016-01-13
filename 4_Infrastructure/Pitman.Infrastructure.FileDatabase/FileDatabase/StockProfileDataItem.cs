using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Infrastructure.MemoryMap;
using Ore.Infrastructure.MarketData;

namespace Pitman.Infrastructure.FileDatabase
{
    internal struct StockProfileDataItem : IStockProfile
    {
        private String256 fullName; 
        /// <summary>
        /// 公司名称
        /// </summary>
        public string FullName
        {
            get
            {
                return fullName.Value;
            }
            set
            {
                fullName.Value = value;
            }
        }
        private String256 englishName; 
        /// <summary>
        /// 公司英文名称
        /// </summary>
        public string EnglishName
        {
            get
            {
                return englishName.Value;
            }
            set
            {
                englishName.Value = value;
            }
        }
        private String256 nameUsedBefore; 
        /// <summary>
        /// 曾用名
        /// </summary>
        public string NameUsedBefore
        {
            get
            {
                return nameUsedBefore.Value;
            }
            set
            {
                nameUsedBefore.Value = value;
            }
        }

        private String64 codeA;
        /// <summary>
        /// A股交易代码
        /// </summary>
        public string CodeA
        {
            get
            {
                return codeA.Value;
            }
            set
            {
                codeA.Value = value;
            }
        }
        private String256 shortNameA;
        /// <summary>
        /// A股证券简称
        /// </summary>
        public string ShortNameA
        {
            get
            {
                return shortNameA.Value;
            }
            set
            {
                shortNameA.Value = value;
            }
        }
        private String64 codeB;
        /// <summary>
        /// B股交易代码
        /// </summary>
        public string CodeB
        {
            get
            {
                return codeB.Value;
            }
            set
            {
                codeB.Value = value;
            }
        }
        private String256 shortNameB;
        /// <summary>
        /// B股证券简称
        /// </summary>
        public string ShortNameB
        {
            get
            {
                return shortNameB.Value;
            }
            set
            {
                shortNameB.Value = value;
            }
        }
        private String64 codeH;
        /// <summary>
        /// H股交易代码
        /// </summary>
        public string CodeH
        {
            get
            {
                return codeH.Value;
            }
            set
            {
                codeH.Value = value;
            }
        }
        private String256 shortNameH;
        /// <summary>
        /// B股证券简称
        /// </summary>
        public string ShortNameH
        {
            get
            {
                return shortNameH.Value;
            }
            set
            {
                shortNameH.Value = value;
            }
        }
        /// <summary>
        /// 证券交易所
        /// </summary>
        public Market Exchange { get; set; }
        private String256 industry; 
        /// <summary>
        /// 所属行业
        /// </summary>
        public string Industry
        {
            get
            {
                return industry.Value;
            }
            set
            {
                industry.Value = value;
            }
        }
        private String256 generalManager;
        /// <summary>
        /// 总经理
        /// </summary>
        public string GeneralManager
        {
            get
            {
                return generalManager.Value;
            }
            set
            {
                generalManager.Value = value;
            }
        }
        private String256 legalRepresentative;
        /// <summary>
        /// 法人代表
        /// </summary>
        public string LegalRepresentative
        {
            get
            {
                return legalRepresentative.Value;
            }
            set
            {
                legalRepresentative.Value = value;
            }
        }
        private String256 boardSecretary;
        /// <summary>
        /// 董秘
        /// </summary>
        public string BoardSecretary
        {
            get
            {
                return boardSecretary.Value;
            }
            set
            {
                boardSecretary.Value = value;
            }
        }
        private String256 chairman;
        /// <summary>
        /// 董事长
        /// </summary>
        public string Chairman
        {
            get
            {
                return chairman.Value;
            }
            set
            {
                chairman.Value = value;
            }
        }
        private String256 securitiesAffairsRepresentatives;
        /// <summary>
        /// 证券事务代表
        /// </summary>
        public string SecuritiesAffairsRepresentatives
        {
            get
            {
                return securitiesAffairsRepresentatives.Value;
            }
            set
            {
                securitiesAffairsRepresentatives.Value = value;
            }
        }
        private String256 independentDirectors;
        /// <summary>
        /// 独立董事
        /// </summary>
        public string IndependentDirectors
        {
            get
            {
                return independentDirectors.Value;
            }
            set
            {
                independentDirectors.Value = value;
            }
        }
        private String256 contactNumber;
        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactNumber
        {
            get
            {
                return contactNumber.Value;
            }
            set
            {
                contactNumber.Value = value;
            }
        }
        private String256 email;
        /// <summary>
        /// 电子信箱
        /// </summary>
        public string Email
        {
            get
            {
                return email.Value;
            }
            set
            {
                email.Value = value;
            }
        }
        private String256 fax;
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax
        {
            get
            {
                return fax.Value;
            }
            set
            {
                fax.Value = value;
            }
        }
        private String256 website;
        /// <summary>
        /// 公司网址
        /// </summary>
        public string Website
        {
            get
            {
                return website.Value;
            }
            set
            {
                website.Value = value;
            }
        }
        private String256 officeAddress;
        /// <summary>
        /// 办公地址
        /// </summary>
        public string OfficeAddress
        {
            get
            {
                return officeAddress.Value;
            }
            set
            {
                officeAddress.Value = value;
            }
        }
        private String256 registeredAddress;
        /// <summary>
        /// 注册地址
        /// </summary>
        public string RegisteredAddress
        {
            get
            {
                return registeredAddress.Value;
            }
            set
            {
                registeredAddress.Value = value;
            }
        }
        private String256 area;
        /// <summary>
        /// 区域
        /// </summary>
        public string Area
        {
            get
            {
                return area.Value;
            }
            set
            {
                area.Value = value;
            }
        }
        private String256 zipCode;
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string ZipCode
        {
            get
            {
                return zipCode.Value;
            }
            set
            {
                zipCode.Value = value;
            }
        }
        private String256 registeredCapital;
        /// <summary>
        /// 注册资本(元)
        /// </summary>
        public string RegisteredCapital
        {
            get
            {
                return registeredCapital.Value;
            }
            set
            {
                registeredCapital.Value = value;
            }
        }
        private String256 businessRegistration;
        /// <summary>
        /// 工商登记
        /// </summary>
        public string BusinessRegistration
        {
            get
            {
                return businessRegistration.Value;
            }
            set
            {
                businessRegistration.Value = value;
            }
        }
        /// <summary>
        /// 雇员人数
        /// </summary>
        public int NumberOfEmployees { get; set; }
        /// <summary>
        /// 管理人员人数
        /// </summary>
        public int NumberOfManagement { get; set; }
        private String256 lawOffice;
        /// <summary>
        /// 律师事务所
        /// </summary>
        public string LawOffice
        {
            get
            {
                return lawOffice.Value;
            }
            set
            {
                lawOffice.Value = value;
            }
        }
        private String256 accountingFirm;
        /// <summary>
        /// 会计师事务所
        /// </summary>
        public string AccountingFirm
        {
            get
            {
                return accountingFirm.Value;
            }
            set
            {
                accountingFirm.Value = value;
            }
        }
        private String256 companyProfile;
        /// <summary>
        /// 公司简介
        /// </summary>
        public string CompanyProfile
        {
            get
            {
                return companyProfile.Value;
            }
            set
            {
                companyProfile.Value = value;
            }
        }
        private String256 primeBusiness;
        /// <summary>
        /// 主营业务范围
        /// </summary>
        public string PrimeBusiness
        {
            get
            {
                return primeBusiness.Value;
            }
            set
            {
                primeBusiness.Value = value;
            }
        }
        /// <summary>
        /// 成立日期
        /// </summary>
        public DateTime EstablishmentDate { get; set; }
        /// <summary>
        /// 上市日期
        /// </summary>
        public DateTime ListDate { get; set; }
    }
}
