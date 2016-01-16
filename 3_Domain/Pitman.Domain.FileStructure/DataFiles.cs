using System;
using System.IO;

namespace Pitman.Domain.FileStructure
{
    public static class DataFiles
    {
        private static readonly string DataFolder = Environment.CurrentDirectory + @"\Data";


        /*需要将FileDatabase.PathHelper中的逻辑移动到此工程来。
        因为Path的逻辑相对固定，属于Pitman的具体业务，和底层的具体实现无太大关系，所以移动到Domain里面来
        */

        public static string GetSecuritiesFile()
        {
            string folder = Path.Combine(DataFolder, "SecurityData");
            CreateFolderIsNotExist(folder);
            return Path.Combine(folder, "Securities.sdf");// 注意文件后缀名必须是sdf
        }

        private static void CreateFolderIsNotExist(string folder)
        {
            if(!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }

    }
}
