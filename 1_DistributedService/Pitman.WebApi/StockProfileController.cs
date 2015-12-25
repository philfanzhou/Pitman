using Ore.Infrastructure.MarketData;
using Pitman.Application.DataCollection;
using Pitman.DistributedService.Contracts;
using System.Web.Http;

namespace Pitman.WebApi
{
    public class StockProfileController : ApiController
    {
        public StockProfileDto Get(string stockCode)
        {
            ///*test code for communication*************************************/
            //var dto = new StockProfileDto()
            //{
            //    CodeA = "600036",
            //};
            //var result = new List<StockProfileDto>();
            //result.Add(dto);
            //return result;
            ///*test code for communication*************************************/

            return ConvertToDto(FundamentalDatasource.GetProfile(stockCode));
        }

        private static StockProfileDto ConvertToDto(IStockProfile data)
        {
            return new StockProfileDto
            {
                Chairman = data.Chairman,
                CodeA = data.CodeA,
                CodeB = data.CodeB,
                CodeH = data.CodeH,
                CompanyProfile = data.CompanyProfile,
                ContactNumber = data.ContactNumber,
                RegisteredCapital = data.RegisteredCapital,
                ZipCode = data.ZipCode,
                AccountingFirm = data.AccountingFirm,
                Area = data.Area,
                OfficeAddress = data.OfficeAddress,
                RegisteredAddress = data.RegisteredAddress,
                EstablishmentDate = data.EstablishmentDate,
                SecuritiesAffairsRepresentatives = data.SecuritiesAffairsRepresentatives,
                ShortNameA = data.ShortNameA,
                ShortNameB = data.ShortNameB,
                ShortNameH = data.ShortNameH,
                BoardSecretary = data.BoardSecretary,
                BusinessRegistration = data.BusinessRegistration,
                IndependentDirectors = data.IndependentDirectors,
                Email = data.Email,
                EnglishName = data.EnglishName,
                Exchange = data.Exchange,
                NumberOfEmployees = data.NumberOfEmployees,
                Fax = data.Fax,
                FullName = data.FullName,
                GeneralManager = data.GeneralManager,
                Industry = data.Industry,
                LawOffice = data.LawOffice,
                LegalRepresentative = data.LegalRepresentative,
                ListDate = data.ListDate,
                NameUsedBefore = data.NameUsedBefore,
                NumberOfManagement = data.NumberOfManagement,
                PrimeBusiness = data.PrimeBusiness,
                Website = data.Website
            };
        }
    }
}
