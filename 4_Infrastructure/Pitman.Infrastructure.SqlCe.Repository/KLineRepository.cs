using Ore.Infrastructure.MarketData;
using Pitman.Infrastructure.DatabaseObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;

namespace Pitman.Infrastructure.SqlCe.Repository
{
    public class KLineRepository : SqlCeRepository
    {
        private const string Amount = "KLineAmount";
        private const string Close = "KLineClose";
        private const string High = "KLineHigh";
        private const string Low = "KLineLow";
        private const string Open = "KLineOpen";
        private const string Time = "KLineTime";
        private const string Volume = "KLineVolume";

        public KLineRepository(string fullPath) : base(fullPath) { }

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
                        string.Format("INSERT INTO KLineTable({0}, {1}, {2}, {3}, {4}, {5}, {6}) VALUES (?, ?, ?, ?, ?, ?, ?)",
                        Time,
                        Open,
                        Close,
                        High,
                        Low,
                        Volume,
                        Amount);

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

        public IEnumerable<IStockKLine> GetAll()
        {
            string sql = "SELECT * FROM KLineTable";

            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                using (SqlCeCommand cmd = new SqlCeCommand(sql, conn))
                {
                    SqlCeDataReader reader = cmd.ExecuteReader();
                    List<StockKLineDbo> result = new List<StockKLineDbo>();
                    while (reader.Read())
                    {
                        StockKLineDbo dbo = new StockKLineDbo
                        {
                            Amount = double.Parse(reader[Amount].ToString().Trim()),
                            Close = double.Parse(reader[Close].ToString().Trim()),
                            High = double.Parse(reader[High].ToString().Trim()),
                            Low = double.Parse(reader[Low].ToString().Trim()),
                            Open = double.Parse(reader[Open].ToString().Trim()),
                            Time = DateTime.Parse(reader[Time].ToString().Trim()),
                            Volume = double.Parse(reader[Volume].ToString().Trim())
                        };
                        result.Add(dbo);
                    }
                    reader.Close();
                    return result;
                }
            }
        }

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
                        string.Format("CREATE TABLE KLineTable({0} nvarchar(19) PRIMARY KEY, {1} money, {2} money, {3} money, {4} money, {5} money, {6} money)",
                        Time,
                        Open,
                        Close,
                        High,
                        Low,
                        Volume,
                        Amount);
                    cmdSqlCe.ExecuteNonQuery();
                }

                conn.Close();
            }
        }
    }
}
