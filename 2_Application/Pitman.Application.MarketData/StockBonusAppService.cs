﻿using Framework.Infrastructure.Repository;
using Ore.Infrastructure.MarketData;
using Pitman.Domain.FileStructure;
using Pitman.Infrastructure.EF.Repository;
using System.Collections.Generic;

namespace Pitman.Application.MarketData
{
    public class StockBonusAppService
    {
        public bool Exists(string stockCode, IStockBonus stockBonus)
        {
            // 设置查询条件
            var spec = Specification<StockBonus>.Eval(p => p.DateOfDeclaration.Equals(stockBonus.DateOfDeclaration));

            using (var context = GetContext(stockCode))
            {
                var repository = new Repository<StockBonus>(context);
                return repository.Exists(spec);
            }
        }

        public void Add(string stockCode, IStockBonus stockBonus)
        {
            using (var context = GetContext(stockCode))
            {
                var repository = new Repository<StockBonus>(context);
                repository.Add(stockBonus.ToDataObject());
                repository.UnitOfWork.Commit();
            }
        }

        public void Update(string stockCode, IStockBonus stockBonus)
        {
            using (var context = GetContext(stockCode))
            {
                var repository = new Repository<StockBonus>(context);
                repository.Update(stockBonus.ToDataObject());
                repository.UnitOfWork.Commit();
            }
        }

        public IEnumerable<IStockBonus> Get(string stockCode)
        {
            using (var context = GetContext(stockCode))
            {
                var repository = new Repository<StockBonus>(context);
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
    }
}
