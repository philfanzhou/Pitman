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
    public class ParticipationRepository : SqlCeRepository
    {
        private const string tableName = "ParticipationTable";
        private const string colCostPrice1Day = "colCostPrice1Day";
        private const string colCostPrice20Day = "colCostPrice20Day";
        private const string colMainForceInflows = "colMainForceInflows";
        private const string colSuperLargeInflows = "colSuperLargeInflows";
        private const string colTime = "colTime";
        private const string colValue = "colValue";

        public ParticipationRepository(string fullPath) : base(fullPath) { }

        protected override void OnDbCreating()
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("CREATE TABLE {0}", tableName);
            sbSql.AppendFormat("({0} float, ", colCostPrice1Day);
            sbSql.AppendFormat("{0} float, ", colCostPrice20Day);
            sbSql.AppendFormat("{0} float, ", colMainForceInflows);
            sbSql.AppendFormat("{0} float, ", colSuperLargeInflows);
            sbSql.AppendFormat("{0} nvarchar(19) PRIMARY KEY, ", colTime);
            sbSql.AppendFormat("{0} float)", colValue);

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

        public bool Exists(IParticipation participation)
        {
            bool bExists = false;
            string sql =
                string.Format("SELECT * FROM {0} WHERE {1}='{2}'",
                tableName,
                colTime,
                participation.Time.ToString("yyyy-MM-dd HH:mm:ss"));

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

        public void AddRange(IEnumerable<IParticipation> participations)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("INSERT INTO {0}", tableName);
            sbSql.AppendFormat("({0}, {1}, {2}, {3}, {4}, {5}) ",
                colCostPrice1Day,
                colCostPrice20Day,
                colMainForceInflows,
                colSuperLargeInflows,
                colTime,
                colValue);
            sbSql.Append("VALUES (?, ?, ?, ?, ?, ?)");

            // 初始化出一个新的数据库连接 
            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                // 建立数据库连接 
                conn.Open();

                using (SqlCeCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sbSql.ToString();

                    cmd.Parameters.Add(new SqlCeParameter("p0", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p1", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p2", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p3", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p4", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter("p5", SqlDbType.Float));

                    cmd.Parameters["p4"].Size = 19;
                    cmd.Prepare();

                    foreach (var it in participations)
                    {
                        cmd.Parameters["p0"].Value = it.CostPrice1Day;
                        cmd.Parameters["p1"].Value = it.CostPrice20Day;
                        cmd.Parameters["p2"].Value = it.MainForceInflows;
                        cmd.Parameters["p3"].Value = it.SuperLargeInflows;
                        cmd.Parameters["p4"].Value = it.Time.ToString("yyyy-MM-dd HH:mm:ss");
                        cmd.Parameters["p5"].Value = it.Value;                
                        cmd.ExecuteNonQuery();
                    }
                }

                conn.Close();
            }
        }

        public void UpdateRange(IEnumerable<IParticipation> participations)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("UPDATE {0} SET ", tableName);
            sbSql.AppendFormat("{0}=@{0}, ", colCostPrice1Day);
            sbSql.AppendFormat("{0}=@{0}, ", colCostPrice20Day);
            sbSql.AppendFormat("{0}=@{0}, ", colMainForceInflows);
            sbSql.AppendFormat("{0}=@{0}, ", colSuperLargeInflows);
            sbSql.AppendFormat("{0}=@{0} ", colValue);
            sbSql.AppendFormat("WHERE {0}=@{0}", colTime);

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
                        cmd.CommandText = sbSql.ToString();

                        foreach (var it in participations)
                        {
                            cmd.Parameters.Add(new SqlCeParameter(colCostPrice1Day, it.CostPrice1Day));
                            cmd.Parameters.Add(new SqlCeParameter(colCostPrice20Day, it.CostPrice20Day));
                            cmd.Parameters.Add(new SqlCeParameter(colMainForceInflows, it.MainForceInflows));
                            cmd.Parameters.Add(new SqlCeParameter(colSuperLargeInflows, it.SuperLargeInflows));
                            cmd.Parameters.Add(new SqlCeParameter(colTime, it.Time.ToString("yyyy-MM-dd HH:mm:ss")));
                            cmd.Parameters.Add(new SqlCeParameter(colValue, it.Value));

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

        public IEnumerable<IParticipation> GetAll()
        {
            List<Participation> result = new List<Participation>();
            string sql = string.Format("SELECT * FROM {0}", tableName);

            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                using (SqlCeCommand cmd = new SqlCeCommand(sql, conn))
                {
                    SqlCeDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Participation dbo = new Participation
                        {
                            CostPrice1Day = Double.Parse(reader[colCostPrice1Day].ToString().Trim()),
                            CostPrice20Day = Double.Parse(reader[colCostPrice20Day].ToString().Trim()),
                            MainForceInflows = Double.Parse(reader[colMainForceInflows].ToString().Trim()),
                            SuperLargeInflows = Double.Parse(reader[colSuperLargeInflows].ToString().Trim()),
                            Time = DateTime.Parse(reader[colTime].ToString().Trim()),
                            Value = Double.Parse(reader[colValue].ToString().Trim())
                        };
                        result.Add(dbo);
                    }
                    reader.Close();
                }

                conn.Close();
            }
            return result;
        }

        public IParticipation Get(string keyCode)
        {
            Participation result = null;
            string sql = string.Format("SELECT * FROM {0} WHERE {1}='{2}'", tableName, colTime, keyCode);

            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                using (SqlCeCommand cmd = new SqlCeCommand(sql, conn))
                {
                    SqlCeDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Participation dbo = new Participation
                        {
                            CostPrice1Day = Double.Parse(reader[colCostPrice1Day].ToString().Trim()),
                            CostPrice20Day = Double.Parse(reader[colCostPrice20Day].ToString().Trim()),
                            MainForceInflows = Double.Parse(reader[colMainForceInflows].ToString().Trim()),
                            SuperLargeInflows = Double.Parse(reader[colSuperLargeInflows].ToString().Trim()),
                            Time = DateTime.Parse(reader[colTime].ToString().Trim()),
                            Value = Double.Parse(reader[colValue].ToString().Trim())
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
