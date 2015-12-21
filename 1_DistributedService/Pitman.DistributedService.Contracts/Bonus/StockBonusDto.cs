using Ore.Infrastructure.MarketData;
using System;
using System.Runtime.Serialization;

namespace Pitman.DistributedService.Contracts
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

        [DataMember(Name = "capitalStockBaseDate")]
        public DateTime CapitalStockBaseDate { get; set; }

        [DataMember(Name = "capitalStockBeforeDispatch")]
        public double CapitalStockBeforeDispatch { get; set; }

        [DataMember(Name = "capitalSurplusIncreaseRate")]
        public double CapitalSurplusIncreaseRate { get; set; }

        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "convertibleBondDate")]
        public DateTime ConvertibleBondDate { get; set; }

        [DataMember(Name = "dateOfDeclaration")]
        public DateTime DateOfDeclaration { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "dispatchExpiryDate")]
        public DateTime DispatchExpiryDate { get; set; }

        [DataMember(Name = "dispatchListingDate")]
        public DateTime DispatchListingDate { get; set; }

        [DataMember(Name = "dispatchPrice")]
        public double DispatchPrice { get; set; }

        [DataMember(Name = "dispatchRate")]
        public double DispatchRate { get; set; }

        [DataMember(Name = "dividendAfterTax")]
        public double DividendAfterTax { get; set; }

        [DataMember(Name = "exchangeRate")]
        public double ExchangeRate { get; set; }

        [DataMember(Name = "exdividendDate")]
        public DateTime ExdividendDate { get; set; }

        [DataMember(Name = "expirationDate")]
        public DateTime ExpirationDate { get; set; }

        [DataMember(Name = "increaseRate")]
        public double IncreaseRate { get; set; }

        [DataMember(Name = "issuingObject")]
        public string IssuingObject { get; set; }

        [DataMember(Name = "lastTradingDay")]
        public DateTime LastTradingDay { get; set; }

        [DataMember(Name = "market")]
        public Market Market { get; set; }

        [DataMember(Name = "preTaxDividend")]
        public double PreTaxDividend { get; set; }

        [DataMember(Name = "registerDate")]
        public DateTime RegisterDate { get; set; }

        [DataMember(Name = "reserveSurplusIncreaseRate")]
        public double ReserveSurplusIncreaseRate { get; set; }

        [DataMember(Name = "resolutionOfShareholdersMeetingDate")]
        public DateTime ResolutionOfShareholdersMeetingDate { get; set; }

        [DataMember(Name = "shareSplitCount")]
        public double ShareSplitCount { get; set; }

        [DataMember(Name = "shortName")]
        public string ShortName { get; set; }

        [DataMember(Name = "startOrArriveDate")]
        public DateTime StartOrArriveDate { get; set; }

        [DataMember(Name = "totalDispatch")]
        public double TotalDispatch { get; set; }

        [DataMember(Name = "transferredAllottedPrice")]
        public double TransferredAllottedPrice { get; set; }

        [DataMember(Name = "transferredAllottedRate")]
        public double TransferredAllottedRate { get; set; }

        [DataMember(Name = "type")]
        public BounsType Type { get; set; }
    }
}
