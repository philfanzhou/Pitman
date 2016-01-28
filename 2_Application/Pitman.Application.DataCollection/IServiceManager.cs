using System.Collections.Generic;

namespace Pitman.Application.DataCollection
{
    /// <summary>
    /// 数据获取服务管理器的接口定义
    /// </summary>
    public interface IServiceManager
    {
        /// <summary>
        /// 获取所有现在正在运行或等待的数据获取服务名称
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetAllServiceName();

        /// <summary>
        /// 根据数据获取服务名称查询服务状态
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        string GetServiceStatus(string serviceName);
    }
}
