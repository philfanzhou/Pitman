using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Infrastructure.Repository.EF.SqlServerCe;

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
