using System.Runtime.Serialization;

namespace Pitman.DistributedService.Dto
{
    [DataContract]
    public enum CollectionStatusDto
    {
        Unknown = 0,

        Stopped = 1,

        Running = 2
    }
}
