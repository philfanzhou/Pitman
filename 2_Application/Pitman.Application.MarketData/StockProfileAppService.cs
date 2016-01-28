using Framework.Infrastructure.Repository;
using Ore.Infrastructure.MarketData;
using Pitman.Domain.FileStructure;
using Pitman.Infrastructure.DatabaseObject;
using Pitman.Infrastructure.EF.Repository;
using System.Collections.Generic;

namespace Pitman.Application.MarketData
{
    public class StockProfileAppService
    {
        public bool Exists(IStockProfile stockProfile)
        {
            // 设置查询条件
            var spec = Specification<StockProfileDbo>.Eval(p => p.CodeA.Equals(stockProfile.CodeA));

            using (var context = GetContext())
            {
                var repository = new Repository<StockProfileDbo>(context);
                return repository.Exists(spec);
            }
        }

        public void Add(IStockProfile stockProfile)
        {
            using (var context = GetContext())
            {
                var repository = new Repository<StockProfileDbo>(context);
                repository.Add(ConvertToDbo(stockProfile));
                repository.UnitOfWork.Commit();
            }
        }

        public void Update(IStockProfile stockProfile)
        {
            using (var context = GetContext())
            {
                var repository = new Repository<StockProfileDbo>(context);
                repository.Update(ConvertToDbo(stockProfile));
                repository.UnitOfWork.Commit();
            }
        }

        public IEnumerable<IStockProfile> GetAll()
        {
            using (var context = GetContext())
            {
                var repository = new Repository<StockProfileDbo>(context);
                return repository.GetAll();
            }
        }

        private IRepositoryContext GetContext()
        {
            string fullPath = DataFiles.GetStockProfileFile();
            IRepositoryContext context
                = ContextFactory.Create(ContextType.StockProfile, fullPath);

            return context;
        }

        private static StockProfileDbo ConvertToDbo(IStockProfile self)
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
