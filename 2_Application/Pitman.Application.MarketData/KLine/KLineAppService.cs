using Framework.Infrastructure.Repository;
using Ore.Infrastructure.MarketData;
using Pitman.Domain.FileStructure;
using Pitman.Infrastructure.EF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pitman.Application.MarketData
{
    public class KLineAppService
    {
        public bool Exists(KLineType type, string stockCode, IStockKLine kLine)
        {
            // 获取数据文件路径
            string dbFilePath = DataFiles.GetKLineFiles(type, stockCode, kLine.Time);

            /***********如果不使用ef，这段代码可能需要重新考虑**********************/
            // 设置查询条件
            var spec = Specification<StockKLine>.Eval(p => p.Time.Equals(kLine.Time));
            /***************************************************************/

            /***********如果不使用ef，需要替换掉这部分代码**********************/
            using (var context = ContextFactory.Create(ContextType.KLine, dbFilePath))
            {
                var repository = new Repository<StockKLine>(context);
                return repository.Exists(spec);
            }
            /***********如果不使用ef，需要替换掉这部分代码**********************/
        }

        public void Add(KLineType type, string stockCode, IStockKLine kLine)
        {
            Add(type, stockCode, new List<IStockKLine> { kLine });
        }
        
        public void Add(KLineType type, string stockCode, IEnumerable<IStockKLine> kLines)
        {
            // 将数据分别放到对应的包裹里面
            List<KLinePackage> packages = KLinePackage.SplitToPackages(type, stockCode, kLines).ToList();

            // 插入所有数据
            foreach (var package in packages)
            {
                // 获取数据文件路径
                string dbFilePath = package.FileInfo.FullPath;

                /***********如果不使用ef，需要替换掉这部分代码**********************/
                using (var context = ContextFactory.Create(ContextType.KLine, dbFilePath))
                {
                    var repository = new Repository<StockKLine>(context);
                    repository.AddRange(kLines.ToDataObject());
                    repository.UnitOfWork.Commit();
                }
                /***********如果不使用ef，需要替换掉这部分代码**********************/
            }
        }      

        public void Update(KLineType type, string stockCode, IStockKLine kLine)
        {
            Update(type, stockCode, new List<IStockKLine> { kLine });
        }

        public void Update(KLineType type, string stockCode, IEnumerable<IStockKLine> kLines)
        {
            List<KLinePackage> packages = KLinePackage.SplitToPackages(type, stockCode, kLines).ToList();

            // 插入所有数据
            foreach (var package in packages)
            {
                // 获取数据文件路径
                string dbFilePath = package.FileInfo.FullPath;

                /***********如果不使用ef，需要替换掉这部分代码**********************/
                using (var context = ContextFactory.Create(ContextType.KLine, dbFilePath))
                {
                    var repository = new Repository<StockKLine>(context);
                    foreach (var kLine in package.KLines)
                    {
                        repository.Update(kLine.ToDataObject());
                    }

                    repository.UnitOfWork.Commit();
                }
                /***********如果不使用ef，需要替换掉这部分代码**********************/
            }
        }

        public IEnumerable<IStockKLine> Get(KLineType type, string stockCode, DateTime startTime, DateTime endTime)
        {
            /*
            注意需要考虑到：
            1：如果查询的时间跨度很长，记录可能存放于不同的文件中，需要进行查询结果的拼接。
            2：同理在获取Context，以及FilePath的时候，也需要考虑时间跨度导致的多文件处理。
            */
            List<IStockKLine> result = new List<IStockKLine>();

            // 根据查询时间，得出应该从哪些文件里面查询
            List<KLineFileInfo> kLineFileInfos = DataFiles.GetKLineFileInfo(type, stockCode, startTime, endTime).ToList();

            /***********如果不使用ef，这段代码可能需要重新考虑**********************/
            // 设置查询条件
            var spec = Specification<StockKLine>.Eval(p => p.Time >= startTime && p.Time <= endTime);
            /***************************************************************/

            // 查询所有文件中的数据
            foreach (var fileInfo in kLineFileInfos)
            {
                // 获取数据文件路径
                string dbFilePath = fileInfo.FullPath;

                /***********如果不使用ef，需要替换掉这部分代码**********************/
                using (var context = ContextFactory.Create(ContextType.KLine, dbFilePath))
                {
                    var repository = new Repository<StockKLine>(context);

                    // todo: 这个地方使用getall还存在问题，因为根据查询时间来查询，并不等于要把每个文件中的所有数据都取出来。
                    // 假如结束时间是在某个文件的中间一部分，那么getall就会把最后一个文件里面的所有数据都查出来
                    result.AddRange(repository.GetAll(spec));
                }
                /***********如果不使用ef，需要替换掉这部分代码**********************/
            }

            return result;
        }
    }
}
