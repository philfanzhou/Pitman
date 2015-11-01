using System.Runtime.Serialization;

namespace Pitman.DistributedService.Dto
{
    [DataContract]
    public enum MarketDto
    {
        Unknown = 0,
        XSHG = 1,
        XSHE = 2,
        CCFX = 3,
        XDCE = 4,
        XSGE = 5,
        XZCE = 6,
        XHKG = 7
    }
}
