using Framework.Infrastructure.Repository;
using Ore.Infrastructure.MarketData;
using Pitman.Domain.FileStructure;
using Pitman.Infrastructure.EF.Repository;
using System.Collections.Generic;
using Pitman.Infrastructure.SqlCe.Repository;

namespace Pitman.Application.MarketData
{
    public class StockProfileAppService
    {
        public bool Exists(IStockProfile stockProfile)
        {
            StockProfileRepository repository = new StockProfileRepository(DataFiles.GetStockProfileFile());
            return repository.Exists(stockProfile);

            //// 设置查询条件
            //var spec = Specification<StockProfile>.Eval(p => p.CodeA.Equals(stockProfile.CodeA));

            //using (var context = GetContext())
            //{
            //    var repository = new Repository<StockProfile>(context);
            //    return repository.Exists(spec);
            //}
        }

        public void Add(IStockProfile stockProfile)
        {
            StockProfileRepository repository = new StockProfileRepository(DataFiles.GetStockProfileFile());
            repository.AddRange(new IStockProfile[] { stockProfile });

            //using (var context = GetContext())
            //{
            //    var repository = new Repository<StockProfile>(context);
            //    repository.Add(stockProfile.ToDataObject());
            //    repository.UnitOfWork.Commit();
            //}
        }

        public void Update(IStockProfile stockProfile)
        {
            StockProfileRepository repository = new StockProfileRepository(DataFiles.GetStockProfileFile());
            repository.UpdateRange(new IStockProfile[] { stockProfile });

            //using (var context = GetContext())
            //{
            //    var repository = new Repository<StockProfile>(context);
            //    repository.Update(stockProfile.ToDataObject());
            //    repository.UnitOfWork.Commit();
            //}
        }

        public IEnumerable<IStockProfile> GetAll()
        {
            StockProfileRepository repository = new StockProfileRepository(DataFiles.GetStockProfileFile());
            return repository.GetAll();

            //using (var context = GetContext())
            //{
            //    var repository = new Repository<StockProfile>(context);
            //    return repository.GetAll();
            //}
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
