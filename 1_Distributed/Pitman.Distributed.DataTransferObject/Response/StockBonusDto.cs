using Ore.Infrastructure.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Pitman.Distributed.DataTransferObject
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

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "issuingObject")]
        public string IssuingObject { get; set; }

        [DataMember(Name = "type")]
        public BounsType Type { get; set; }

        [DataMember(Name = "capitalStockBaseDate")]
        private DateTimeDto capitalStockBaseDate = new DateTimeDto();
        public DateTime CapitalStockBaseDate
        {
            get { return capitalStockBaseDate.Value; }
            set { capitalStockBaseDate.Value = value; }
        }

        [DataMember(Name = "convertibleBondDate")]
        private DateTimeDto convertibleBondDate = new DateTimeDto();
        public DateTime ConvertibleBondDate
        {
            get { return convertibleBondDate.Value; }
            set { convertibleBondDate.Value = value; }
        }

        [DataMember(Name = "dateOfDeclaration")]
        private DateTimeDto dateOfDeclaration = new DateTimeDto();
        public DateTime DateOfDeclaration
        {
            get { return dateOfDeclaration.Value; }
            set { dateOfDeclaration.Value = value; }
        }

        [DataMember(Name = "dispatchExpiryDate")]
        private DateTimeDto dispatchExpiryDate = new DateTimeDto();
        public DateTime DispatchExpiryDate
        {
            get { return dispatchExpiryDate.Value; }
            set { dispatchExpiryDate.Value = value; }
        }

        [DataMember(Name = "dispatchListingDate")]
        private DateTimeDto dispatchListingDate = new DateTimeDto();
        public DateTime DispatchListingDate
        {
            get { return dispatchListingDate.Value; }
            set { dispatchListingDate.Value = value; }
        }

        [DataMember(Name = "exdividendDate")]
        private DateTimeDto exdividendDate = new DateTimeDto();
        public DateTime ExdividendDate
        {
            get { return exdividendDate.Value; }
            set { exdividendDate.Value = value; }
        }

        [DataMember(Name = "expirationDate")]
        private DateTimeDto expirationDate = new DateTimeDto();
        public DateTime ExpirationDate
        {
            get { return expirationDate.Value; }
            set { expirationDate.Value = value; }
        }

        [DataMember(Name = "lastTradingDay")]
        private DateTimeDto lastTradingDay = new DateTimeDto();
        public DateTime LastTradingDay
        {
            get { return lastTradingDay.Value; }
            set { lastTradingDay.Value = value; }
        }

        [DataMember(Name = "registerDate")]
        private DateTimeDto registerDate = new DateTimeDto();
        public DateTime RegisterDate
        {
            get { return registerDate.Value; }
            set { registerDate.Value = value; }
        }

        [DataMember(Name = "resolutionOfShareholdersMeetingDate")]
        private DateTimeDto resolutionOfShareholdersMeetingDate = new DateTimeDto();
        public DateTime ResolutionOfShareholdersMeetingDate
        {
            get { return resolutionOfShareholdersMeetingDate.Value; }
            set { resolutionOfShareholdersMeetingDate.Value = value; }
        }

        [DataMember(Name = "startOrArriveDate")]
        private DateTimeDto startOrArriveDate = new DateTimeDto();
        public DateTime StartOrArriveDate
        {
            get { return startOrArriveDate.Value; }
            set { startOrArriveDate.Value = value; }
        }
    }

    public static class StockBonusConverter
    {
        public static IEnumerable<StockBonusDto> ToDto(this IEnumerable<IStockBonus> self)
        {
            return self.Select(p => p.ToDto());
        }

        public static StockBonusDto ToDto(this IStockBonus self)
        {
            StockBonusDto outputData = new StockBonusDto
            {
                ActualDispatchRate = self.ActualDispatchRate,
                BAndHDividendAfterTax = self.BAndHDividendAfterTax,
                BAndHPreTaxDividend = self.BAndHPreTaxDividend,
                BonusRate = self.BonusRate,
                CapitalStockBaseDate = self.CapitalStockBaseDate,
                CapitalStockBeforeDispatch = self.CapitalStockBeforeDispatch,
                CapitalSurplusIncreaseRate = self.CapitalSurplusIncreaseRate,
                ConvertibleBondDate = self.ConvertibleBondDate,
                DateOfDeclaration = self.DateOfDeclaration,
                Description = self.Description,
                DispatchExpiryDate = self.DispatchExpiryDate,
                DispatchListingDate = self.DispatchListingDate,
                DispatchPrice = self.DispatchPrice,
                DispatchRate = self.DispatchRate,
                DividendAfterTax = self.DividendAfterTax,
                ExchangeRate = self.ExchangeRate,
                ExdividendDate = self.ExdividendDate,
                ExpirationDate = self.ExpirationDate,
                IncreaseRate = self.IncreaseRate,
                IssuingObject = self.IssuingObject,
                LastTradingDay = self.LastTradingDay,
                PreTaxDividend = self.PreTaxDividend,
                RegisterDate = self.RegisterDate,
                ReserveSurplusIncreaseRate = self.ReserveSurplusIncreaseRate,
                ResolutionOfShareholdersMeetingDate = self.ResolutionOfShareholdersMeetingDate,
                ShareSplitCount = self.ShareSplitCount,
                StartOrArriveDate = self.StartOrArriveDate,
                TotalDispatch = self.TotalDispatch,
                TransferredAllottedPrice = self.TransferredAllottedPrice,
                TransferredAllottedRate = self.TransferredAllottedRate,
                Type = self.Type
            };

            return outputData;
        }
    }
}
