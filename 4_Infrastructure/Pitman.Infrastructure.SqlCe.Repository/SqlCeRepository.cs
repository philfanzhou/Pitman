using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Infrastructure.SqlCe.Repository
{
    public abstract class SqlCeRepository
    {
        private readonly string _filePath;
        private readonly string _connectionString;

        protected SqlCeRepository(string fullPath)
        {
            _filePath = fullPath;
            _connectionString = "Data Source=" + _filePath;

            CreateDbIfNotExist();
        }

        protected string ConnectionString { get { return _connectionString; } }

        /// <summary>
        /// 子类实现Db创建的时候应该完成的工作，例如表建立
        /// </summary>
        protected abstract void OnDbCreating();

        private void CreateDbIfNotExist()
        {
            if (System.IO.File.Exists(_filePath) == false)
            {
                // 建立数据库文件
                using (SqlCeEngine SQLCEEngine = new SqlCeEngine(_connectionString))
                {
                    SQLCEEngine.CreateDatabase();
                }

                // 新建数据库之后建立数据库表
                OnDbCreating();
            }
        }
    }
}
