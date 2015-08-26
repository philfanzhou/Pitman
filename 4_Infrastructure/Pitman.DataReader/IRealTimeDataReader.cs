using Pitman.Metadata;
using System.Collections.Generic;

namespace Pitman.DataReader
{
    /// <summary>
    /// 实时行情数据读取器接口定义
    /// </summary>
    public interface IRealTimeDataReader
    {
        RealTimeData GetData(string code);

        IEnumerable<RealTimeData> GetData(IEnumerable<string> codes);
    }
}
