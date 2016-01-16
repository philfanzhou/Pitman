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
            var spec = Specification<SecurityDbo>.Eval(p => p.Code.Equals(security.Code));

            using (var context = GetContext())
            {
                var repository = new Repository<SecurityDbo>(context);
                return repository.Exists(spec);
            }
        }

        public void Add(ISecurity security)
        {
            using (var context = GetContext())
            {
                var repository = new Repository<SecurityDbo>(context);
                repository.Add(security.ConvertToDbo());
                repository.UnitOfWork.Commit();
            }
        }

        public void Update(ISecurity security)
        {
            using (var context = GetContext())
            {
                var repository = new Repository<SecurityDbo>(context);
                repository.Update(security.ConvertToDbo());
                repository.UnitOfWork.Commit();
            }
        }

        public IEnumerable<ISecurity> GetAll()
        {
            using (var context = GetContext())
            {
                var repository = new Repository<SecurityDbo>(context);
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

    internal static class SecurityExt
    {
        public static SecurityDbo ConvertToDbo(this ISecurity self)
        {
            SecurityDbo outputData = new SecurityDbo
            {
                Code = self.Code,
                ShortName = self.ShortName,
                Market = self.Market,
                Type = self.Type
            };

            return outputData;
        }
    }
}
