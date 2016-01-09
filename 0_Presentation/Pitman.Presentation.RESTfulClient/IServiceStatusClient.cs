using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Presentation.RESTfulClient
{
    public interface IServiceStatusClient
    {
        IEnumerable<string> GetAllServiceName();

        string GetServiceStatus(string serviceName);
    }
}
