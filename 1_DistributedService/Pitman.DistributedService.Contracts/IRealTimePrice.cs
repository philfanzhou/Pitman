using Pitman.DistributedService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.DistributedService.Contracts
{
    [ServiceContract]
    public interface IRealTimePrice
    {
        IEnumerable<StockRealTimePriceDto> 
    }
}
