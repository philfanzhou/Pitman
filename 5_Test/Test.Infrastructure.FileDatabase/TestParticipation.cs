using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ore.Infrastructure.MarketData;
using Pitman.Infrastructure.FileDatabase;

namespace Test.Infrastructure.FileDatabase
{
    [TestClass]
    public class TestParticipation
    {
        private void CompareDataField(IParticipation expected, IParticipation actual)
        {
            //Assert.AreEqual(expected.Code, actual.Code);
            Assert.AreEqual(expected.CostPrice1Day, actual.CostPrice1Day);
            Assert.AreEqual(expected.CostPrice20Day, actual.CostPrice20Day);
            Assert.AreEqual(expected.MainForceInflows, actual.MainForceInflows);
            Assert.AreEqual(expected.SuperLargeInflows, actual.SuperLargeInflows);
            Assert.AreEqual(expected.Time, actual.Time);
            Assert.AreEqual(expected.Value, actual.Value);
        }

        private IParticipation ExampleParticipation_600036(DateTime day)
        {
            return new ParticipationDataItem
            {
                Code = "600036",
                CostPrice1Day = 16.37,
                CostPrice20Day = 17.62,
                MainForceInflows = -18890.18,
                SuperLargeInflows = -13224.41,
                Time = day,
                Value = 37.97
            };
        }

        private IParticipation ExampleParticipation_600518(DateTime day)
        {
            return new ParticipationDataItem
            {
                Code = "600518",
                CostPrice1Day = 14.09,
                CostPrice20Day = 16.67,
                MainForceInflows = -11838.97,
                SuperLargeInflows = -4277.92,
                Time = day,
                Value = 34.32
            };
        }

        //[TestMethod]
        //public void TestMethod1()
        //{
        //    var example_600036_20160101 = ExampleParticipation_600036(new DateTime(2016, 1, 1));
        //    var example_600036_20160105 = ExampleParticipation_600036(new DateTime(2016, 1, 5));
        //    var example_600036_20160111 = ExampleParticipation_600036(new DateTime(2016, 1, 11));

        //    var example_600518_20160101 = ExampleParticipation_600518(new DateTime(2016, 1, 1));
        //    var example_600518_20160102 = ExampleParticipation_600518(new DateTime(2016, 1, 2));
        //    var example_600518_20160110 = ExampleParticipation_600518(new DateTime(2016, 1, 10));
        //    var example_600518_20160111 = ExampleParticipation_600518(new DateTime(2016, 1, 11));

        //    var repository = new ParticipationDataRepository();

        //    if (!repository.Exists(example_600036_20160101))
        //    {
        //        repository.Add(example_600036_20160101);
        //    }
        //    if (!repository.Exists(example_600036_20160105))
        //    {
        //        repository.Add(example_600036_20160105);
        //    }
        //    if (!repository.Exists(example_600036_20160111))
        //    {
        //        repository.Add(example_600036_20160111);
        //    }

        //    if (!repository.Exists(example_600518_20160101))
        //    {
        //        repository.Add(example_600518_20160101);
        //    }
        //    if (!repository.Exists(example_600518_20160102))
        //    {
        //        repository.Add(example_600518_20160102);
        //    }
        //    if (!repository.Exists(example_600518_20160110))
        //    {
        //        repository.Add(example_600518_20160110);
        //    }
        //    if (!repository.Exists(example_600518_20160111))
        //    {
        //        repository.Add(example_600518_20160111);
        //    }

        //    var datas_600036 = repository.GetData("600036").ToList();
        //    Assert.IsNotNull(datas_600036);
        //    Assert.IsTrue(datas_600036.Count == 3);

        //    var datas_600518 = repository.GetData("600518").ToList();
        //    Assert.IsNotNull(datas_600518);
        //    Assert.IsTrue(datas_600518.Count == 4);

        //    var latest_600036 = repository.GetLatest("600036");
        //    CompareDataField(example_600036_20160111, latest_600036);

        //    var latest_600518 = repository.GetLatest("600518");
        //    CompareDataField(example_600518_20160111, latest_600518);
        //}
    }
}
