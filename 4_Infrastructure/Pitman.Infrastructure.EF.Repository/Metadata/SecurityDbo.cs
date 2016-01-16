using Ore.Infrastructure.MarketData;

namespace Pitman.Infrastructure.EF.Repository
{
    public class SecurityDbo : ISecurity
    {
        public string Code { get; set; }

        public Market Market { get; set; }

        public string ShortName { get; set; }

        public SecurityType Type { get; set; }
    }
}
