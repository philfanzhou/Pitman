using Ore.Infrastructure.MarketData;
using Pitman.Distributed.Dto;
using System;
using System.Collections.Generic;

namespace Pitman.RESTful.Client
{
    public class ClientApi : IDisposable
    {
        #region Field
        private HttpClientEx _httpClient;
        #endregion

        #region constructor
        public ClientApi(string serverAddress)
        {
            _httpClient = new HttpClientEx(serverAddress);
        }

        public void Dispose()
        {
            if(_httpClient != null)
            {
                _httpClient.Dispose();
                _httpClient = null;
            }
        }
        #endregion

        #region Property
        public string ServerAddress
        {
            get { return _httpClient.BaseAddress.ToString(); }
        }
        #endregion

        #region Collection Service Status
        public IEnumerable<string> GetAllServiceName()
        {
            return _httpClient.GetAndReadAs<IEnumerable<string>>("CollectionStatus");
        }

        public string GetServiceStatus(string serviceName)
        {
            string uri = string.Format("CollectionStatus/{0}", serviceName);
            return _httpClient.GetAndReadAs<string>(uri);
        }
        #endregion

        public IEnumerable<ISecurity> GetAllSecurity()
        {
            return _httpClient.GetAndReadAs<IEnumerable<SecurityDto>>("Securities");
        }

        public IStockProfile GetStockProfile(string stockCode)
        {
            string uri = string.Format("StockProfile/{0}", stockCode);
            return _httpClient.GetAndReadAs<StockProfileDto>(uri);
        }

        public IEnumerable<IStockBonus> GetStockBonus(string stockCode)
        {
            string uri = string.Format("StockBonus/{0}", stockCode);
            return _httpClient.GetAndReadAs<IEnumerable<StockBonusDto>>(uri);
        }

        public IEnumerable<IStockStructure> GetStockStructure(string stockCode)
        {
            string uri = string.Format("StockStructure/{0}", stockCode);
            return _httpClient.GetAndReadAs<IEnumerable<StockStructureDto>>(uri);
        }

        public IEnumerable<IStockKLine> GetStockKLine(
            KLineType type, string stockCode, 
            DateTime startTime, DateTime endTime)
        {
            KLineArgs args = new KLineArgs
            {
                StockCode = stockCode,
                StartDate = startTime,
                EndDate = endTime
            };

            string controllerName;
            switch(type)
            {
                case KLineType.Day:
                    controllerName = "KLineDay";
                    break;
                case KLineType.Week:
                    controllerName = "KLineWeek";
                    break;
                case KLineType.Month:
                    controllerName = "KLineMonth";
                    break;
                case KLineType.Quarter:
                    controllerName = "KLineQuarter";
                    break;
                case KLineType.Year:
                    controllerName = "KLineYear";
                    break;
                case KLineType.Min1:
                    controllerName = "KLineMin1";
                    break;
                case KLineType.Min5:
                    controllerName = "KLineMin5";
                    break;
                case KLineType.Min15:
                    controllerName = "KLineMin15";
                    break;
                case KLineType.Min30:
                    controllerName = "KLineMin30";
                    break;
                case KLineType.Min60:
                    controllerName = "KLineMin60";
                    break;
                default:
                    controllerName = string.Empty;
                    break;
            }

            var result = _httpClient.PostAndReadAs<IEnumerable<StockKLineDto>, KLineArgs>(controllerName, args);
            return result;
        }
    }
}
