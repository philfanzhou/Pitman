using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Infrastructure.Repository;
using Ore.Infrastructure.MarketData;
using Pitman.Domain.FileStructure;
using Pitman.Infrastructure.EF.Repository;

namespace Pitman.Application.MarketData
{
    public class StockStructureAppService
    {
        public bool Exists(string stockCode, IStockStructure stockStructure)
        {
            // 设置查询条件
            var spec = Specification<StockStructureDbo>.Eval(p => p.DateOfChange.Equals(stockStructure.DateOfChange));

            using (var context = GetContext(stockCode))
            {
                var repository = new Repository<StockStructureDbo>(context);
                return repository.Exists(spec);
            }
        }

        public void Add(string stockCode, IStockStructure stockStructure)
        {
            using (var context = GetContext(stockCode))
            {
                var repository = new Repository<StockStructureDbo>(context);
                repository.Add(ConvertToDbo(stockStructure));
                repository.UnitOfWork.Commit();
            }
        }

        public void Update(string stockCode, IStockStructure stockStructure)
        {
            using (var context = GetContext(stockCode))
            {
                var repository = new Repository<StockStructureDbo>(context);
                repository.Update(ConvertToDbo(stockStructure));
                repository.UnitOfWork.Commit();
            }
        }

        public IEnumerable<IStockStructure> Get(string stockCode)
        {
            using (var context = GetContext(stockCode))
            {
                var repository = new Repository<StockStructureDbo>(context);
                return repository.GetAll();
            }
        }

        private IRepositoryContext GetContext(string stockCode)
        {
            string fullPath = DataFiles.GetStockStructureFile(stockCode);
            IRepositoryContext context
                = ContextFactory.Create(ContextType.StockStructure, fullPath);

            return context;
        }

        private static StockStructureDbo ConvertToDbo(IStockStructure self)
        {
            StockStructureDbo outputData = new StockStructureDbo
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
