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
                repository.Add(stockProfile.ToDbo());
                repository.UnitOfWork.Commit();
            }
        }

        public void Update(IStockProfile stockProfile)
        {
            using (var context = GetContext())
            {
                var repository = new Repository<StockProfileDbo>(context);
                repository.Update(stockProfile.ToDbo());
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
    }
}
