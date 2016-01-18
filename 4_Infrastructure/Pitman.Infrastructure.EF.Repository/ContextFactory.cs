using Framework.Infrastructure.Repository;
using Framework.Infrastructure.Repository.EF;
using System.Data.Entity;

namespace Pitman.Infrastructure.EF.Repository
{
    public static class ContextFactory
    {
        public static IRepositoryContext Create(ContextType type, string fullPath)
        {
            IRepositoryContext context = null;
            switch (type)
            {
                case ContextType.KLine:
                    context = CreateContext(new KLineContext(fullPath));
                    break;
                case ContextType.Security:
                    context = CreateContext(new SecurityContext(fullPath));
                    break;
                // 分红配股
                case ContextType.StockBonus:
                    context = CreateContext(new StockBonusContext(fullPath));
                    break;
                // 基本信息
                case ContextType.StockProfile:
                    context = CreateContext(new StockProfileContext(fullPath));
                    break;
                // 股本结构
                case ContextType.StockStructure:
                    context = CreateContext(new StockStructureContext(fullPath));
                    break;
                // 机构参与度
                case ContextType.Participation:
                    context = CreateContext(new ParticipationContext(fullPath));
                    break;
            }
            return context;
        }

        private static IRepositoryContext CreateContext<T>(T dbContext)
            where T : DbContext
        {
            dbContext.Database.CreateIfNotExists();
            var repositoryContext = new EntityFrameworkRepositoryContext<T>(dbContext);
            return repositoryContext;
        }
    }

    
}
