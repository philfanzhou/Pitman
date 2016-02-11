﻿using System;
using System.Collections.Generic;
using System.Timers;

namespace Pitman.Application.DataCollection
{
    internal class ServiceManager : IServiceManager, IDisposable
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
            // todo: 停止所有服务

            _heartbeatTimer.Elapsed -= HeartbeatTimer_Elapsed;
            _heartbeatTimer.Enabled = false;
            _heartbeatTimer.Stop();
        }
        #endregion

        #region Private Method
        private void HeartbeatTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _heartbeatTimer.Enabled = false;
            
            foreach (var service in _serviceContainer.Values)
            {
                service.Heartbeat();
            }

            _heartbeatTimer.Enabled = true;
        }

        private void InitServices()
        {
            var security = new SecurityService();
            _serviceContainer.Add(security.ServiceName, security);

            var kLinDay = new KLineDayService();
            _serviceContainer.Add(kLinDay.ServiceName, kLinDay);

            //var kLineMin1Min5 = new KLineMin1Min5Service();
            //_serviceContainer.Add(kLineMin1Min5.ServiceName, kLineMin1Min5);

            //var participation = new ParticipationService();
            //_serviceContainer.Add(participation.ServiceName, participation);

            //var stockBonus = new StockBonusService();
            //_serviceContainer.Add(stockBonus.ServiceName, stockBonus);

            //var stockProfile = new StockProfileService();
            //_serviceContainer.Add(stockProfile.ServiceName, stockProfile);

            //var stockStructure = new StockStructureService();
            //_serviceContainer.Add(stockStructure.ServiceName, stockStructure);
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

        #region IDisposable Members
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
