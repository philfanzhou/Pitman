using Framework.Infrastructure.Repository.EF.SqlServerCe;
using System.Data.Entity;

namespace Pitman.Infrastructure.EF.Repository
{
    internal class ParticipationContext : SqlCeDbContext
    {
        public ParticipationContext(string fullPath)
            : base(fullPath)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ParticipationConfig());
        }
    }
}
