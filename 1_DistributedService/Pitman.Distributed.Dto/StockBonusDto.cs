using Ore.Infrastructure.MarketData;
using System;
using System.Runtime.Serialization;

namespace Pitman.Distributed.Dto
{
    [DataContract(Name = "stockBonus")]
    public class StockBonusDto : IStockBonus
    {
        [DataMember(Name = "actualDispatchRate")]
        public double ActualDispatchRate { get; set; }

        [DataMember(Name = "bAndHDividendAfterTax")]
        public double BAndHDividendAfterTax { get; set; }

        [DataMember(Name = "bAndHPreTaxDividend")]
        public double BAndHPreTaxDividend { get; set; }

        [DataMember(Name = "bonusRate")]
        public double BonusRate { get; set; }

        [DataMember(Name = "capitalStockBeforeDispatch")]
        public double CapitalStockBeforeDispatch { get; set; }

        [DataMember(Name = "capitalSurplusIncreaseRate")]
        public double CapitalSurplusIncreaseRate { get; set; }

        [DataMember(Name = "dispatchPrice")]
        public double DispatchPrice { get; set; }

        [DataMember(Name = "dispatchRate")]
        public double DispatchRate { get; set; }

        [DataMember(Name = "dividendAfterTax")]
        public double DividendAfterTax { get; set; }

        [DataMember(Name = "exchangeRate")]
        public double ExchangeRate { get; set; }

        [DataMember(Name = "increaseRate")]
        public double IncreaseRate { get; set; }

        [DataMember(Name = "totalDispatch")]
        public double TotalDispatch { get; set; }

        [DataMember(Name = "transferredAllottedPrice")]
        public double TransferredAllottedPrice { get; set; }

        [DataMember(Name = "transferredAllottedRate")]
        public double TransferredAllottedRate { get; set; }

        [DataMember(Name = "shareSplitCount")]
        public double ShareSplitCount { get; set; }

        [DataMember(Name = "preTaxDividend")]
        public double PreTaxDividend { get; set; }

        [DataMember(Name = "reserveSurplusIncreaseRate")]
        public double ReserveSurplusIncreaseRate { get; set; }

        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "shortName")]
        public string ShortName { get; set; }

        [DataMember(Name = "issuingObject")]
        public string IssuingObject { get; set; }

        [DataMember(Name = "market")]
        public Market Market { get; set; }

        [DataMember(Name = "type")]
        public BounsType Type { get; set; }

        [DataMember(Name = "capitalStockBaseDate")]
        private string capitalStockBaseDate = "1970-01-01 00:00:00";
        public DateTime CapitalStockBaseDate
        {
            get { return DateTime.Parse(capitalStockBaseDate); }
            set { capitalStockBaseDate = value.ToString("yyyy-MM-dd hh:mm:ss"); }
        }

        [DataMember(Name = "convertibleBondDate")]
        private string convertibleBondDate = "1970-01-01 00:00:00";
        public DateTime ConvertibleBondDate
        {
            get { return DateTime.Parse(convertibleBondDate); }
            set { convertibleBondDate = value.ToString("yyyy-MM-dd hh:mm:ss"); }
        }

        [DataMember(Name = "dateOfDeclaration")]
        private string dateOfDeclaration = "1970-01-01 00:00:00";
        public DateTime DateOfDeclaration
        {
            get { return DateTime.Parse(dateOfDeclaration); }
            set { dateOfDeclaration = value.ToString("yyyy-MM-dd hh:mm:ss"); }
        }

        [DataMember(Name = "dispatchExpiryDate")]
        private string dispatchExpiryDate = "1970-01-01 00:00:00";
        public DateTime DispatchExpiryDate
        {
            get { return DateTime.Parse(dispatchExpiryDate); }
            set { dispatchExpiryDate = value.ToString("yyyy-MM-dd hh:mm:ss"); }
        }

        [DataMember(Name = "dispatchListingDate")]
        private string dispatchListingDate = "1970-01-01 00:00:00";
        public DateTime DispatchListingDate
        {
            get { return DateTime.Parse(dispatchListingDate); }
            set { dispatchListingDate = value.ToString("yyyy-MM-dd hh:mm:ss"); }
        }

        [DataMember(Name = "exdividendDate")]
        private string exdividendDate = "1970-01-01 00:00:00";
        public DateTime ExdividendDate
        {
            get { return DateTime.Parse(exdividendDate); }
            set { exdividendDate = value.ToString("yyyy-MM-dd hh:mm:ss"); }
        }

        [DataMember(Name = "expirationDate")]
        private string expirationDate = "1970-01-01 00:00:00";
        public DateTime ExpirationDate
        {
            get { return DateTime.Parse(expirationDate); }
            set { expirationDate = value.ToString("yyyy-MM-dd hh:mm:ss"); }
        }

        [DataMember(Name = "lastTradingDay")]
        private string lastTradingDay = "1970-01-01 00:00:00";
        public DateTime LastTradingDay
        {
            get { return DateTime.Parse(lastTradingDay); }
            set { lastTradingDay = value.ToString("yyyy-MM-dd hh:mm:ss"); }
        }

        [DataMember(Name = "registerDate")]
        private string registerDate = "1970-01-01 00:00:00";
        public DateTime RegisterDate
        {
            get { return DateTime.Parse(registerDate); }
            set { registerDate = value.ToString("yyyy-MM-dd hh:mm:ss"); }
        }

        [DataMember(Name = "resolutionOfShareholdersMeetingDate")]
        private string resolutionOfShareholdersMeetingDate = "1970-01-01 00:00:00";
        public DateTime ResolutionOfShareholdersMeetingDate
        {
            get { return DateTime.Parse(resolutionOfShareholdersMeetingDate); }
            set { resolutionOfShareholdersMeetingDate = value.ToString("yyyy-MM-dd hh:mm:ss"); }
        }

        [DataMember(Name = "startOrArriveDate")]
        private string startOrArriveDate = "1970-01-01 00:00:00";
        public DateTime StartOrArriveDate
        {
            get { return DateTime.Parse(startOrArriveDate); }
            set { startOrArriveDate = value.ToString("yyyy-MM-dd hh:mm:ss"); }
        }
    }
}
