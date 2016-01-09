using Ore.Infrastructure.MarketData;
using System;
using System.Runtime.Serialization;

namespace Pitman.Distributed.Dto
{
    [DataContract(Name = "stockStructure")]
    public class StockStructureDto : IStockStructure
    {
        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "dateOfChange")]
        private string dateOfChange = "1970-01-01 00:00:00";
        public DateTime DateOfChange
        {
            get { return DateTime.Parse(dateOfChange); }
            set { dateOfChange = value.ToString("yyyy-MM-dd hh:mm:ss"); }
        }

        [DataMember(Name = "dateOfDeclaration")]
        private string dateOfDeclaration = "1970-01-01 00:00:00";
        public DateTime DateOfDeclaration
        {
            get { return DateTime.Parse(dateOfDeclaration); }
            set { dateOfDeclaration = value.ToString("yyyy-MM-dd hh:mm:ss"); }
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

        [DataMember(Name = "market")]
        public Market Market { get; set; }

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

        [DataMember(Name = "shortName")]
        public string ShortName { get; set; }

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
}
