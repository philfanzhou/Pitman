using System.Runtime.Serialization;

namespace Pitman.DistributedService.Dto
{
    [DataContract]
    public enum CollectionServiceStatusDto
    {
        Unknown = 0,

        Stopped = 1,

        Running = 2
    }
}
