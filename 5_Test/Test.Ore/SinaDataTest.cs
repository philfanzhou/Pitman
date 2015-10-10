using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ore.Infrastructure.MarketData.Implementation;
using System.Collections.Generic;

namespace Test.Ore
{
    [TestClass]
    public class SinaDataTest
    {
        [TestMethod]
        public void SinaRealTimeDataConstructorTest()
        {
            SinaDataReader reader = new SinaDataReader();
            SinaRealTimeData data = reader.GetData("sh600036");
            Assert.IsNotNull(data);
            Assert.AreEqual("sh600036", data.Code);
            Assert.AreEqual("招商银行", data.Name);

            data = null;
            data = reader.GetData("sz399001");
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void GetMultipleDataTest()
        {
            string[] codes = new string[] { "sh600036","sz150209","sh600518","sz300118","sh600298","sh601009","sh601933","sh600660","sh600196" };
            SinaDataReader reader = new SinaDataReader();
            IEnumerable<SinaRealTimeData> datas = reader.GetData(codes);

            Assert.IsNotNull(datas);
            foreach(SinaRealTimeData data in datas)
            {
                Assert.IsNotNull(data);
            }
        }
    }
}
