using Ore.Infrastructure.MarketData;
using Pitman.Application.DataCollection;
using Pitman.DistributedService.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Pitman.WebApi
{
    public class StockStructureController : ApiController
    {
        public IEnumerable<StockStructureDto> Get(string stockCode)
        {
            ///*test code for communication*************************************/
            //var dto = new StockStructureDto()
            //{
            //    Code = "600036",
            //    Market = Market.XSHG,
            //    ShortName = "招商银行",
            //};
            //var result = new List<StockStructureDto>();
            //result.Add(dto);
            //return result;
            ///*test code for communication*************************************/

            return FundamentalDatasource.GetStructure(stockCode).Select(t => ConvertToDto(t));
        }

        private static StockStructureDto ConvertToDto(IStockStructure data)
        {
            return new StockStructureDto
            {
                Code = data.Code,
                ShortName = data.ShortName,
                Market = data.Market,
                SharesA = data.SharesA,
                SharesB = data.SharesB,
                SharesH = data.SharesH,
                StateOwnedLegalPersonShares = data.StateOwnedLegalPersonShares,
                StateShares = data.StateShares,
                StrategicInvestorsShares = data.StrategicInvestorsShares,
                DomesticLegalPersonShares = data.DomesticLegalPersonShares,
                DateOfChange = data.DateOfChange,
                DateOfDeclaration = data.DateOfDeclaration,
                DomesticSponsorsShares = data.DomesticSponsorsShares,
                ExecutiveShares = data.ExecutiveShares,
                FundsShares = data.FundsShares,
                GeneralLegalPersonShares = data.GeneralLegalPersonShares,
                InternalStaffShares = data.InternalStaffShares,
                PreferredStock = data.PreferredStock,
                RaiseLegalPersonShares = data.RaiseLegalPersonShares,
                Reason = data.Reason,
                RestrictedSharesA = data.RestrictedSharesA,
                RestrictedSharesB = data.RestrictedSharesB,
                TotalShares = data.TotalShares,
                TransferredAllottedShares = data.TransferredAllottedShares
            };
        }
    }
}
