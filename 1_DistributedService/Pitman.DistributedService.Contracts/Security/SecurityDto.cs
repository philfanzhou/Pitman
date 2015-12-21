using Ore.Infrastructure.MarketData;
using System.Runtime.Serialization;

namespace Pitman.DistributedService.Contracts
{
    [DataContract(Name = "security")]
    public class SecurityDto : ISecurity
    {
        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "market")]
        public Market Market { get; set; }

        [DataMember(Name = "shortName")]
        public string ShortName { get; set; }

        [DataMember(Name = "type")]
        public SecurityType Type { get; set; }
    }
}
