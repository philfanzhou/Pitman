using Ore.Infrastructure.MarketData;
using System;

namespace Pitman.Infrastructure.DatabaseObject
{
    public class StockProfileDbo : IStockProfile
    {
        public string AccountingFirm { get; set; }

        public string Area { get; set; }

        public string BoardSecretary { get; set; }

        public string BusinessRegistration { get; set; }

        public string Chairman { get; set; }

        public string CodeA { get; set; }

        public string CodeB { get; set; }

        public string CodeH { get; set; }

        public string CompanyProfile { get; set; }

        public string ContactNumber { get; set; }

        public string Email { get; set; }

        public string EnglishName { get; set; }

        public DateTime EstablishmentDate { get; set; }

        public Market Exchange { get; set; }

        public string Fax { get; set; }

        public string FullName { get; set; }

        public string GeneralManager { get; set; }

        public string IndependentDirectors { get; set; }

        public string Industry { get; set; }

        public string LawOffice { get; set; }

        public string LegalRepresentative { get; set; }

        public DateTime ListDate { get; set; }

        public string NameUsedBefore { get; set; }

        public int NumberOfEmployees { get; set; }

        public int NumberOfManagement { get; set; }

        public string OfficeAddress { get; set; }

        public string PrimeBusiness { get; set; }

        public string RegisteredAddress { get; set; }

        public string RegisteredCapital { get; set; }

        public string SecuritiesAffairsRepresentatives { get; set; }

        public string ShortNameA { get; set; }

        public string ShortNameB { get; set; }

        public string ShortNameH { get; set; }

        public string Website { get; set; }

        public string ZipCode { get; set; }
    }

    public static class StockProfileConverter
    {
        public static StockProfileDbo ToDbo(this IStockProfile self)
        {
            StockProfileDbo outputData = new StockProfileDbo
            {
                AccountingFirm = self.AccountingFirm,
                Area = self.Area,
                BoardSecretary = self.BoardSecretary,
                BusinessRegistration = self.BusinessRegistration,
                Chairman = self.Chairman,
                CodeA = self.CodeA,
                CodeB = self.CodeB,
                CodeH = self.CodeH,
                CompanyProfile = self.CompanyProfile,
                ContactNumber = self.ContactNumber,
                Email = self.Email,
                EnglishName = self.EnglishName,
                EstablishmentDate = self.EstablishmentDate,
                Exchange = self.Exchange,
                Fax = self.Fax,
                FullName = self.FullName,
                GeneralManager = self.GeneralManager,
                IndependentDirectors = self.IndependentDirectors,
                Industry = self.Industry,
                LawOffice = self.LawOffice,
                LegalRepresentative = self.LegalRepresentative,
                ListDate = self.ListDate,
                NameUsedBefore = self.NameUsedBefore,
                NumberOfEmployees = self.NumberOfEmployees,
                NumberOfManagement = self.NumberOfManagement,
                OfficeAddress = self.OfficeAddress,
                PrimeBusiness = self.PrimeBusiness,
                RegisteredAddress = self.RegisteredAddress,
                RegisteredCapital = self.RegisteredCapital,
                SecuritiesAffairsRepresentatives = self.SecuritiesAffairsRepresentatives,
                ShortNameA = self.ShortNameA,
                ShortNameB = self.ShortNameB,
                ShortNameH = self.ShortNameH,
                Website = self.Website,
                ZipCode = self.ZipCode
            };

            return outputData;
        }
    }
}
