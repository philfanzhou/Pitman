using Ore.Infrastructure.MarketData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;

namespace Pitman.Infrastructure.SqlCe.Repository
{
    public class KLineRepository : SqlCeRepository
    {
        private const string tableName = "KLineTable";
        private const string colAmount = "colAmount";
        private const string colClose = "colClose";
        private const string colHigh = "colHigh";
        private const string colLow = "colLow";
        private const string colOpen = "colOpen";
        private const string colTime = "colTime";
        private const string colVolume = "colVolume";

        public KLineRepository(string fullPath) : base(fullPath) { }

        protected override void OnDbCreating()
        {
            // 初始化出一个新的数据库连接 
            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                // 建立数据库连接 
                conn.Open();

                using (SqlCeCommand cmdSqlCe = conn.CreateCommand())
                {
                    cmdSqlCe.CommandText =
                        string.Format("CREATE TABLE {0}({1} nvarchar(19) PRIMARY KEY, {2} money, {3} money, {4} money, {5} money, {6} money, {7} money)",
                        tableName,
                        colTime,
                        colOpen,
                        colClose,
                        colHigh,
                        colLow,
                        colVolume,
                        colAmount);
                    cmdSqlCe.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public bool Exists(IStockKLine kLine)
        {
            bool bExists = false;
            string sql = 
                string.Format("SELECT * FROM {0} WHERE {1}='{2}'",
                tableName,
                colTime,
                kLine.Time.ToString("yyyy-MM-dd HH:mm:ss"));

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

        public DateTime? GetLastTradeDate()
        {
            DateTime? result = null;
            string sql = string.Format("SELECT MAX([{0}]) FROM {1}", colTime, tableName);            

            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                using (SqlCeCommand sqlCmd = new SqlCeCommand(sql, conn))
                {
                    Object o = sqlCmd.ExecuteScalar();
                    if (o != null && o != DBNull.Value)
                    {
                        result = Convert.ToDateTime(o);
                    }
                }

                conn.Close();
            }

            return result;
        }

        public void AddRange(IEnumerable<IStockKLine> kLines)
        {
            // 初始化出一个新的数据库连接 
            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                // 建立数据库连接 
                conn.Open();

                using (SqlCeCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = 
                        string.Format("INSERT INTO {0}({1}, {2}, {3}, {4}, {5}, {6}, {7}) VALUES (?, ?, ?, ?, ?, ?, ?)",
                        tableName,
                        colTime,
                        colOpen,
                        colClose,
                        colHigh,
                        colLow,
                        colVolume,
                        colAmount);

                    cmd.Parameters.Add(new SqlCeParameter("p1", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter("p2", SqlDbType.Money));
                    cmd.Parameters.Add(new SqlCeParameter("p3", SqlDbType.Money));
                    cmd.Parameters.Add(new SqlCeParameter("p4", SqlDbType.Money));
                    cmd.Parameters.Add(new SqlCeParameter("p5", SqlDbType.Money));
                    cmd.Parameters.Add(new SqlCeParameter("p6", SqlDbType.Money));
                    cmd.Parameters.Add(new SqlCeParameter("p7", SqlDbType.Money));

                    cmd.Parameters["p1"].Size = 19;
                    cmd.Prepare();

                    foreach (var it in kLines)
                    {
                        cmd.Parameters["p1"].Value = it.Time.ToString("yyyy-MM-dd HH:mm:ss");
                        cmd.Parameters["p2"].Value = it.Open;
                        cmd.Parameters["p3"].Value = it.Close;
                        cmd.Parameters["p4"].Value = it.High;
                        cmd.Parameters["p5"].Value = it.Low;
                        cmd.Parameters["p6"].Value = it.Volume;
                        cmd.Parameters["p7"].Value = it.Amount;
                        cmd.ExecuteNonQuery();
                    }
                }

                conn.Close();
            }
        }

        public void AddIfNotExist(IEnumerable<IStockKLine> kLines)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<IStockKLine> kLines)
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
                            string.Format("UPDATE {0} SET {2}=@{2}, {3}=@{3}, {4}=@{4}, {5}=@{5}, {6}=@{6}, {7}=@{7} WHERE {1}=@{1}",
                            tableName,
                            colTime,
                            colOpen,
                            colClose,
                            colHigh,
                            colLow,
                            colVolume,
                            colAmount);

                        foreach (var it in kLines)
                        {
                            cmd.Parameters.Add(new SqlCeParameter(colTime, it.Time.ToString("yyyy-MM-dd HH:mm:ss")));
                            cmd.Parameters.Add(new SqlCeParameter(colOpen, it.Open));
                            cmd.Parameters.Add(new SqlCeParameter(colClose, it.Close));
                            cmd.Parameters.Add(new SqlCeParameter(colHigh, it.High));
                            cmd.Parameters.Add(new SqlCeParameter(colLow, it.Low));
                            cmd.Parameters.Add(new SqlCeParameter(colVolume, it.Volume));
                            cmd.Parameters.Add(new SqlCeParameter(colAmount, it.Amount));

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
                
        public IEnumerable<IStockKLine> GetAll()
        {
            List<StockKLine> result = new List<StockKLine>();
            string sql = string.Format("SELECT * FROM {0}", tableName);

            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                using (SqlCeCommand cmd = new SqlCeCommand(sql, conn))
                {
                    SqlCeDataReader reader = cmd.ExecuteReader();
                   
                    while (reader.Read())
                    {
                        StockKLine dbo = new StockKLine
                        {
                            Amount = double.Parse(reader[colAmount].ToString().Trim()),
                            Close = double.Parse(reader[colClose].ToString().Trim()),
                            High = double.Parse(reader[colHigh].ToString().Trim()),
                            Low = double.Parse(reader[colLow].ToString().Trim()),
                            Open = double.Parse(reader[colOpen].ToString().Trim()),
                            Time = DateTime.Parse(reader[colTime].ToString().Trim()),
                            Volume = double.Parse(reader[colVolume].ToString().Trim())
                        };
                        result.Add(dbo);
                    }

                    reader.Close();                    
                }

                conn.Close();
            }

            return result;
        }

        public IEnumerable<IStockKLine> Get(DateTime startTime, DateTime endTime)
        {
            List<StockKLine> result = new List<StockKLine>();
            string sql = 
                string.Format("SELECT * FROM {0} WHERE {1}>='{2}' AND {1}<='{3}'",
                tableName,
                colTime,
                startTime.ToString("yyyy-MM-dd HH:mm:ss"),
                endTime.ToString("yyyy-MM-dd HH:mm:ss"));

            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                using (SqlCeCommand cmd = new SqlCeCommand(sql, conn))
                {
                    SqlCeDataReader reader = cmd.ExecuteReader();                    
                    while (reader.Read())
                    {
                        StockKLine dbo = new StockKLine
                        {
                            Amount = double.Parse(reader[colAmount].ToString().Trim()),
                            Close = double.Parse(reader[colClose].ToString().Trim()),
                            High = double.Parse(reader[colHigh].ToString().Trim()),
                            Low = double.Parse(reader[colLow].ToString().Trim()),
                            Open = double.Parse(reader[colOpen].ToString().Trim()),
                            Time = DateTime.Parse(reader[colTime].ToString().Trim()),
                            Volume = double.Parse(reader[colVolume].ToString().Trim())
                        };
                        result.Add(dbo);
                    }
                    reader.Close();
                }

                conn.Close();
            }

            return result;
        }
    }
}
