using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Sina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Pitman.Application.MarketData
{
    public class RealTimePriceServices : IDataCollectionService
    {
        private readonly TimeSpan StartTime = new DateTime(1900, 1, 1, 9, 10, 0).TimeOfDay;
        private readonly TimeSpan StopTime = new DateTime(1900, 1, 1, 15, 15, 0).TimeOfDay;

        private Task getDataTask;

        /// <summary>
        /// 获取数据的Timer
        /// </summary>
        private Timer getDataTimer = new Timer(3000);

        /// <summary>
        /// 存储数据的Timer
        /// </summary>
        private Timer saveDataTimer = new Timer(1000);

        private ServiceStatus status = ServiceStatus.Stopped;

        private Dictionary<string, IStockRealTimePrice> latestData
            = new Dictionary<string, IStockRealTimePrice>();

        private Dictionary<string, Queue<IStockRealTimePrice>> dataQueue
            = new Dictionary<string, Queue<IStockRealTimePrice>>();

        public ServiceStatus Status
        {
            get
            {
                return status;
            }
        }

        /// <summary>
        /// 分时数据的精度为5秒，这里取3秒时间差作为数据是否已经更新的依据
        /// </summary>
        private TimeSpan dataSpan = new TimeSpan(0, 0, 3);

        public bool IsWorkingTime(DateTime now)
        {
            TimeSpan current = now.TimeOfDay;
            if(StartTime < current && current < StopTime)
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
            if(status == ServiceStatus.Running)
            {
                return;
            }

            getDataTask = new Task(GetDataTimer_Elapsed);
            getDataTask.Start();

            //开始获取数据
            //getDataTimer.Elapsed += GetDataTimer_Elapsed;
            //getDataTimer.Enabled = true;

            //saveDataTimer.Elapsed += SaveDataTimer_Elapsed;
            //saveDataTimer.Enabled = true;

            this.status = ServiceStatus.Running;
        }

        public void Stop()
        {
            if (status == ServiceStatus.Stopped)
            {
                return;
            }

            if(getDataTimer != null)
            {
                //getDataTimer.Elapsed -= GetDataTimer_Elapsed;
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

            latestData.Clear();
            dataQueue.Clear();

            this.status = ServiceStatus.Stopped;
        }

        private void GetDataTimer_Elapsed()
        {
            System.Threading.Timer
                IEnumerable<IStockRealTimePrice> datas = GetRealTimeDatas();
                if (null == datas)
                {
                    return;
                }

                CheckDataAndAddToQueue(datas);
        }

        private void SaveDataTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            
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
                datas = api.GetData(stocks);
            }
            catch
            {
                datas = null;
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

                if(!latestData.ContainsKey(marketAndCode))
                {
                    latestData.Add(marketAndCode, currentData);

                    AddDataToQueue(marketAndCode, currentData);
                }
                else
                {
                    var previousData = latestData[marketAndCode];
                    if(currentData.Time - previousData.Time > dataSpan)
                    {
                        latestData[marketAndCode] = currentData;
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
    }
}
