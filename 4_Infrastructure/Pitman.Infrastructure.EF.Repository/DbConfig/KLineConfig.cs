using Ore.Infrastructure.MarketData;
using System.Data.Entity.ModelConfiguration;

namespace Pitman.Infrastructure.EF.Repository
{
    internal class KLineConfig : EntityTypeConfiguration<StockKLine>
    {
        public KLineConfig()
        {
            this.HasKey(p => p.Time);
            this.Property(p => p.Open).IsRequired();
            this.Property(p => p.Close).IsRequired();
            this.Property(p => p.High).IsRequired();
            this.Property(p => p.Low).IsRequired();
            this.Property(p => p.Volume).IsRequired();
            this.Property(p => p.Amount).IsRequired();
        }
    }
}
