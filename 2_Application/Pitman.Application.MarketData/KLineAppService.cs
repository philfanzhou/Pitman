using Framework.Infrastructure.Repository;
using Ore.Infrastructure.MarketData;
using Pitman.Infrastructure.EF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitman.Domain.FileStructure;

namespace Pitman.Application.MarketData
{
    public class KLineAppService
    {
        public bool Exists(KLineType type, string stockCode, IStockKLine kLine)
        {
            // 设置查询条件
            var spec = Specification<KLineDbo>.Eval(p => p.Time.Equals(kLine.Time));
            using (var context = GetContext(type, stockCode, kLine.Time))
            {
                var repository = new Repository<KLineDbo>(context);
                return repository.Exists(spec);
            }
        }

        public void Add(KLineType type, string stockCode, IStockKLine kLine)
        {
            DateTime dtDebug = DateTime.Now;
            using (var context = GetContext(type, stockCode, kLine.Time))
            {
                System.Diagnostics.Debug.Print("GetContext:" + (DateTime.Now - dtDebug).TotalMilliseconds.ToString());
                dtDebug = DateTime.Now;

                var repository = new Repository<KLineDbo>(context);
                System.Diagnostics.Debug.Print("Repository:" + (DateTime.Now - dtDebug).TotalMilliseconds.ToString());
                dtDebug = DateTime.Now;

                repository.Add(ConvertToDbo(kLine));
                System.Diagnostics.Debug.Print("repository.Add:" + (DateTime.Now - dtDebug).TotalMilliseconds.ToString());
                dtDebug = DateTime.Now;

                repository.UnitOfWork.Commit();//每条提交一次，效率很低
                System.Diagnostics.Debug.Print("repository.UnitOfWork.Commit:" + (DateTime.Now - dtDebug).TotalMilliseconds.ToString());
                dtDebug = DateTime.Now;
            }
        }
        
        public void Add(KLineType type, string stockCode, IEnumerable<IStockKLine> kLines)
        {


            //DateTime dtDebug = DateTime.Now;

            //using (var context = GetContext(type, stockCode, kLine.Time))
            //{
            //    System.Diagnostics.Debug.Print("GetContext:" + (DateTime.Now - dtDebug).TotalMilliseconds.ToString());
            //    dtDebug = DateTime.Now;

            //    var repository = new Repository<KLineDbo>(context);
            //    System.Diagnostics.Debug.Print("Repository:" + (DateTime.Now - dtDebug).TotalMilliseconds.ToString());
            //    dtDebug = DateTime.Now;

            //    repository.Add(ConvertToDbo(kLine));
            //    System.Diagnostics.Debug.Print("repository.Add:" + (DateTime.Now - dtDebug).TotalMilliseconds.ToString());
            //    dtDebug = DateTime.Now;

            //    repository.UnitOfWork.Commit();//每条提交一次，效率很低
            //    System.Diagnostics.Debug.Print("repository.UnitOfWork.Commit:" + (DateTime.Now - dtDebug).TotalMilliseconds.ToString());
            //    dtDebug = DateTime.Now;
            //}
        }      

        public void Update(KLineType type, string stockCode, IStockKLine kLine)
        {
            using (var context = GetContext(type, stockCode, kLine.Time))
            {
                var repository = new Repository<KLineDbo>(context);
                repository.Update(ConvertToDbo(kLine));
                repository.UnitOfWork.Commit();
            }
        }

        public IEnumerable<IStockKLine> Get(KLineType type, string stockCode, DateTime startTime, DateTime endTime)
        {
            /*
            注意需要考虑到：
            1：如果查询的时间跨度很长，记录可能存放于不同的文件中，需要进行查询结果的拼接。
            2：同理在获取Context，以及FilePath的时候，也需要考虑时间跨度导致的多文件处理。
            */
            // 设置查询条件
            var spec = Specification<KLineDbo>.Eval(p => p.Time >= startTime && p.Time <= endTime);

            List<IStockKLine> lstQuery = new List<IStockKLine>();
            var contexts = GetContext(type, stockCode, startTime, endTime);
            foreach(var context in contexts)
            {
                var repository = new Repository<KLineDbo>(context);
                lstQuery.AddRange(repository.GetAll(spec));
            }

            return lstQuery;
        }

        private IRepositoryContext GetContext(KLineType type, string stockCode, DateTime dt)
        {
            string fullPath = DataFiles.GetKLineFiles(type, stockCode, dt);
            IRepositoryContext context
                = ContextFactory.Create(ContextType.KLine, fullPath);

            return context;
        }

        private IEnumerable<IRepositoryContext> GetContext(KLineType type, string stockCode, DateTime startTime, DateTime endTime)
        {
            /*因为时间跨度可能导致多个存储文件，所以这里的Context返回是一个集合*/
            var fullPaths = DataFiles.GetKLineFiles(type, stockCode, startTime, endTime);
            List<IRepositoryContext> lstRepositoryContext = new List<IRepositoryContext>();
            foreach (var it in fullPaths)
                lstRepositoryContext.Add(ContextFactory.Create(ContextType.KLine, it));

            return lstRepositoryContext;
        }

        private static KLineDbo ConvertToDbo(IStockKLine self)
        {
            KLineDbo outputData = new KLineDbo
            {
                //
                // 摘要:
                //     成交额
                Amount = self.Amount,
                //
                // 摘要:
                //     收盘
                Close = self.Close,
                //
                // 摘要:
                //     最高
                High = self.High,
                //
                // 摘要:
                //     最低
                Low = self.Low,
                //
                // 摘要:
                //     今开
                Open = self.Open,
                //
                // 摘要:
                //     日期与时间
                Time = self.Time,
                //
                // 摘要:
                //     成交量
                Volume = self.Volume
            };

            return outputData;
        }
    }
}
