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
        /// <summary>
        /// 获取所有数据收集服务名称
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetAllServiceName()
        {
            return _httpClient.GetAndReadAs<IEnumerable<string>>("CollectionStatus");
        }

        /// <summary>
        /// 获取指定的数据收集服务的状态报告
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public string GetServiceStatus(string serviceName)
        {
            string uri = string.Format("CollectionStatus/{0}", serviceName);
            return _httpClient.GetAndReadAs<string>(uri);
        }
        #endregion

        /// <summary>
        /// 获取所有证券代码信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ISecurity> GetAllSecurity()
        {
            return _httpClient.GetAndReadAs<IEnumerable<SecurityDto>>("Securities");
        }

        /// <summary>
        /// 获取指定股票的基本信息
        /// </summary>
        /// <param name="stockCode"></param>
        /// <returns></returns>
        public IStockProfile GetStockProfile(string stockCode)
        {
            string uri = string.Format("StockProfile/{0}", stockCode);
            return _httpClient.GetAndReadAs<StockProfileDto>(uri);
        }

        /// <summary>
        /// 获取指定股票的分红配股信息
        /// </summary>
        /// <param name="stockCode"></param>
        /// <returns></returns>
        public IEnumerable<IStockBonus> GetStockBonus(string stockCode)
        {
            string uri = string.Format("StockBonus/{0}", stockCode);
            return _httpClient.GetAndReadAs<IEnumerable<StockBonusDto>>(uri);
        }

        /// <summary>
        /// 获取指定股票的股本结构信息
        /// </summary>
        /// <param name="stockCode"></param>
        /// <returns></returns>
        public IEnumerable<IStockStructure> GetStockStructure(string stockCode)
        {
            string uri = string.Format("StockStructure/{0}", stockCode);
            return _httpClient.GetAndReadAs<IEnumerable<StockStructureDto>>(uri);
        }

        /// <summary>
        /// 获取K线数据
        /// </summary>
        /// <param name="type"></param>
        /// <param name="stockCode"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 获取指定股票的机构持仓信息
        /// </summary>
        /// <param name="stockCode"></param>
        /// <returns></returns>
        public IEnumerable<IParticipation> GetParticipation(string stockCode)
        {
            string uri = string.Format("Participation/{0}", stockCode);
            return _httpClient.GetAndReadAs<IEnumerable<ParticipationDto>>(uri);
        }
    }
}
