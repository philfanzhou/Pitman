using Framework.Infrastructure.Repository.EF.SqlServerCe;
using System.Data.Entity;

namespace Pitman.Infrastructure.EF.Repository
{
    internal class StockStructureContext : SqlCeDbContext
    {
        public StockStructureContext(string fullPath)
            : base(fullPath)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StockStructureConfig());
        }
    }
}
