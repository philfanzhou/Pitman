﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pitman.DataReader;
using Pitman.Metadata;
using System.Collections.Generic;

namespace Quantum.Data.DataReader.Test
{
    [TestClass]
    public class DataReaderTest
    {
        [TestMethod]
        public void SinaRealTimeDataConstructorTest()
        {
            IRealTimeDataReader reader = DataReaderCreator.Create();
            RealTimeData data = reader.GetData("sh600036");
            Assert.IsNotNull(data);

            data = null;
            data = reader.GetData("sz399001");
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void GetMultipleDataTest()
        {
            string[] codes = new string[] { "sh600036","sz150209","sh600518","sz300118","sh600298","sh601009","sh601933","sh600660","sh600196" };
            IRealTimeDataReader reader = DataReaderCreator.Create();
            IEnumerable<RealTimeData> datas = reader.GetData(codes);

            Assert.IsNotNull(datas);
            foreach(RealTimeData data in datas)
            {
                Assert.IsNotNull(data);
            }
        }
    }
}
