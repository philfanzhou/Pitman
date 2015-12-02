namespace Pitman.DistributedService.Contracts
{
    public class CollectionStatusServiceConst
    {
        public const string ServiceName = "CollectionStatusService";

        public const string Uri_GetAllServiceName = "AllServiceName";

        public const string Uri_GetStatus_ServerSide = "Status/{serviceName}";

        public const string Uri_GetStatus_ClientSide = "Status/{0}";
    }
}
