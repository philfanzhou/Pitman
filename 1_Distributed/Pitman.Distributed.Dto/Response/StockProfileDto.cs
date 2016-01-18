using Ore.Infrastructure.MarketData;
using System;
using System.Runtime.Serialization;

namespace Pitman.Distributed.Dto
{
    [DataContract(Name = "stockProfile")]
    public class StockProfileDto : IStockProfile
    {
        [DataMember(Name = "codeA")]
        public string CodeA { get; set; }

        [DataMember(Name = "shortNameA")]
        public string ShortNameA { get; set; }

        [DataMember(Name = "accountingFirm")]
        public string AccountingFirm { get; set; }

        [DataMember(Name = "area")]
        public string Area { get; set; }

        [DataMember(Name = "boardSecretary")]
        public string BoardSecretary { get; set; }

        [DataMember(Name = "businessRegistration")]
        public string BusinessRegistration { get; set; }

        [DataMember(Name = "chairman")]
        public string Chairman { get; set; }

        [DataMember(Name = "codeB")]
        public string CodeB { get; set; }

        [DataMember(Name = "codeH")]
        public string CodeH { get; set; }

        [DataMember(Name = "companyProfile")]
        public string CompanyProfile { get; set; }

        [DataMember(Name = "contactNumber")]
        public string ContactNumber { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "englishName")]
        public string EnglishName { get; set; }

        [DataMember(Name = "exchange")]
        public Market Exchange { get; set; }

        [DataMember(Name = "fax")]
        public string Fax { get; set; }

        [DataMember(Name = "fullName")]
        public string FullName { get; set; }

        [DataMember(Name = "generalManager")]
        public string GeneralManager { get; set; }

        [DataMember(Name = "independentDirectors")]
        public string IndependentDirectors { get; set; }

        [DataMember(Name = "industry")]
        public string Industry { get; set; }

        [DataMember(Name = "lawOffice")]
        public string LawOffice { get; set; }

        [DataMember(Name = "legalRepresentative")]
        public string LegalRepresentative { get; set; }

        [DataMember(Name = "numberOfEmployees")]
        public int NumberOfEmployees { get; set; }

        [DataMember(Name = "nameUsedBefore")]
        public string NameUsedBefore { get; set; }

        [DataMember(Name = "numberOfManagement")]
        public int NumberOfManagement { get; set; }

        [DataMember(Name = "officeAddress")]
        public string OfficeAddress { get; set; }

        [DataMember(Name = "primeBusiness")]
        public string PrimeBusiness { get; set; }

        [DataMember(Name = "registeredAddress")]
        public string RegisteredAddress { get; set; }

        [DataMember(Name = "registeredCapital")]
        public string RegisteredCapital { get; set; }

        [DataMember(Name = "securitiesAffairsRepresentatives")]
        public string SecuritiesAffairsRepresentatives { get; set; }

        [DataMember(Name = "shortNameB")]
        public string ShortNameB { get; set; }

        [DataMember(Name = "shortNameH")]
        public string ShortNameH { get; set; }

        [DataMember(Name = "website")]
        public string Website { get; set; }

        [DataMember(Name = "zipCode")]
        public string ZipCode { get; set; }

        [DataMember(Name = "establishmentDate")]
        private DateTimeDto establishmentDate = new DateTimeDto();
        public DateTime EstablishmentDate
        {
            get { return establishmentDate.Value; }
            set { establishmentDate.Value = value; }
        }

        [DataMember(Name = "listDate")]
        private DateTimeDto listDate = new DateTimeDto();
        public DateTime ListDate
        {
            get { return listDate.Value; }
            set { listDate.Value = value; }
        }
    }
}
