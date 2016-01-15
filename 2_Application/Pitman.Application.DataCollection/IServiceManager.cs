using System.Collections.Generic;

namespace Pitman.Application.DataCollection
{
    public interface IServiceManager
    {
        IEnumerable<string> GetAllServiceName();

        string GetServiceStatus(string serviceName);
    }
}
