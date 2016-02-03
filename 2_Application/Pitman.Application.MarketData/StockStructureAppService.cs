﻿using Framework.Infrastructure.Repository;
using Ore.Infrastructure.MarketData;
using Pitman.Domain.FileStructure;
using Pitman.Infrastructure.EF.Repository;
using System.Collections.Generic;
using Pitman.Infrastructure.SqlCe.Repository;

namespace Pitman.Application.MarketData
{
    public class StockStructureAppService
    {
        public bool Exists(string stockCode, IStockStructure stockStructure)
        {
            StockStructureRepository repository = new StockStructureRepository(DataFiles.GetStockStructureFile(stockCode));
            return repository.Exists(stockStructure);

            //// 设置查询条件
            //var spec = Specification<StockStructure>.Eval(p => p.DateOfChange.Equals(stockStructure.DateOfChange));

            //using (var context = GetContext(stockCode))
            //{
            //    var repository = new Repository<StockStructure>(context);
            //    return repository.Exists(spec);
            //}
        }

        public void Add(string stockCode, IStockStructure stockStructure)
        {
            StockStructureRepository repository = new StockStructureRepository(DataFiles.GetStockStructureFile(stockCode));
            repository.AddRange(new IStockStructure[] { stockStructure });

            //using (var context = GetContext(stockCode))
            //{
            //    var repository = new Repository<StockStructure>(context);
            //    repository.Add(stockStructure.ToDataObject());
            //    repository.UnitOfWork.Commit();
            //}
        }

        public void Update(string stockCode, IStockStructure stockStructure)
        {
            StockStructureRepository repository = new StockStructureRepository(DataFiles.GetStockStructureFile(stockCode));
            repository.UpdateRange(new IStockStructure[] { stockStructure });

            //using (var context = GetContext(stockCode))
            //{
            //    var repository = new Repository<StockStructure>(context);
            //    repository.Update(stockStructure.ToDataObject());
            //    repository.UnitOfWork.Commit();
            //}
        }

        public IEnumerable<IStockStructure> Get(string stockCode)
        {
            StockStructureRepository repository = new StockStructureRepository(DataFiles.GetStockStructureFile(stockCode));
            return repository.GetAll();

            //using (var context = GetContext(stockCode))
            //{
            //    var repository = new Repository<StockStructure>(context);
            //    return repository.GetAll();
            //}
        }

        private IRepositoryContext GetContext(string stockCode)
        {
            string fullPath = DataFiles.GetStockStructureFile(stockCode);
            IRepositoryContext context
                = ContextFactory.Create(ContextType.StockStructure, fullPath);

            return context;
        }
    }
}
