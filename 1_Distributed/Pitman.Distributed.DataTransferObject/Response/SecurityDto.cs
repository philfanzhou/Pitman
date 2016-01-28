using Ore.Infrastructure.MarketData;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Pitman.Distributed.DataTransferObject
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

    public static class SecurityConverter
    {
        public static IEnumerable<SecurityDto> ToDto(this IEnumerable<ISecurity> self)
        {
            return self.Select(p => p.ToDto());
        }

        public static SecurityDto ToDto(this ISecurity self)
        {
            SecurityDto outputData = new SecurityDto
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
