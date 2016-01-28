using Ore.Infrastructure.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Pitman.Distributed.DataTransferObject
{
    [DataContract(Name = "stockStructure")]
    public class StockStructureDto : IStockStructure
    {
        [DataMember(Name = "dateOfChange")]
        private DateTimeDto dateOfChange = new DateTimeDto();
        public DateTime DateOfChange
        {
            get { return dateOfChange.Value; }
            set { dateOfChange.Value = value; }
        }

        [DataMember(Name = "dateOfDeclaration")]
        private DateTimeDto dateOfDeclaration = new DateTimeDto();
        public DateTime DateOfDeclaration
        {
            get { return dateOfDeclaration.Value; }
            set { dateOfDeclaration.Value = value; }
        }

        [DataMember(Name = "domesticLegalPersonShares")]
        public double DomesticLegalPersonShares { get; set; }

        [DataMember(Name = "domesticSponsorsShares")]
        public double DomesticSponsorsShares { get; set; }

        [DataMember(Name = "executiveShares")]
        public double ExecutiveShares { get; set; }

        [DataMember(Name = "fundsShares")]
        public double FundsShares { get; set; }

        [DataMember(Name = "generalLegalPersonShares")]
        public double GeneralLegalPersonShares { get; set; }

        [DataMember(Name = "internalStaffShares")]
        public double InternalStaffShares { get; set; }

        [DataMember(Name = "preferredStock")]
        public double PreferredStock { get; set; }

        [DataMember(Name = "raiseLegalPersonShares")]
        public double RaiseLegalPersonShares { get; set; }

        [DataMember(Name = "reason")]
        public string Reason { get; set; }

        [DataMember(Name = "restrictedSharesA")]
        public double RestrictedSharesA { get; set; }

        [DataMember(Name = "restrictedSharesB")]
        public double RestrictedSharesB { get; set; }

        [DataMember(Name = "sharesA")]
        public double SharesA { get; set; }

        [DataMember(Name = "sharesB")]
        public double SharesB { get; set; }

        [DataMember(Name = "sharesH")]
        public double SharesH { get; set; }

        [DataMember(Name = "stateOwnedLegalPersonShares")]
        public double StateOwnedLegalPersonShares { get; set; }

        [DataMember(Name = "stateShares")]
        public double StateShares { get; set; }

        [DataMember(Name = "strategicInvestorsShares")]
        public double StrategicInvestorsShares { get; set; }

        [DataMember(Name = "TtotalShares")]
        public double TotalShares { get; set; }

        [DataMember(Name = "transferredAllottedShares")]
        public double TransferredAllottedShares { get; set; }
    }

    public static class StockStructureConverter
    {
        public static IEnumerable<StockStructureDto> ToDto(this IEnumerable<IStockStructure> self)
        {
            return self.Select(p => p.ToDto());
        }

        public static StockStructureDto ToDto(this IStockStructure self)
        {
            StockStructureDto outputData = new StockStructureDto
            {
                DateOfChange = self.DateOfChange,
                DateOfDeclaration = self.DateOfDeclaration,
                DomesticLegalPersonShares = self.DomesticLegalPersonShares,
                DomesticSponsorsShares = self.DomesticSponsorsShares,
                ExecutiveShares = self.ExecutiveShares,
                FundsShares = self.FundsShares,
                GeneralLegalPersonShares = self.GeneralLegalPersonShares,
                InternalStaffShares = self.InternalStaffShares,
                PreferredStock = self.PreferredStock,
                RaiseLegalPersonShares = self.RaiseLegalPersonShares,
                Reason = self.Reason,
                RestrictedSharesA = self.RestrictedSharesA,
                RestrictedSharesB = self.RestrictedSharesB,
                SharesA = self.SharesA,
                SharesB = self.SharesB,
                SharesH = self.SharesH,
                StateOwnedLegalPersonShares = self.StateOwnedLegalPersonShares,
                StateShares = self.StateShares,
                StrategicInvestorsShares = self.StrategicInvestorsShares,
                TotalShares = self.TotalShares,
                TransferredAllottedShares = self.TransferredAllottedShares
            };

            return outputData;
        }
    }
}
