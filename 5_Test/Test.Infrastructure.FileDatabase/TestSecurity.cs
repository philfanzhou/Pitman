using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ore.Infrastructure.MarketData;
using Pitman.Infrastructure.FileDatabase;

namespace Test.Infrastructure.FileDatabase
{
    [TestClass]
    public class TestSecurity
    {        
        private List<ISecurity> ExampleSecurities()
        {
            return new List<ISecurity>()
            {
                new SecurityItem { Code = "166105", Market = Market.XSHG, ShortName =  "信达增利", Type = SecurityType.Sotck },
                new SecurityItem { Code = "201000", Market = Market.XSHG, ShortName =  "R003", Type = SecurityType.Sotck },
                new SecurityItem { Code = "600006", Market = Market.XSHG, ShortName =  "东风汽车", Type = SecurityType.Sotck },
                new SecurityItem { Code = "600518", Market = Market.XSHG, ShortName =  "康美药业", Type = SecurityType.Sotck },
                new SecurityItem { Code = "600036", Market = Market.XSHG, ShortName =  "招商银行", Type = SecurityType.Sotck },
                new SecurityItem { Code = "600298", Market = Market.XSHG, ShortName =  "安琪酵母", Type = SecurityType.Sotck },
                new SecurityItem { Code = "601933", Market = Market.XSHG, ShortName =  "永辉超市", Type = SecurityType.Sotck },
                new SecurityItem { Code = "600660", Market = Market.XSHG, ShortName =  "福耀玻璃", Type = SecurityType.Sotck },
                new SecurityItem { Code = "600196", Market = Market.XSHG, ShortName =  "复星医药", Type = SecurityType.Sotck },

                new SecurityItem { Code = "300118", Market = Market.XSHE, ShortName =  "东方日升", Type = SecurityType.Sotck },
                new SecurityItem { Code = "000800", Market = Market.XSHE, ShortName =  "一汽轿车", Type = SecurityType.Sotck },
                new SecurityItem { Code = "002122", Market = Market.XSHE, ShortName =  "天马股份", Type = SecurityType.Sotck },
                new SecurityItem { Code = "300490", Market = Market.XSHE, ShortName =  "华自科技", Type = SecurityType.Sotck },
                new SecurityItem { Code = "300477", Market = Market.XSHE, ShortName =  "合纵科技", Type = SecurityType.Sotck }
            };
        }

        [TestMethod]
        public void TestMethod1()
        {
            var securities = ExampleSecurities();

            var repository = new SecurityDataRepository();            
            foreach(var item in securities)
            {
                if (!repository.Exists(item.Code))
                    repository.Add(item);
            }

            var lstAll = repository.GetDataAll().ToList();
            Assert.IsNotNull(lstAll);
            Assert.IsTrue(lstAll.Count == 14);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var repository = new SecurityDataRepository();

            Assert.IsTrue(repository.Exists("600518"));

            var it_600518 = repository.GetData("600518");
            Assert.IsNotNull(it_600518);
            Assert.IsTrue(it_600518.ShortName == "康美药业");

            var it_600036 = repository.GetData("600036");
            Assert.IsNotNull(it_600036);
            Assert.IsTrue(it_600036.ShortName == "招商银行");

            var it_600298 = repository.GetData("600298");
            Assert.IsNotNull(it_600298);
            Assert.IsTrue(it_600298.ShortName == "安琪酵母");

            var it_601933 = repository.GetData("601933");
            Assert.IsNotNull(it_601933);
            Assert.IsTrue(it_601933.ShortName == "永辉超市");

            var it_600660 = repository.GetData("600660");
            Assert.IsNotNull(it_600660);
            Assert.IsTrue(it_600660.ShortName == "福耀玻璃");

            var it_600196 = repository.GetData("600196");
            Assert.IsNotNull(it_600196);
            Assert.IsTrue(it_600196.ShortName == "复星医药");

            var it_300118 = repository.GetData("300118");
            Assert.IsNotNull(it_300118);
            Assert.IsTrue(it_300118.ShortName == "东方日升");

            var it_000800 = repository.GetData("000800");
            Assert.IsNotNull(it_000800);
            Assert.IsTrue(it_000800.ShortName == "一汽轿车");            

            List <string> stockCodes = new List<string>();
            stockCodes.Add("600518");//康美药业
            stockCodes.Add("600036");//招商银行
            stockCodes.Add("600298");//安琪酵母
            stockCodes.Add("601933");//永辉超市
            stockCodes.Add("600660");//福耀玻璃
            stockCodes.Add("600196");//复星医药
            stockCodes.Add("300118");//东方日升
            stockCodes.Add("000800");//一汽轿车

            var lstSecurity = repository.GetData(stockCodes).ToList();

            Assert.IsNotNull(lstSecurity);
            Assert.AreEqual(lstSecurity.Count, stockCodes.Count);
        }
    }
}
