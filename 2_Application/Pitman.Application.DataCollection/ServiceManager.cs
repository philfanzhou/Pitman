using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Pitman.Application.DataCollection
{
    public class ServiceManager
    {
        private Dictionary<string, CollectionService> _serviceContainer 
            = new Dictionary<string, CollectionService>();
        
        private readonly Timer _heartbeatTimer = new Timer(30000);

        public ServiceManager()
        {
            _heartbeatTimer.Elapsed += HeartbeatTimer_Elapsed;

            var security = new Security();
            _serviceContainer.Add(security.ServiceName, security);
        }

        public IEnumerable<string> GetAllServiceName()
        {
            return _serviceContainer.Keys;
        }

        public string GetServiceStatus(string serviceName)
        {
            string result = string.Empty;
            CollectionService service;
            if (_serviceContainer.TryGetValue(serviceName, out service))
            {
                result = service.GetStatusReport();
            }

            return result;
        }

        public void Start()
        {
            _heartbeatTimer.Enabled = true;
            _heartbeatTimer.Start();
        }

        private void HeartbeatTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _heartbeatTimer.Enabled = false;
            
            foreach (var service in _serviceContainer.Values)
            {
                service.Heartbeat();
            }

            _heartbeatTimer.Enabled = true;
        }
    }
}
