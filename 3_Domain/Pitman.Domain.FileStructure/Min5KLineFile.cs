using Ore.Infrastructure.MarketData;
using Quantum.Domain.TimeSeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Domain.FileStructure
{
    /// <summary>
    /// 5分钟K线采用：每票一年一个文件的方式存储
    /// </summary>
    public class Min5KLineFile : Year1KLineFile
    {
        private const string _strType = "Min5";

        public Min5KLineFile(string stockCode) : base(stockCode) { }

        protected override string StrKLineType
        {
            get
            {
                return _strType;
            }
        }
    }
}
