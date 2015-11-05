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
            //string hostName = "http://quantum1234.cloudapp.net:6688";
            string hostName = "http://localhost:9999";
            var client = ClientFactory.CreateCollectionStatusClient(hostName);
            var result = client.GetAllServiceName().ToList();

            Assert.IsNotNull(result);

            var status = client.GetStatus(result[0]);
            Assert.IsNotNull(status);
        }
    }
}
