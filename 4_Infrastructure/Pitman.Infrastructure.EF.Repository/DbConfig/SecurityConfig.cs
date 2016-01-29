using Ore.Infrastructure.MarketData;
using System.Data.Entity.ModelConfiguration;

namespace Pitman.Infrastructure.EF.Repository
{
    internal class SecurityConfig : EntityTypeConfiguration<Security>
    {
        public SecurityConfig()
        {
            this.HasKey(p => p.Code);
            this.Property(p => p.Market).IsRequired();
            this.Property(p => p.Type).IsRequired();
            this.Property(p => p.ShortName).IsRequired().HasMaxLength(12);
        }
    }
}
