using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Eastmoney;
using Pitman.Application.MarketData;
using System;
using System.Linq;
using Framework.Infrastructure.Log;

namespace Pitman.Application.DataCollection
{
    internal class ParticipationService : CollectionService
    {
        // 每天晚上7：00进行一次数据获取
        // 调用Ore.EastMoney内的接口
        private const string _serviceName = "Participation";

        public override string ServiceName
        {
            get { return _serviceName; }
        }

        protected override void DoWork()
        {
            try
            {
                // 获取所有证券信息
                var securities = SecurityService.GetDataFromApi().ToList();
                //设置进度对象
                base.Progress = new Progress(securities.Count);
                // 获取数据服务
                var appService = new ParticipationAppService();

                // 检查并更新或增加
                foreach (var security in securities)
                {
                    //股票的数据获取
                    var participation = GetDataFromApi(security.Code);

                    // 检查是否已经存在记录
                    if (appService.Exists(security.Code, participation))
                    {
                        // 如果已经存在就更新
                        appService.Update(security.Code, participation);
                    }
                    else
                    {
                        // 不存在就添加
                        appService.Add(security.Code, participation);
                    }

                    // 更新进度
                    base.Progress.Increase();
                }
            }
            catch(Exception ex)
            {
                LogHelper.Logger.WriteLine("Pitman.Application.DataCollection.ParticipationService.DoWork" + ex.Message);
            }
        }

        protected override bool IsWorkingTime()
        {
            // 每天只进行一次此任务
            if (IsCompletedToday())
            {
                return false;
            }

            // 每天晚上7：00进行一次数据获取
            return DateTime.Now.Hour == 19;
        }

        internal static IParticipation GetDataFromApi(string stockCode)
        {
            ParticipationApi api = new ParticipationApi();             
            return api.GetLatest(stockCode);
        }
    }
}
