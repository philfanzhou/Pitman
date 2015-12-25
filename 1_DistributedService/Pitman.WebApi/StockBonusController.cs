using Ore.Infrastructure.MarketData;
using Pitman.Application.DataCollection;
using Pitman.DistributedService.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Pitman.WebApi
{
    public class StockBonusController : ApiController
    {
        public IEnumerable<StockBonusDto> Get(string stockCode)
        {
            ///*test code for communication*************************************/
            //var dto = new StockBonusDto()
            //{
            //    Code = "600036",
            //    Market = Market.XSHG,
            //    ShortName = "招商银行",
            //};
            //var result = new List<StockBonusDto>();
            //result.Add(dto);
            //return result;
            ///*test code for communication*************************************/
            
            return FundamentalDatasource.GetBonus(stockCode).Select(t => ConvertToDto(t));
        }

        private static StockBonusDto ConvertToDto(IStockBonus data)
        {
            return new StockBonusDto
            {
                Code = data.Code,
                ShortName = data.ShortName,
                Market = data.Market,
                Type = data.Type,
                ShareSplitCount = data.ShareSplitCount,
                StartOrArriveDate = data.StartOrArriveDate,
                CapitalStockBaseDate = data.CapitalStockBaseDate,
                CapitalStockBeforeDispatch = data.CapitalStockBeforeDispatch,
                CapitalSurplusIncreaseRate = data.CapitalSurplusIncreaseRate,
                ConvertibleBondDate = data.ConvertibleBondDate,
                DateOfDeclaration = data.DateOfDeclaration,
                Description = data.Description,
                ReserveSurplusIncreaseRate = data.ReserveSurplusIncreaseRate,
                ResolutionOfShareholdersMeetingDate = data.ResolutionOfShareholdersMeetingDate,
                ActualDispatchRate = data.ActualDispatchRate,
                BAndHDividendAfterTax = data.BAndHDividendAfterTax,
                BAndHPreTaxDividend = data.BAndHPreTaxDividend,
                DividendAfterTax = data.DividendAfterTax,
                TransferredAllottedPrice = data.TransferredAllottedPrice,
                TransferredAllottedRate = data.TransferredAllottedRate,
                BonusRate = data.BonusRate,
                DispatchExpiryDate = data.DispatchExpiryDate,
                DispatchListingDate = data.DispatchListingDate,
                DispatchPrice = data.DispatchPrice,
                DispatchRate = data.DispatchRate,
                ExdividendDate = data.ExdividendDate,
                ExchangeRate = data.ExchangeRate,
                ExpirationDate = data.ExpirationDate,
                IncreaseRate = data.IncreaseRate,
                LastTradingDay = data.LastTradingDay,
                IssuingObject = data.IssuingObject,
                PreTaxDividend = data.PreTaxDividend,
                RegisterDate = data.RegisterDate,
                TotalDispatch = data.TotalDispatch
            };
        }
    }
}
