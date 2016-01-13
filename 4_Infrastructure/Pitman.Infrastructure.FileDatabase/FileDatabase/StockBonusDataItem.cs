using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Infrastructure.MemoryMap;
using Ore.Infrastructure.MarketData;

namespace Pitman.Infrastructure.FileDatabase
{
    internal struct StockBonusDataItem : IStockBonus
    {
        public double ActualDispatchRate { get; set; }

        public double BAndHDividendAfterTax { get; set; }

        public double BAndHPreTaxDividend { get; set; }

        public double BonusRate { get; set; }

        public DateTime CapitalStockBaseDate { get; set; }

        public double CapitalStockBeforeDispatch { get; set; }

        public double CapitalSurplusIncreaseRate { get; set; }

        private String64 code;
        public string Code
        {
            get
            {
                return code.Value;
            }
            set
            {
                code.Value = value;
            }
        }

        public DateTime ConvertibleBondDate { get; set; }

        public DateTime DateOfDeclaration { get; set; }

        private String256 description;
        public string Description
        {
            get
            {
                return description.Value;
            }
            set
            {
                description.Value = value;
            }
        }

        public DateTime DispatchExpiryDate { get; set; }

        public DateTime DispatchListingDate { get; set; }

        public double DispatchPrice { get; set; }

        public double DispatchRate { get; set; }

        public double DividendAfterTax { get; set; }

        public double ExchangeRate { get; set; }

        public DateTime ExdividendDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public double IncreaseRate { get; set; }

        private String256 issuingObject;
        public string IssuingObject
        {
            get
            {
                return issuingObject.Value;
            }
            set
            {
                issuingObject.Value = value;
            }
        }

        public DateTime LastTradingDay { get; set; }

        public Market Market { get; set; }

        public double PreTaxDividend { get; set; }

        public DateTime RegisterDate { get; set; }

        public double ReserveSurplusIncreaseRate { get; set; }

        public DateTime ResolutionOfShareholdersMeetingDate { get; set; }

        public double ShareSplitCount { get; set; }

        private String256 shortName;
        /// <summary>
        /// 股票简称
        /// </summary>
        public string ShortName
        {
            get
            {
                return shortName.Value;
            }
            set
            {
                shortName.Value = value;
            }
        }

        public DateTime StartOrArriveDate { get; set; }

        public double TotalDispatch { get; set; }

        public double TransferredAllottedPrice { get; set; }

        public double TransferredAllottedRate { get; set; }

        public BounsType Type { get; set; }
    }
}
