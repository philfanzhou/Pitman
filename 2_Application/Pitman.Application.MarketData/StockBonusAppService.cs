using Framework.Infrastructure.Repository;
using Ore.Infrastructure.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitman.Domain.FileStructure;
using Pitman.Infrastructure.EF.Repository;

namespace Pitman.Application.MarketData
{
    public class StockBonusAppService
    {
        public bool Exists(string stockCode, IStockBonus stockBonus)
        {
            // 设置查询条件
            var spec = Specification<StockBonusDbo>.Eval(p => p.DateOfDeclaration.Equals(stockBonus.DateOfDeclaration));

            using (var context = GetContext(stockCode))
            {
                var repository = new Repository<StockBonusDbo>(context);
                return repository.Exists(spec);
            }
        }

        public void Add(string stockCode, IStockBonus stockBonus)
        {
            using (var context = GetContext(stockCode))
            {
                var repository = new Repository<StockBonusDbo>(context);
                repository.Add(ConvertToDbo(stockBonus));
                repository.UnitOfWork.Commit();
            }
        }

        public void Update(string stockCode, IStockBonus stockBonus)
        {
            using (var context = GetContext(stockCode))
            {
                var repository = new Repository<StockBonusDbo>(context);
                repository.Update(ConvertToDbo(stockBonus));
                repository.UnitOfWork.Commit();
            }
        }

        public IEnumerable<IStockBonus> Get(string stockCode)
        {
            using (var context = GetContext(stockCode))
            {
                var repository = new Repository<StockBonusDbo>(context);
                return repository.GetAll();
            }
        }

        private IRepositoryContext GetContext(string stockCode)
        {
            string fullPath = DataFiles.GetStockBonusFile(stockCode);
            IRepositoryContext context
                = ContextFactory.Create(ContextType.StockBonus, fullPath);

            return context;
        }

        private static StockBonusDbo ConvertToDbo(IStockBonus self)
        {
            StockBonusDbo outputData = new StockBonusDbo
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
