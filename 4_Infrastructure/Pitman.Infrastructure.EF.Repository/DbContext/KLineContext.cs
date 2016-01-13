using Framework.Infrastructure.Repository.EF.SqlServerCe;
using System.Data.Entity;

namespace Pitman.Infrastructure.EF.Repository
{
    internal class KLineContext : SqlCeDbContext
    {
        public KLineContext(string fullPath)
            : base(fullPath)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new KLineConfig());
        }
    }
}
