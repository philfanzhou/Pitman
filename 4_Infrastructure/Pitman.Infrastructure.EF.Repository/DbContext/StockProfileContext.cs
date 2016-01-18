using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Infrastructure.Repository.EF.SqlServerCe;

namespace Pitman.Infrastructure.EF.Repository
{
    internal class StockProfileContext : SqlCeDbContext
    {
        public StockProfileContext(string fullPath)
            : base(fullPath)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StockProfileConfig());
        }
    }
}
