using Ore.Infrastructure.MarketData;
using Quantum.Domain.TimeSeries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Pitman.Domain.FileStructure
{
    /// <summary>
    /// 1分钟K线采用：每票一年一个文件的方式存储
    /// </summary>
    public class Min1KLineFile : Year1KLineFile
    {
        private const string _strType = "Min1";

        public Min1KLineFile(string stockCode) : base(stockCode) { }

        protected override string StrKLineType
        {
            get
            {
                return _strType;
            }
        }
    }
}
