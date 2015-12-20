using Ore.Infrastructure.MarketData;

namespace Pitman.WebApi
{
    public class SecurityDto : ISecurity
    {
        public string Code { get; set; }

        public Market Market { get; set; }

        public string ShortName { get; set; }

        public SecurityType Type { get; set; }
    }
}
