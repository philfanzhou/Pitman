using System.Collections.Generic;
using System.ServiceModel;

namespace Pitman.DistributedService.Contracts
{
    [ServiceContract]
    public interface IFundamentalService
    {
        [OperationContract]
        StockProfileDto GetProfile(string stockCode);

        [OperationContract]
        IEnumerable<StockBonusDto> GetBonus(string stockCode);

        [OperationContract]
        IEnumerable<StockStructureDto> GetStructure(string stockCode);
    }
}
