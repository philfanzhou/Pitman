using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.Infrastructure.Repository;
using Pitman.Infrastructure.EF.Repository;
using System.IO;
using Ore.Infrastructure.MarketData;

namespace Test.Infrastructure.EF.Repository
{
    [TestClass]
    public class SqlCeTest
    {
        private static string directory = Environment.CurrentDirectory + @"\Data\Day\Shanghai\";

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            if(Directory.Exists(directory) == false)
            {
                Directory.CreateDirectory(directory);
            }
        }

        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            string dir = Environment.CurrentDirectory + @"\Data";
            if (Directory.Exists(dir))
            {
                Directory.Delete(dir, true);
            }
        }

        [TestMethod]
        public void TestKLineReadAndWrite()
        {
            KLine insertData = new KLine()
            {
                Amount = 123214124,
                Close = 19.96,
                Open = 19.05,
                High = 19.98,
                Low = 19.01,
                Time = DateTime.Now.Date,
                Volume = 32342352352
            };
            
            string fileName = "600036_2015.sdf";
            string fullPath = Path.Combine(directory, fileName);

            // Add
            using (IRepositoryContext context = ContextFactory.Create(ContextType.KLine, fullPath))
            {
                var repository = new Repository<KLine>(context);
                repository.Add(insertData);
                repository.UnitOfWork.Commit();
            }

            // Read
            KLine readData;
            using (IRepositoryContext context = ContextFactory.Create(ContextType.KLine, fullPath))
            {
                var repository = new Repository<KLine>(context);
                readData = repository.Get(insertData.Time);
            }
            Assert.IsNotNull(readData);
            Assert.AreEqual(insertData.Time, readData.Time);

            // update
            KLine updatedData = readData;
            updatedData.Open = 100;
            using (IRepositoryContext context = ContextFactory.Create(ContextType.KLine, fullPath))
            {
                var repository = new Repository<KLine>(context);
                repository.Update(updatedData);
                repository.UnitOfWork.Commit();
            }
            // Read
            using (IRepositoryContext context = ContextFactory.Create(ContextType.KLine, fullPath))
            {
                var repository = new Repository<KLine>(context);
                readData = repository.Get(insertData.Time);
            }
            Assert.IsTrue(readData.Open - 100 < 0.0000001);
        }

        [TestMethod]
        public void TestSecurityReadAndWrite()
        {
            Security insertData = new Security()
            {
                Code = "600036",
                ShortName = "招商银行招商银行招商银行",
                Market = Market.XSHG,
                Type = SecurityType.Sotck
            };

            string fileName = "Security.sdf";
            string fullPath = Path.Combine(directory, fileName);

            // Add
            using (IRepositoryContext context = ContextFactory.Create(ContextType.Security, fullPath))
            {
                var repository = new Repository<Security>(context);
                repository.Add(insertData);
                repository.UnitOfWork.Commit();
            }

            // Read
            Security readData;
            using (IRepositoryContext context = ContextFactory.Create(ContextType.Security, fullPath))
            {
                var repository = new Repository<Security>(context);
                readData = repository.Get(insertData.Code);
            }
            Assert.IsNotNull(readData);
            Assert.AreEqual(insertData.ShortName, readData.ShortName);
        }
    }
}
