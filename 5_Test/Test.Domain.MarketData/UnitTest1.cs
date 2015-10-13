using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pitman.Application.MarketData;

namespace Test.Domain.MarketData
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            RealTimePriceServices service = new RealTimePriceServices();

            DateTime time090959 = DateTime.Now.Date.AddHours(9).AddMinutes(9).AddSeconds(59);
            Assert.IsFalse(service.IsWorkingTime(time090959));

            DateTime time091001 = DateTime.Now.Date.AddHours(9).AddMinutes(10).AddSeconds(1);
            Assert.IsTrue(service.IsWorkingTime(time091001));

            DateTime time101001 = DateTime.Now.Date.AddHours(10).AddMinutes(10).AddSeconds(1);
            Assert.IsTrue(service.IsWorkingTime(time101001));

            DateTime time141001 = DateTime.Now.Date.AddHours(14).AddMinutes(10).AddSeconds(1);
            Assert.IsTrue(service.IsWorkingTime(time141001));

            DateTime time151501 = DateTime.Now.Date.AddHours(15).AddMinutes(15).AddSeconds(1);
            Assert.IsFalse(service.IsWorkingTime(time151501));

            service.Start();

            do
            {
                System.Threading.Thread.Sleep(500);

            } while (DateTime.Now.Hour < 24);
        }
    }
}
