using Pitman.Infrastructure.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pitman.Application.Import
{
    public partial class MainForm : Form
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public MainForm()
        {
            InitializeComponent();            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            timer.Interval = 1000 * 3600;
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("是否停止下载服务和关闭软件？", "询问", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();

            DateTime dtNow = DateTime.Now;
            if ((dtNow.Hour == 17 || dtNow.Hour == 23) && dtNow.DayOfWeek != DayOfWeek.Saturday && dtNow.DayOfWeek != DayOfWeek.Sunday)
            {
                //if (this.btnMktEqud.Enabled)
                //{
                //    //启动股票日线行情
                //    btnMktEqud_Click(null, null);
                //}
                //if (this.btnMktIdxd.Enabled)
                //{
                //    //启动指数日线行情
                //    btnMktIdxd_Click(null, null);
                //}
                if (this.btnOrgPercent.Enabled)
                {
                    //启动机构参与度
                    btnOrgPercent_Click(null, null);
                }
            }

            timer.Start();
        }

        //#region 下载股票基本信息

        private void btnEqu_Click(object sender, EventArgs e)
        {
        //    this.pbEqu.Value = 0;
        //    this.lblEqu.Text = "下载中...";
        //    this.btnEqu.Enabled = false;

        //    Thread thread = new Thread(new ThreadStart(DownEquData));
        //    thread.IsBackground = true;
        //    thread.Start();
        }

        //private void DownEquData()
        //{
        //    string message = Wmcloud.GetDataFromUrl(Wmcloud.EquUrl);
        //    if (message == null || !message.Contains("Success")) return;
        //    message = Wmcloud.GetJsonStrByMessage(message);
        //    List<Equ> equList = JsonHelper.JsonToList<Equ>(message);

        //    IEquRepository equService = ImportService.EquService;
        //    if (!equService.DeleteAllEqus())
        //    {
        //        this.lblEqu.Text = "数据库异常D";
        //        this.btnEqu.Enabled = true;
        //        return;
        //    }

        //    int index = 0;
        //    foreach (Equ entity in equList)
        //    {
        //        this.pbEqu.Value = (index * 100) / equList.Count;
        //        this.lblEqu.Text = string.Format("{0}/{1}", ++index, equList.Count);

        //        //如果插入失败，反复插入数据；以后请修改为更新历史数据方式
        //        if (!equService.Insert(entity))
        //        {
        //            Thread.Sleep(5000);
        //            equService.Insert(entity);
        //        }
        //    }

        //    this.pbEqu.Value = 100;
        //    this.lblEqu.Text = "下载完毕！";
        //    this.btnEqu.Enabled = true;
        //}

        //#endregion

        //#region 下载股票日线数据

        private void btnMktEqud_Click(object sender, EventArgs e)
        {
        //    this.pbMktEqud.Value = 0;
        //    this.lblMktEqud.Text = "下载中...";
        //    this.btnMktEqud.Enabled = false;

        //    Thread thread = new Thread(new ThreadStart(DownMktEqudData));
        //    thread.IsBackground = true;
        //    thread.Start();
        }

        //private void DownMktEqudData()
        //{
        //    IEquRepository equService = ImportService.EquService;
        //    List<string> allTickers = equService.GetAllCodes();
        //    if (allTickers == null)
        //    {
        //        this.lblMktEqud.Text = "数据库异常Q";
        //        this.btnMktEqud.Enabled = true;
        //        return;
        //    }

        //    int tickerIndex = 0;
        //    int tickersCount = allTickers.Count;
        //    IMktEqudRepository mktEqudService = ImportService.MktEqudService;

        //    while (allTickers.Count > 0)
        //    {
        //        List<string> allTickersCopy = Common.GetListCopy<string>(allTickers);
        //        foreach (string ticker in allTickersCopy)
        //        {
        //            this.pbMktEqud.Value = (tickerIndex * 100) / tickersCount;

        //            DateTime dtCurrent = Common.GetCurrentDataDate();
        //            string strBeginDate = Common.StartDateInputStr;
        //            string strEndDate = Common.GetInputDateFormat(dtCurrent);
        //            string lastTradeDate = mktEqudService.GetLastTradeDate(ticker);
        //            //数据库查询异常，先返回，避免插入重复数据
        //            if (lastTradeDate == null) 
        //            {
        //                continue;
        //            }
        //            if (lastTradeDate != string.Empty)
        //            {
        //                if (lastTradeDate == Common.GetOutputDateFormat(dtCurrent))
        //                {
        //                    allTickers.Remove(ticker);
        //                    this.lblMktEqud.Text = string.Format("{0}/{1}", ++tickerIndex, tickersCount);
        //                    continue;
        //                }
        //                else
        //                {
        //                    DateTime dtNewStartDay = Common.GetDateFromOutput(lastTradeDate).AddDays(1);
        //                    strBeginDate = Common.GetInputDateFormat(dtNewStartDay);
        //                }
        //            }

        //            string mktEqudUrl = string.Format(Wmcloud.MktEqudUrl, strBeginDate, strEndDate, ticker);
        //            string message = Wmcloud.GetDataFromUrl(mktEqudUrl);
        //            if (message == null)
        //            {
        //                Thread.Sleep(10000);
        //                continue;
        //            }

        //            //表示能正确返回API，但确实是无数据的
        //            if (message.Contains("No Data Returned"))
        //            {
        //                allTickers.Remove(ticker);
        //                this.lblMktEqud.Text = string.Format("{0}/{1}", ++tickerIndex, tickersCount);
        //                continue;
        //            }

        //            message = Wmcloud.GetJsonStrByMessage(message);
        //            List<MktEqud> mktEqudList = JsonHelper.JsonToList<MktEqud>(message);
        //            if (mktEqudService.Insert(mktEqudList))
        //            {
        //                allTickers.Remove(ticker);
        //                this.lblMktEqud.Text = string.Format("{0}/{1}", ++tickerIndex, tickersCount);
        //                continue;
        //            }
        //        }
        //    }

        //    this.pbMktEqud.Value = 100;
        //    this.lblMktEqud.Text = "下载完毕！";
        //    this.btnMktEqud.Enabled = true;
        //}

        //#endregion

        //#region 下载指数日线数据

        private void btnMktIdxd_Click(object sender, EventArgs e)
        {
        //    this.pbMktIdxd.Value = 0;
        //    this.lblMktIdxd.Text = "下载中...";
        //    this.btnMktIdxd.Enabled = false;

        //    Thread thread = new Thread(new ThreadStart(DownMktIdxdData));
        //    thread.IsBackground = true;
        //    thread.Start();
        }

        //private void DownMktIdxdData()
        //{
        //    IMktIdxdRepository mktIdxdService = ImportService.MktIdxdService;
        //    List<string> mktIdxTickers = new List<string>() { "000001", "399001", "399006", "399005" };

        //    int tickerIndex = 0;
        //    int tickersCount = mktIdxTickers.Count;

        //    while (mktIdxTickers.Count > 0)
        //    {
        //        List<string> mktIdxTickersCopy = Common.GetListCopy<string>(mktIdxTickers);
        //        foreach (string ticker in mktIdxTickersCopy)
        //        {
        //            this.pbMktIdxd.Value = (tickerIndex * 100) / tickersCount;

        //            DateTime dtCurrent = Common.GetCurrentDataDate();
        //            string strBeginDate = Common.StartDateInputStr;                    
        //            string strEndDate = Common.GetInputDateFormat(dtCurrent);
        //            string lastTradeDate = mktIdxdService.GetLastTradeDateByCode(ticker);
        //            //数据库查询异常，先返回，避免插入重复数据
        //            if (lastTradeDate == null)
        //            {
        //                continue;
        //            }
        //            if (lastTradeDate != string.Empty)
        //            {
        //                if (lastTradeDate == Common.GetOutputDateFormat(dtCurrent))
        //                {
        //                    mktIdxTickers.Remove(ticker);
        //                    this.lblMktIdxd.Text = string.Format("{0}/{1}", ++tickerIndex, tickersCount);
        //                    continue;
        //                }
        //                else
        //                {
        //                    DateTime dtNewStartDay = Common.GetDateFromOutput(lastTradeDate).AddDays(1);
        //                    strBeginDate = Common.GetInputDateFormat(dtNewStartDay);
        //                }
        //            }

        //            string mktIdxdUrl = string.Format(Wmcloud.MktIdxdUrl, strBeginDate, strEndDate, ticker);
        //            string message = Wmcloud.GetDataFromUrl(mktIdxdUrl);
        //            if (message == null)
        //            {
        //                Thread.Sleep(10000);
        //                continue;
        //            }

        //            //表示能正确返回API，但确实是无数据的
        //            if (message.Contains("No Data Returned"))
        //            {
        //                mktIdxTickers.Remove(ticker);
        //                this.lblMktIdxd.Text = string.Format("{0}/{1}", ++tickerIndex, tickersCount);
        //                continue;
        //            }

        //            message = Wmcloud.GetJsonStrByMessage(message);
        //            List<MktIdxd> mktIdxdList = JsonHelper.JsonToList<MktIdxd>(message);
        //            if (mktIdxdService.Insert(mktIdxdList))
        //            {
        //                mktIdxTickers.Remove(ticker);
        //                this.lblMktIdxd.Text = string.Format("{0}/{1}", ++tickerIndex, tickersCount);
        //                continue;
        //            }
        //        }
        //    }

        //    this.pbMktIdxd.Value = 100;
        //    this.lblMktIdxd.Text = "下载完毕！";
        //    this.btnMktIdxd.Enabled = true;
        //}

        //#endregion

        #region 机构控盘度数据下载

        private void btnOrgPercent_Click(object sender, EventArgs e)
        {
            this.pbOrgPercent.Value = 0;
            this.lblOrgPercent.Text = "下载中...";
            this.btnOrgPercent.Enabled = false;

            Thread thread = new Thread(new ThreadStart(DownOrgPercentData));
            thread.IsBackground = true;
            thread.Start();
        }

        private void DownOrgPercentData()
        {
            List<string> allTickers = ImportService.GetAllCodes();
            if (allTickers == null)
            {
                this.lblMktEqud.Text = "数据库异常Q";
                this.btnMktEqud.Enabled = true;
                return;
            }

            int tickerIndex = 0;
            int tickersCount = allTickers.Count;

            while (allTickers.Count > 0)
            {
                string testUrl = string.Format(Eastmoney.OrgPercentUrl, "600000");
                string message = Eastmoney.GetDataFromUrl(testUrl);
                if (message == null)
                {
                    Thread.Sleep(10000);
                    continue;
                }

                //获取当前交易日所有股票机构控盘度数据
                List<OrgPercent> orgList = ImportService.GetOrgList(message.Substring(message.IndexOf("数据日期") + 5, 10));

                //重新生成所有股票代码的副本列表
                List<string> allTickersCopy = Common.GetListCopy<string>(allTickers);
                foreach (string ticker in allTickersCopy)
                {
                    this.pbOrgPercent.Value = (tickerIndex * 100) / tickersCount;
                    OrgPercent findPercent = orgList.Find(p => p.Code == ticker);
                    if (findPercent == null)
                    {
                        testUrl = string.Format(Eastmoney.OrgPercentUrl, ticker);
                        message = Eastmoney.GetDataFromUrl(testUrl);
                        if (message == null)
                        {
                            Thread.Sleep(10000);
                            continue;
                        }
                        //停牌的股票是有所有数据的的，但有些新上市的股票是没有机构参与度数据的；
                        if (message.Contains("数据日期") && message.Contains("机构参与度为"))
                        {
                            string strDataTime = message.Substring(message.IndexOf("数据日期") + 5, 10);
                            string strOrgPercent = message.Substring(message.IndexOf("机构参与度为") + 6, 10).Split('%')[0];
                            if (Common.IsDateTime(strDataTime) && Common.IsFloat(strOrgPercent))
                            {
                                OrgPercent newOrg = new OrgPercent();
                                newOrg.Code = ticker;
                                newOrg.Day = strDataTime;
                                newOrg.Value = float.Parse(strOrgPercent);
                                newOrg.Zhuli = double.Parse(message.Substring(message.IndexOf("主力净流入") + 5, 100).Split('>')[1].Split('<')[0]);
                                newOrg.Chaoda = double.Parse(message.Substring(message.IndexOf("超大单流入") + 5, 100).Split('>')[1].Split('<')[0]);
                                if (!ImportService.AddNewOrg(newOrg))
                                {
                                    Thread.Sleep(1024);
                                    continue;
                                }
                            }
                        }
                        //避免频繁访问网页被禁
                        Thread.Sleep(1024);
                    }
                    //只要能正常返回网页数据，哪怕新上市的新股没有机构参与度，也需要Remove
                    allTickers.Remove(ticker);
                    this.lblOrgPercent.Text = string.Format("{0}/{1}", ++tickerIndex, tickersCount);                                        
                }
            }

            Thread.Sleep(1024);
            this.pbOrgPercent.Value = 100;
            this.lblOrgPercent.Text = "下载完毕！";
            this.btnOrgPercent.Enabled = true;
        }

        #endregion

    }
}
