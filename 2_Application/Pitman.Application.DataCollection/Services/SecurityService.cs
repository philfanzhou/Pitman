using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Eastmoney;
using Pitman.Application.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Infrastructure.Log;

namespace Pitman.Application.DataCollection
{
    internal class SecurityService : CollectionService
    {
        private const string _serviceName = "Security";

        public override string ServiceName
        {
            get { return _serviceName; }
        }

        protected override void DoWork()
        {
            try
            {
                // 获取所有证券信息
                var securities = GetDataFromApi().ToList();

                //设置进度对象
                base.Progress = new Progress(securities.Count);

                // 获取数据服务
                var appService = new SecurityAppService();

                // 检查并更新或增加
                foreach (var security in securities)
                {
                    // 检查是否已经存在记录
                    if (appService.Exists(security))
                    {
                        // 如果已经存在就更新
                        appService.Update(security);
                    }
                    else
                    {
                        // 不存在就添加
                        appService.Add(security);
                    }

                    // 更新进度
                    base.Progress.Increase();
                }
            }
            catch(Exception ex)
            {
                LogHelper.Logger.WriteLine("Pitman.Application.DataCollection.SecurityService.DoWork" + ex.Message);
            }
        }

        protected override bool IsWorkingTime()
        {
            // 每天只进行一次此任务
            if (IsCompletedToday())
            {
                return false;
            }

            // 每天早上7点执行任务
            return DateTime.Now.Hour == 7;
        }

        internal static IEnumerable<ISecurity> GetDataFromApi()
        {
            SecurityInfoApi api = new SecurityInfoApi();
            return api.GetAllSecurity();
        }
    }
}
