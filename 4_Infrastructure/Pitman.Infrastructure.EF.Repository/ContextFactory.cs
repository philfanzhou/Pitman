using Framework.Infrastructure.Repository;
using Framework.Infrastructure.Repository.EF;
using System.Data.Entity;

namespace Pitman.Infrastructure.EF.Repository
{
    public static class ContextFactory
    {
        public static IRepositoryContext CreateContext(ContextType type, string fullPath)
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

    public enum ContextType
    {
        KLine,
        Security
    }
}
