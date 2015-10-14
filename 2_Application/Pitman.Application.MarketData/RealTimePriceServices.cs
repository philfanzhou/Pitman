using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Sina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace Pitman.Application.MarketData
{
    internal class RealTimePriceServices : IDataCollectionService
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

        private Dictionary<string, IStockRealTimePrice> previousData
            = new Dictionary<string, IStockRealTimePrice>();

        private Dictionary<string, Queue<IStockRealTimePrice>> dataQueue
            = new Dictionary<string, Queue<IStockRealTimePrice>>();

        /// <summary>
        /// 分时数据的精度为5秒，这里取3秒时间差作为数据是否已经更新的依据
        /// </summary>
        private TimeSpan dataSpan = new TimeSpan(0, 0, 3);
        #endregion

        #region Property
        public ServiceStatus Status
        {
            get
            {
                if(getDataTimer.Enabled && saveDataTimer.Enabled)
                {
                    return ServiceStatus.Running;
                }
                else
                {
                    return ServiceStatus.Stopped;
                }
            }
        }
        #endregion

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
            
            //开始获取数据
            getDataTimer.Elapsed += GetDataTimer_Elapsed;
            getDataTimer.Enabled = true;

            saveDataTimer.Elapsed += SaveDataTimer_Elapsed;
            saveDataTimer.Enabled = true;
        }

        public void Stop()
        {
            if (Status == ServiceStatus.Stopped)
            {
                return;
            }

            if(getDataTimer != null)
            {
                getDataTimer.Elapsed -= GetDataTimer_Elapsed;
                getDataTimer.Enabled = false;
                getDataTimer.Stop();
                getDataTimer.Dispose();
                getDataTimer = null;
            }

            if(saveDataTimer != null)
            {
                saveDataTimer.Elapsed -= SaveDataTimer_Elapsed;
                saveDataTimer.Enabled = false;
                saveDataTimer.Stop();
                saveDataTimer.Dispose();
                saveDataTimer = null;
            }

            //todo:清理数据之前，还应该将最后剩余的数据进行保存

            previousData.Clear();
            dataQueue.Clear();
        }

        #region Private Method
        private void GetDataTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            getDataTimer.Enabled = false;

            IEnumerable<IStockRealTimePrice> datas = GetRealTimeDatas();
            if (null != datas)
            {
                CheckDataAndAddToQueue(datas);
            }

            getDataTimer.Enabled = true;
        }

        private void SaveDataTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            saveDataTimer.Enabled = false;

            saveDataTimer.Enabled = true;
        }

        private IEnumerable<ISecurity> GetStockList()
        {
            List<ISecurity> result = new List<ISecurity>();
            result.Add(new StockInfo { Code = "600036", Market = Market.XSHG });
            result.Add(new StockInfo { Code = "000800", Market = Market.XSHE });

            return result;
        }

        private IEnumerable<IStockRealTimePrice> GetRealTimeDatas()
        {
            IEnumerable<ISecurity> stocks = GetStockList();
            SinaRealTimePriceAPI api = new SinaRealTimePriceAPI();

            IEnumerable<IStockRealTimePrice> datas;
            try
            {
                datas = api.GetData(stocks).Where(p => p.Time.Date == DateTime.Now.Date);
            }
            catch
            {
                datas = new List<IStockRealTimePrice>();
            }

            return datas;
        }

        private static string GetMarketAndCode(IStockRealTimePrice data)
        {
            return data.Market.ToString() + data.Code;
        }

        private void CheckDataAndAddToQueue(IEnumerable<IStockRealTimePrice> datas)
        {
            foreach(var currentData in datas)
            {
                string marketAndCode = GetMarketAndCode(currentData);

                if(!previousData.ContainsKey(marketAndCode))
                {
                    previousData.Add(marketAndCode, currentData);
                    AddDataToQueue(marketAndCode, currentData);
                }
                else
                {
                    var previousData = this.previousData[marketAndCode];
                    if(currentData.Time - previousData.Time > dataSpan)
                    {
                        this.previousData[marketAndCode] = currentData;
                        AddDataToQueue(marketAndCode, currentData);
                    }
                }
            }
        }

        private void AddDataToQueue(string marketAndCode, IStockRealTimePrice data)
        {
            if(!dataQueue.ContainsKey(marketAndCode))
            {
                dataQueue.Add(marketAndCode, new Queue<IStockRealTimePrice>());
            }

            dataQueue[marketAndCode].Enqueue(data);
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
