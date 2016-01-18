﻿using Ore.Infrastructure.MarketData;
using Pitman.Distributed.Dto;
using System.Collections.Generic;
using System.Web.Http;

namespace Pitman.Distributed.WebApi
{
    public class StockStructureController : ApiController
    {
        public IEnumerable<StockStructureDto> Get(string stockCode)
        {
#if DEBUG
            /*test code for communication*************************************/
            var dto = new StockStructureDto()
            {
                SharesA = 12324232,
                Reason = "测试测试测试"
            };
            var result = new List<StockStructureDto>();
            result.Add(dto);
            return result;
            /*test code for communication*************************************/
#endif
            throw new System.NotImplementedException();

            //return FundamentalDatasource.GetStructure(stockCode).Select(t => ConvertToDto(t));
        }

        private static StockStructureDto ConvertToDto(IStockStructure data)
        {
            return new StockStructureDto
            {
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
