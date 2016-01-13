using System.Collections.Generic;
using System.Web.Http;

namespace Pitman.Distributed.WebApi
{
    public class CollectionStatusController : ApiController
    {
        public IEnumerable<string> Get()
        {
#if DEBUG
            /*test code for communication * ************************************/
            var result = new List<string>();
            result.Add("testServiceName");
            return result;
            /*test code for communication************************************/
#endif
            throw new System.NotImplementedException();
        }

        public string Get(string serviceName)
        {
#if DEBUG
            /*test code for communication * ************************************/
            return "test service status   " + serviceName;
            /*test code for communication************************************/
#endif
            throw new System.NotImplementedException();
        }
    }
}
