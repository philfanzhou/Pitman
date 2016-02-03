using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ore.Infrastructure.MarketData;

namespace Pitman.Infrastructure.SqlCe.Repository
{
    public class SecurityRepository : SqlCeRepository
    {
        private const string tableName = "SecurityTable";
        private const string colCode = "colCode";
        private const string colMarket = "colMarket";
        private const string colShortName = "colShortName";
        private const string colType = "colType";

        public SecurityRepository(string fullPath) : base(fullPath) { }

        protected override void OnDbCreating()
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("CREATE TABLE {0}", tableName);
            sbSql.AppendFormat("({0} nvarchar(16) PRIMARY KEY, ", colCode);
            sbSql.AppendFormat("{0} int, ", colMarket);
            sbSql.AppendFormat("{0} nvarchar(64), ", colShortName);
            sbSql.AppendFormat("{0} int)", colType);

            // 初始化出一个新的数据库连接 
            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                // 建立数据库连接 
                conn.Open();

                using (SqlCeCommand cmdSqlCe = conn.CreateCommand())
                {
                    cmdSqlCe.CommandText = sbSql.ToString();
                    cmdSqlCe.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public bool Exists(ISecurity security)
        {
            bool bExists = false;
            string sql =
                string.Format("SELECT * FROM {0} WHERE {1}='{2}'",
                tableName,
                colCode,
                security.Code);

            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                using (SqlCeCommand sqlCmd = new SqlCeCommand(sql, conn))
                {
                    Object o = sqlCmd.ExecuteScalar();
                    bExists = (o != null);
                }

                conn.Close();
            }

            return bExists;
        }

        public void AddRange(IEnumerable<ISecurity> securities)
        {
            // 初始化出一个新的数据库连接 
            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                // 建立数据库连接 
                conn.Open();

                using (SqlCeCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText =
                        string.Format("INSERT INTO {0}({1}, {2}, {3}, {4}) VALUES (?, ?, ?, ?)",
                        tableName,
                        colCode,
                        colMarket,
                        colShortName,
                        colType);

                    cmd.Parameters.Add(new SqlCeParameter("p1", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter("p2", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlCeParameter("p3", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter("p4", SqlDbType.Int));

                    cmd.Parameters["p1"].Size = 16;
                    cmd.Parameters["p3"].Size = 64;
                    cmd.Prepare();

                    foreach (var it in securities)
                    {
                        cmd.Parameters["p1"].Value = it.Code;
                        cmd.Parameters["p2"].Value = it.Market;
                        cmd.Parameters["p3"].Value = it.ShortName;
                        cmd.Parameters["p4"].Value = it.Type;
                        cmd.ExecuteNonQuery();
                    }
                }

                conn.Close();
            }
        }

        public void UpdateRange(IEnumerable<ISecurity> securities)
        {
            // 初始化出一个新的数据库连接 
            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                // 建立数据库连接 
                conn.Open();

                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                using (SqlCeCommand cmd = conn.CreateCommand())
                {
                    sw.Start();

                    SqlCeTransaction transaction = conn.BeginTransaction(IsolationLevel.Serializable);
                    cmd.Transaction = transaction;
                    try
                    {
                        cmd.CommandText =
                            string.Format("UPDATE {0} SET {2}=@{2}, {3}=@{3}, {4}=@{4} WHERE {1}=@{1}",
                            tableName,
                            colCode,
                            colMarket,
                            colShortName,
                            colType);

                        foreach (var it in securities)
                        {
                            cmd.Parameters.Add(new SqlCeParameter(colCode, it.Code));
                            cmd.Parameters.Add(new SqlCeParameter(colMarket, it.Market));
                            cmd.Parameters.Add(new SqlCeParameter(colShortName, it.ShortName));
                            cmd.Parameters.Add(new SqlCeParameter(colType, it.Type));

                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }

                    sw.Stop();
                    System.Diagnostics.Debug.Print(string.Format("Update time is {0} ms", sw.ElapsedMilliseconds));
                }

                conn.Close();
            }
        }

        public IEnumerable<ISecurity> GetAll()
        {
            List<Security> result = new List<Security>();
            string sql = string.Format("SELECT * FROM {0}", tableName);

            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                using (SqlCeCommand cmd = new SqlCeCommand(sql, conn))
                {
                    SqlCeDataReader reader = cmd.ExecuteReader();                    
                    while (reader.Read())
                    {
                        Security dbo = new Security
                        {
                            Code = reader[colCode].ToString().Trim(),
                            Market = (Market)Int32.Parse(reader[colMarket].ToString().Trim()),
                            ShortName = reader[colShortName].ToString().Trim(),
                            Type = (Ore.Infrastructure.MarketData.SecurityType)Int32.Parse(reader[colType].ToString().Trim())
                        };
                        result.Add(dbo);
                    }
                    reader.Close();
                }

                conn.Close();
            }
            return result;
        }

        public ISecurity Get(string keyCode)
        {
            Security result = null;
            string sql = string.Format("SELECT * FROM {0} WHERE {1}='{2}'", tableName, colCode, keyCode);

            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                using (SqlCeCommand cmd = new SqlCeCommand(sql, conn))
                {
                    SqlCeDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Security dbo = new Security
                        {
                            Code = reader[colCode].ToString().Trim(),
                            Market = (Market)Int32.Parse(reader[colMarket].ToString().Trim()),
                            ShortName = reader[colShortName].ToString().Trim(),
                            Type = (Ore.Infrastructure.MarketData.SecurityType)Int32.Parse(reader[colType].ToString().Trim())
                        };
                        result = dbo;
                    }
                    reader.Close();
                }

                conn.Close();
            }
            return result;
        }
    }
}
