using Framework.Infrastructure.Repository;
using Ore.Infrastructure.MarketData;
using Pitman.Domain.FileStructure;
using Pitman.Infrastructure.EF.Repository;
using System.Collections.Generic;

namespace Pitman.Application.MarketData
{
    public class SecurityAppService
    {
        public bool Exists(ISecurity security)
        {
            // 设置查询条件
            var spec = Specification<Security>.Eval(p => p.Code.Equals(security.Code));

            using (var context = GetContext())
            {
                var repository = new Repository<Security>(context);
                return repository.Exists(spec);
            }
        }

        public void Add(ISecurity security)
        {
            using (var context = GetContext())
            {
                var repository = new Repository<Security>(context);
                repository.Add(security.ToDataObject());
                repository.UnitOfWork.Commit();
            }
        }

        public void Update(ISecurity security)
        {
            using (var context = GetContext())
            {
                var repository = new Repository<Security>(context);
                repository.Update(security.ToDataObject());
                repository.UnitOfWork.Commit();
            }
        }

        public IEnumerable<ISecurity> GetAll()
        {
            using (var context = GetContext())
            {
                var repository = new Repository<Security>(context);
                return repository.GetAll();
            }
        }

        private IRepositoryContext GetContext()
        {
            string fullPath = DataFiles.GetSecuritiesFile();
            IRepositoryContext context
                = ContextFactory.Create(ContextType.Security, fullPath);

            return context;
        }
    }
}
