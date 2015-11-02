using Pitman.DistributedService.Contracts;
using Pitman.DistributedService.Dto;
using System;
using System.Collections.Generic;

namespace Pitman.DistributedService
{
    public class CollectionServiceStatus : ICollectionServiceStatus
    {
        public IEnumerable<string> GetAllServiceName()
        {
            return new List<string> { "Test ok" };
        }

        public CollectionServiceStatusDto GetStatus(string serviceName)
        {
            return CollectionServiceStatusDto.Running;
        }
    }
}
