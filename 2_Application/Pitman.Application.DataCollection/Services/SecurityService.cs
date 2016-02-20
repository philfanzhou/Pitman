using Framework.Infrastructure.Log;
using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Eastmoney;
using Pitman.Application.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pitman.Application.DataCollection
{
    internal class SecurityService : CollectionService
    {
        /// <summary>
        /// 存储数据服务
        /// </summary>
        private SecurityAppService _saveDataService = new SecurityAppService();

        public override string ServiceName
        {
            get { return "Security"; }
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

            // 每天只进行一次此任务
            if (IsCompletedToday())
            {
                return false;
            }

            // 每天早上7点执行任务
            return DateTime.Now.Hour == 7;
        }

        protected override void DoWork()
        {
            // 获取所有证券信息
            var securities = GetData().ToList();

            //设置进度对象
            base.Progress = new Progress(securities.Count);

            // 检查并更新或增加
            foreach (var security in securities)
            {
                SaveData(security);

                // 更新进度
                base.Progress.Increase();
            }
        }

        private IEnumerable<ISecurity> GetData()
        {
            try
            {
                SecurityInfoApi api = new SecurityInfoApi();
                return api.GetAllSecurity();
            }
            catch (Exception ex)
            {
                LogHelper.Logger.WriteLine(ex.ToString());
                return new List<ISecurity>();
            }
        }

        private void SaveData(ISecurity data)
        {
            try
            {
                // 检查是否已经存在记录
                if (_saveDataService.Exists(data))
                {
                    // 如果已经存在就更新
                    _saveDataService.Update(data);
                }
                else
                {
                    // 不存在就添加
                    _saveDataService.Add(data);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Logger.WriteLine("Save Security data error.");
                LogHelper.Logger.WriteLine(ex.ToString());
            }
        }
    }
}
