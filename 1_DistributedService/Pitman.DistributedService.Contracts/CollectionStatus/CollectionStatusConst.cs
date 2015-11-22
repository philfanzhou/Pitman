namespace Pitman.DistributedService.Contracts
{
    public class CollectionStatusConst
    {
        public const string ServiceName = "CollectionStatus";

        public const string Uri_GetAllServiceName = "AllServiceName";

        public const string Uri_GetStatus_ServerSide = "Status/{serviceName}";

        public const string Uri_GetStatus_ClientSide = "Status/{0}";
    }
}
