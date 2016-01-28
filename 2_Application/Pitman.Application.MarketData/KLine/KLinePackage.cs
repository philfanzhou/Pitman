using Ore.Infrastructure.MarketData;
using Pitman.Domain.FileStructure;
using System.Collections.Generic;

namespace Pitman.Application.MarketData
{
    internal class KLinePackage
    {
        #region Field
        private readonly KLineFileInfo _fileInfo;
        private List<IStockKLine> _kLineList = new List<IStockKLine>();
        #endregion

        #region Constructor
        public KLinePackage(KLineFileInfo fileInfo)
        {
            _fileInfo = fileInfo;
        }
        #endregion

        #region Property
        public KLineFileInfo FileInfo { get { return _fileInfo; } }

        public IEnumerable<IStockKLine> KLines { get { return _kLineList; } }
        #endregion

        #region Public Method
        public void Add(IStockKLine kLine)
        {
            _kLineList.Add(kLine);
        }

        public static IEnumerable<KLinePackage> SplitToPackages(KLineType type, string stockCode, IEnumerable<IStockKLine> kLines)
        {
            List<KLinePackage> packages = new List<KLinePackage>();

            // 将数据分别放到对应的包裹里面
            foreach (var kLine in kLines)
            {
                bool processed = false;

                // 检查是否能够将数据插入到已有包裹
                foreach (var package in packages)
                {
                    if (package.FileInfo.ContainsTime(kLine.Time))
                    {
                        package.Add(kLine);
                        processed = true;
                        break;
                    }
                }

                // 如果已有包裹无法插入数据，新建包裹
                if (!processed)
                {
                    KLineFileInfo fileInfo = DataFiles.GetKLineFileInfo(type, stockCode, kLine.Time);
                    KLinePackage package = new KLinePackage(fileInfo);
                    package.Add(kLine);
                    packages.Add(package);
                }
            }

            return packages;
        }
        #endregion
    }
}
