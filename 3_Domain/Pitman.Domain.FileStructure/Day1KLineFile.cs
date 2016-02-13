using System.IO;

namespace Pitman.Domain.FileStructure
{
    /// <summary>
    /// 日K线采用：每票一个文件的方式存储
    /// </summary>
    public class Day1KLineFile
    {
        private readonly string _stockCode;
        private const string _strType = "Day1";

        public Day1KLineFile(string stockCode)
        {
            _stockCode = stockCode;
        }

        public string GetFilePath()
        {
            string folder = Path.Combine(DataFiles.GetKLineFolder(_stockCode), _strType);
            DataFiles.CreateFolderIsNotExist(folder);

            string fileName = string.Format("{0}_{1}{2}", _stockCode, _strType, DataFiles._fileExtName);
            return Path.Combine(folder, fileName);
        }
    }
}
