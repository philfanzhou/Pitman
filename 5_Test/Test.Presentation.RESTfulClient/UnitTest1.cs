using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pitman.Presentation.RESTfulClient;
using System.Linq;

namespace Test.Presentation.RESTfulClient
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var client = ClientFactory.CreateCollectionStatusClient();
            var result = client.GetAllServiceName().ToList();

            Assert.IsNotNull(result);

            var status = client.GetStatus(result[0]);
            Assert.IsNotNull(status);
        }
    }
}
