using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Sina;
using Pitman.Infrastructure.FileDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace Pitman.Application.DataCollection
{
    internal class RealTimePriceServices : ICollectionService
    {
        #region Field
        private readonly TimeSpan morningStart = new DateTime(1900, 1, 1, 9, 10, 0).TimeOfDay;
        private readonly TimeSpan noonStop = new DateTime(1900, 1, 1, 11, 55, 0).TimeOfDay;
        private readonly TimeSpan noonStart = new DateTime(1900, 1, 1, 12, 55, 0).TimeOfDay;
        private readonly TimeSpan afternoonStop = new DateTime(1900, 1, 1, 15, 15, 0).TimeOfDay;

        /// <summary>
        /// 获取数据的Timer
        /// </summary>
        private Timer getDataTimer = new Timer(3000);

        /// <summary>
        /// 存储数据的Timer
        /// </summary>
        private Timer saveDataTimer = new Timer(1000);

        private Dictionary<string, IStockRealTime> previousData
            = new Dictionary<string, IStockRealTime>();

        private Queue<IStockRealTime> dataQueue
            = new Queue<IStockRealTime>();

        /// <summary>
        /// 分时数据的精度为5秒，这里取3秒时间差作为数据是否已经更新的依据
        /// </summary>
        private TimeSpan dataSpan = new TimeSpan(0, 0, 3);
        #endregion

        #region Property
        public ServiceStatus Status
        {
            get; private set;
        }
        #endregion

        public RealTimePriceServices()
        {
            getDataTimer.Elapsed += GetDataTimer_Elapsed;
            saveDataTimer.Elapsed += SaveDataTimer_Elapsed;

            Status = ServiceStatus.Stopped;
        }

        public bool IsWorkingTime(DateTime now)
        {
            TimeSpan current = now.TimeOfDay;
            if((morningStart < current && current < noonStop) ||
                (noonStart < current && current < afternoonStop))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Start()
        {
            if(Status == ServiceStatus.Running)
            {
                return;
            }
            
            getDataTimer.Enabled = true;
            saveDataTimer.Enabled = true;

            Status = ServiceStatus.Running;
        }

        public void Stop()
        {
            if (Status == ServiceStatus.Stopped)
            {
                return;
            }

            getDataTimer.Enabled = false;
            saveDataTimer.Enabled = false;

            //还应该将最后剩余的数据进行保存
            WriteDataToFile();

            Status = ServiceStatus.Stopped;
        }

        #region Private Method
        private void GetDataTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            getDataTimer.Enabled = false;

            IEnumerable<IStockRealTime> datas = GetRealTimeDatas();
            CheckDataAndAddToQueue(datas);

            getDataTimer.Enabled = true;
        }

        private void SaveDataTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            saveDataTimer.Enabled = false;
            WriteDataToFile();
            saveDataTimer.Enabled = true;
        }

        private void WriteDataToFile()
        {
            if (dataQueue.Count > 0)
            {
                var repository = new RealTimeDataRepository();
                while (dataQueue.Count > 0)
                {
                    repository.Add(dataQueue.Dequeue());
                }
            }
        }

        private IEnumerable<ISecurity> GetStockList()
        {
            List<ISecurity> result = new List<ISecurity>();
            result.Add(new StockInfo { Code = "600518", Market = Market.XSHG });
            result.Add(new StockInfo { Code = "600036", Market = Market.XSHG });
            result.Add(new StockInfo { Code = "600298", Market = Market.XSHG });
            result.Add(new StockInfo { Code = "601933", Market = Market.XSHG });
            result.Add(new StockInfo { Code = "600660", Market = Market.XSHG });
            result.Add(new StockInfo { Code = "600196", Market = Market.XSHG });

            result.Add(new StockInfo { Code = "300118", Market = Market.XSHE });
            result.Add(new StockInfo { Code = "000800", Market = Market.XSHE });


            return result;
        }

        private IEnumerable<IStockRealTime> GetRealTimeDatas()
        {
            IEnumerable<ISecurity> stocks = GetStockList();
            StockRealTimeApi api = new StockRealTimeApi();

            IEnumerable<IStockRealTime> datas;
            try
            {
                datas = api.GetData(stocks).Where(p => p.Time.Date == DateTime.Now.Date);
            }
            catch
            {
                datas = new List<IStockRealTime>();
            }

            return datas;
        }

        private void CheckDataAndAddToQueue(IEnumerable<IStockRealTime> datas)
        {
            foreach(var currentData in datas)
            {
                if(!previousData.ContainsKey(currentData.Code))
                {
                    previousData.Add(currentData.Code, currentData);
                    dataQueue.Enqueue(currentData);
                }
                else
                {
                    var preData = this.previousData[currentData.Code];
                    if(currentData.Time - preData.Time > dataSpan)
                    {
                        this.previousData[currentData.Code] = currentData;
                        dataQueue.Enqueue(currentData);
                    }
                }
            }
        }

        private class StockInfo : ISecurity
        {
            public string Code
            {
                get; set;
            }

            public Market Market
            {
                get; set;
            }

            public string ShortName
            {
                get; set;
            }

            public SecurityType Type
            {
                get
                {
                    return SecurityType.Sotck;
                }
            }
        }
        #endregion
    }
}
