using System.Collections.Generic;
using System.Timers;

namespace Pitman.Application.DataCollection
{
    internal class ServiceManager : IServiceManager
    {
        #region Field
        private Dictionary<string, CollectionService> _serviceContainer 
            = new Dictionary<string, CollectionService>();
        
        private readonly Timer _heartbeatTimer = new Timer(30000);
        #endregion

        #region Public Method
        public void StartService()
        {
            InitServices();

            _heartbeatTimer.Elapsed += HeartbeatTimer_Elapsed;
            _heartbeatTimer.Enabled = true;
            _heartbeatTimer.Start();
        }

        public void StopService()
        {
            _heartbeatTimer.Elapsed -= HeartbeatTimer_Elapsed;
            _heartbeatTimer.Enabled = false;
            _heartbeatTimer.Stop();
        }
        #endregion

        #region Private Method
        private void InitServices()
        {
#if DEBUG
            var serviceForTest = new ServiceForTest();
            _serviceContainer.Add(serviceForTest.ServiceName, serviceForTest);
#endif

            var security = new SecurityService();
            _serviceContainer.Add(security.ServiceName, security);
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
        #endregion

        #region IServiceManager Member
        IEnumerable<string> IServiceManager.GetAllServiceName()
        {
            return _serviceContainer.Keys;
        }

        string IServiceManager.GetServiceStatus(string serviceName)
        {
            string result = string.Empty;
            CollectionService service;
            if (_serviceContainer.TryGetValue(serviceName, out service))
            {
                result = service.GetStatusReport();
            }

            return result;
        }
        #endregion
    }
}
