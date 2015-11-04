using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pitman.Presentation.RESTfulClient;

namespace Test.Presentation.RESTfulClient
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var client = ClientFactory.CreateCollectionStatusClient();
            var result = client.GetAllServiceName();

            Assert.IsNotNull(result);
        }
    }
}
