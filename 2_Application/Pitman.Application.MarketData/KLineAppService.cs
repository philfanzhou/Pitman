using Ore.Infrastructure.MarketData;
using Pitman.Domain.FileStructure;
using Pitman.Infrastructure.SqlCe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pitman.Application.MarketData
{
    public class KLineAppService
    {
        public bool Exists(KLineType type, string stockCode, IStockKLine kLine)
        {
            ThrowIfTypeNotSupport(type);

            // 获取数据文件路径
            string dbFilePath = null;
            if(type == KLineType.Day)
            {
                dbFilePath = new Day1KLineFile(stockCode).GetFilePath();
            }
            else if(type == KLineType.Min1)
            {
                dbFilePath = new Min1KLineFile(stockCode).GetFilePath(kLine.Time);
            }
            else if(type == KLineType.Min5)
            {
                dbFilePath = new Min5KLineFile(stockCode).GetFilePath(kLine.Time);
            }

            if (!string.IsNullOrEmpty(dbFilePath))
            {
                KLineRepository repository = new KLineRepository(dbFilePath);
                return repository.Exists(kLine);
            }
            else
            {
                return false;
            }
        }

        public DateTime? GetLastTradeDate(KLineType type, string stockCode)
        {
            ThrowIfTypeNotSupport(type);

            if (type == KLineType.Day)
            {
                string dbFilePath = new Day1KLineFile(stockCode).GetFilePath();
                KLineRepository repository = new KLineRepository(dbFilePath);
                return repository.GetLastTradeDate();
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        public void Add(KLineType type, string stockCode, IStockKLine kLine)
        {
            Add(type, stockCode, new List<IStockKLine> { kLine });
        }
        
        public void Add(KLineType type, string stockCode, IEnumerable<IStockKLine> kLines)
        {
            ThrowIfTypeNotSupport(type);

            if(type == KLineType.Day)
            {
                string dbFilePath = new Day1KLineFile(stockCode).GetFilePath();
                KLineRepository repository = new KLineRepository(dbFilePath);
                repository.AddRange(kLines);
            }
            else
            {
                Year1KLineFile file = null;
                if(type == KLineType.Min1)
                {
                    file = new Min1KLineFile(stockCode);
                }
                else
                {
                    file = new Min5KLineFile(stockCode);
                }
                var packages = file.SplitToPackages(kLines);

                // 插入所有数据
                foreach (var package in packages)
                {
                    // 获取数据文件路径
                    string dbFilePath = file.GetFilePath(package);

                    KLineRepository repository = new KLineRepository(dbFilePath);
                    repository.AddRange(package.Items);
                }
            }
        }      

        public void Update(KLineType type, string stockCode, IStockKLine kLine)
        {
            Update(type, stockCode, new List<IStockKLine> { kLine });
        }

        public void Update(KLineType type, string stockCode, IEnumerable<IStockKLine> kLines)
        {
            ThrowIfTypeNotSupport(type);

            if (type == KLineType.Day)
            {
                string dbFilePath = new Day1KLineFile(stockCode).GetFilePath();
                KLineRepository repository = new KLineRepository(dbFilePath);
                repository.UpdateRange(kLines);
            }
            else
            {
                Year1KLineFile file = null;
                if (type == KLineType.Min1)
                {
                    file = new Min1KLineFile(stockCode);
                }
                else
                {
                    file = new Min5KLineFile(stockCode);
                }
                var packages = file.SplitToPackages(kLines);

                // 插入所有数据
                foreach (var package in packages)
                {
                    // 获取数据文件路径
                    string dbFilePath = file.GetFilePath(package);

                    KLineRepository repository = new KLineRepository(dbFilePath);
                    repository.UpdateRange(package.Items);
                }
            }
        }

        public IEnumerable<IStockKLine> Get(
            KLineType type, string stockCode, 
            DateTime startTime, DateTime endTime)
        {
            ThrowIfTypeNotSupport(type);

            /*
            注意需要考虑到：
            1：如果查询的时间跨度很长，记录可能存放于不同的文件中，需要进行查询结果的拼接。
            2：同理在获取Context，以及FilePath的时候，也需要考虑时间跨度导致的多文件处理。
            */
            List<IStockKLine> result = new List<IStockKLine>();

            if (type == KLineType.Day)
            {
                string dbFilePath = new Day1KLineFile(stockCode).GetFilePath();
                KLineRepository repository = new KLineRepository(dbFilePath);
                result.AddRange(repository.Get(startTime, endTime));
            }
            else
            {
                Year1KLineFile file = null;
                if (type == KLineType.Min1)
                {
                    file = new Min1KLineFile(stockCode);
                }
                else
                {
                    file = new Min5KLineFile(stockCode);
                }
                var files = file.GetFilePath(startTime, endTime);

                // 插入所有数据
                foreach (var dbFilePath in files)
                {
                    // 获取数据文件路径

                    KLineRepository repository = new KLineRepository(dbFilePath);
                    result.AddRange(repository.Get(startTime, endTime));
                }
            }

            return result;
        }

        private void ThrowIfTypeNotSupport(KLineType type)
        {
            if (type != KLineType.Day &&
                type != KLineType.Min1 &&
                type != KLineType.Min5)
            {
                throw new NotSupportedException();
            }
        }
    }
}
