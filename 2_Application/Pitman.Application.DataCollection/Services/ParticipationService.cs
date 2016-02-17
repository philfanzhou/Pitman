using Framework.Infrastructure.Log;
using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Eastmoney;
using Pitman.Application.MarketData;
using System;
using System.Linq;

namespace Pitman.Application.DataCollection
{
    /// <summary>
    /// 获取机构持仓数据的服务
    /// </summary>
    internal class ParticipationService : CollectionService
    {
        // 每天晚上7：00进行一次数据获取
        // 调用Ore.EastMoney内的接口
        private const string _serviceName = "Participation";

        /// <summary>
        /// 东方财富Api
        /// </summary>
        ParticipationApi _eastMoneyApi = new ParticipationApi();
        /// <summary>
        /// 存储数据服务
        /// </summary>
        private ParticipationAppService _appService = new ParticipationAppService();

        public override string ServiceName
        {
            get { return _serviceName; }
        }

        protected override bool IsWorkingTime()
        {
            ///*************test code*****************/
            //if (DateTime.Now - base.StopTime > new TimeSpan(0, 2, 0))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            ///******************************/


            //每天只进行一次此任务
            if (IsCompletedToday())
            {
                return false;
            }

            // 每天晚上7：00进行一次数据获取
            return DateTime.Now.Hour == 19;
        }

        protected override void DoWork()
        {
            // 获取所有证券信息
            var securities = SecurityService.GetDataFromApi().ToList();
            //设置进度对象
            base.Progress = new Progress(securities.Count);

            // 检查并更新或增加
            foreach (var security in securities)
            {
                //股票的数据获取
                var participation = GetData(security.Code);

                if(participation != null)
                {
                    SaveData(security.Code, participation);
                }

                // 降低获取数据的频率，避免被服务端封ip
                System.Threading.Thread.Sleep(500);

                // 更新进度
                base.Progress.Increase();
            }
        }

        private IParticipation GetData(string stockCode)
        {
            IParticipation result = null;

            try
            {
                result = _eastMoneyApi.GetLatest(stockCode);
            }
            catch (Exception ex)
            {
                //LogHelper.Logger.WriteLine(string.Format("Get Participation[{0}] data error.", stockCode));
                //LogHelper.Logger.WriteLine(ex.ToString());
            }

            return result;
        }

        private void SaveData(string stockCode, IParticipation data)
        {
            try
            {
                // 检查是否已经存在记录
                if (_appService.Exists(stockCode, data))
                {
                    //todo:
                    // 已经存在的记录，需要考虑更新
                }
                else
                {
                    // 不存在就添加
                    _appService.Add(stockCode, data);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Logger.WriteLine(string.Format("Save Participation[{0}] data error.", stockCode));
                LogHelper.Logger.WriteLine(ex.ToString());
            }
        }
    }
}
