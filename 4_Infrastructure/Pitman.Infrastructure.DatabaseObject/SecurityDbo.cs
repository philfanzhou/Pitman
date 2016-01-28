using Ore.Infrastructure.MarketData;

namespace Pitman.Infrastructure.DatabaseObject
{
    public class SecurityDbo : ISecurity
    {
        public string Code { get; set; }

        public Market Market { get; set; }

        public string ShortName { get; set; }

        public SecurityType Type { get; set; }
    }

    public static class SecurityConverter
    {
        public static SecurityDbo ToDbo(this ISecurity self)
        {
            SecurityDbo outputData = new SecurityDbo
            {
                Code = self.Code,
                ShortName = self.ShortName,
                Market = self.Market,
                Type = self.Type
            };

            return outputData;
        }
    }
}
