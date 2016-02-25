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
                    SqlCeTransaction transaction = conn.BeginTransaction(IsolationLevel.Serializable);
                    cmd.Transaction = transaction;
                    try
                    {
                        cmd.CommandText =
                                        string.Format("INSERT INTO {0}({1}, {2}, {3}, {4}, {5}, {6}, {7}) VALUES (@{1}, @{2}, @{3}, @{4}, @{5}, @{6}, @{7})",
                                        tableName,
                                        colTime,
                                        colOpen,
                                        colClose,
                                        colHigh,
                                        colLow,
                                        colVolume,
                                        colAmount);

                        cmd.Parameters.Add(new SqlCeParameter(colTime, SqlDbType.NVarChar));
                        cmd.Parameters.Add(new SqlCeParameter(colOpen, SqlDbType.Money));
                        cmd.Parameters.Add(new SqlCeParameter(colClose, SqlDbType.Money));
                        cmd.Parameters.Add(new SqlCeParameter(colHigh, SqlDbType.Money));
                        cmd.Parameters.Add(new SqlCeParameter(colLow, SqlDbType.Money));
                        cmd.Parameters.Add(new SqlCeParameter(colVolume, SqlDbType.Money));
                        cmd.Parameters.Add(new SqlCeParameter(colAmount, SqlDbType.Money));

                        cmd.Parameters[colTime].Size = 19;
                        cmd.Prepare();

                        foreach (var it in kLines)
                        {
                            cmd.Parameters[colTime].Value = it.Time.ToString("yyyy-MM-dd HH:mm:ss");
                            cmd.Parameters[colOpen].Value = it.Open;
                            cmd.Parameters[colClose].Value = it.Close;
                            cmd.Parameters[colHigh].Value = it.High;
                            cmd.Parameters[colLow].Value = it.Low;
                            cmd.Parameters[colVolume].Value = it.Volume;
                            cmd.Parameters[colAmount].Value = it.Amount;
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                    finally
                    {
                        transaction.Dispose();
                    }
                }

                conn.Close();
            }
        }

        public void UpdateRange(IEnumerable<IStockKLine> kLines)
        {
            // 初始化出一个新的数据库连接 
            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                // 建立数据库连接 
                conn.Open();
                
                using (SqlCeCommand cmd = conn.CreateCommand())
                {
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
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                    finally
                    {
                        transaction.Dispose();
                    }
                }

                conn.Close();
            }
        }

        public void DeleteRange(IEnumerable<IStockKLine> kLines)
        {
            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                using (SqlCeCommand cmd = conn.CreateCommand())
                {
                    SqlCeTransaction transaction = conn.BeginTransaction(IsolationLevel.Serializable);
                    cmd.Transaction = transaction;

                    try
                    {
                        cmd.CommandText = string.Format("Delete from {0} where {1}=@{1}",
                            tableName,
                            colTime);

                        cmd.Parameters.Add(new SqlCeParameter(colTime, SqlDbType.NVarChar));
                        cmd.Parameters[colTime].Size = 19;
                        cmd.Prepare();

                        foreach (var item in kLines)
                        {
                            cmd.Parameters[colTime].Value = item.Time.ToString("yyyy-MM-dd HH:mm:ss");
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch(Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                    finally
                    {
                        transaction.Dispose();
                    }
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
