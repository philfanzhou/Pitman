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
    public class StockStructureRepository : SqlCeRepository
    {
        private const string tableName = "StockStructureTable";
        private const string colDateOfChange = "colDateOfChange";
        private const string colDateOfDeclaration = "colDateOfDeclaration";
        private const string colDomesticLegalPersonShares = "colDomesticLegalPersonShares";
        private const string colDomesticSponsorsShares = "colDomesticSponsorsShares";
        private const string colExecutiveShares = "colExecutiveShares";
        private const string colFundsShares = "colFundsShares";
        private const string colGeneralLegalPersonShares = "colGeneralLegalPersonShares";
        private const string colInternalStaffShares = "colInternalStaffShares";
        private const string colPreferredStock = "colPreferredStock";
        private const string colRaiseLegalPersonShares = "colRaiseLegalPersonShares";
        private const string colReason = "colReason";
        private const string colRestrictedSharesA = "colRestrictedSharesA";
        private const string colRestrictedSharesB = "colRestrictedSharesB";
        private const string colSharesA = "colSharesA";
        private const string colSharesB = "colSharesB";
        private const string colSharesH = "colSharesH";
        private const string colStateOwnedLegalPersonShares = "colStateOwnedLegalPersonShares";
        private const string colStateShares = "colStateShares";
        private const string colStrategicInvestorsShares = "colStrategicInvestorsShares";
        private const string colTotalShares = "colTotalShares";
        private const string colTransferredAllottedShares = "colTransferredAllottedShares";

        public StockStructureRepository(string fullPath) : base(fullPath) { }

        protected override void OnDbCreating()
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("CREATE TABLE {0}", tableName);
            sbSql.AppendFormat("({0} nvarchar(19) PRIMARY KEY, ", colDateOfChange);
            sbSql.AppendFormat("{0} nvarchar(19), ", colDateOfDeclaration);
            sbSql.AppendFormat("{0} float, ", colDomesticLegalPersonShares);
            sbSql.AppendFormat("{0} float, ", colDomesticSponsorsShares);
            sbSql.AppendFormat("{0} float, ", colExecutiveShares);
            sbSql.AppendFormat("{0} float, ", colFundsShares);
            sbSql.AppendFormat("{0} float, ", colGeneralLegalPersonShares);
            sbSql.AppendFormat("{0} float, ", colInternalStaffShares);
            sbSql.AppendFormat("{0} float, ", colPreferredStock);
            sbSql.AppendFormat("{0} float, ", colRaiseLegalPersonShares);
            sbSql.AppendFormat("{0} nvarchar(256), ", colReason);
            sbSql.AppendFormat("{0} float, ", colRestrictedSharesA);
            sbSql.AppendFormat("{0} float, ", colRestrictedSharesB);
            sbSql.AppendFormat("{0} float, ", colSharesA);
            sbSql.AppendFormat("{0} float, ", colSharesB);
            sbSql.AppendFormat("{0} float, ", colSharesH);
            sbSql.AppendFormat("{0} float, ", colStateOwnedLegalPersonShares);
            sbSql.AppendFormat("{0} float, ", colStateShares);
            sbSql.AppendFormat("{0} float, ", colStrategicInvestorsShares);
            sbSql.AppendFormat("{0} float, ", colTotalShares);
            sbSql.AppendFormat("{0} float)", colTransferredAllottedShares);

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

        public bool Exists(IStockStructure stockStructure)
        {
            bool bExists = false;
            string sql =
                string.Format("SELECT * FROM {0} WHERE {1}='{2}'",
                tableName,
                colDateOfChange,
                stockStructure.DateOfChange.ToString("yyyy-MM-dd HH:mm:ss"));

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

        public void AddRange(IEnumerable<IStockStructure> stockStructures)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("INSERT INTO {0}", tableName);

            sbSql.AppendFormat("({0}, ", colDateOfChange);
            sbSql.AppendFormat("{0}, ", colDateOfDeclaration);
            sbSql.AppendFormat("{0}, ", colDomesticLegalPersonShares);
            sbSql.AppendFormat("{0}, ", colDomesticSponsorsShares);
            sbSql.AppendFormat("{0}, ", colExecutiveShares);

            sbSql.AppendFormat("{0}, ", colFundsShares);
            sbSql.AppendFormat("{0}, ", colGeneralLegalPersonShares);
            sbSql.AppendFormat("{0}, ", colInternalStaffShares);
            sbSql.AppendFormat("{0}, ", colPreferredStock);
            sbSql.AppendFormat("{0}, ", colRaiseLegalPersonShares);

            sbSql.AppendFormat("{0}, ", colReason);
            sbSql.AppendFormat("{0}, ", colRestrictedSharesA);
            sbSql.AppendFormat("{0}, ", colRestrictedSharesB);
            sbSql.AppendFormat("{0}, ", colSharesA);
            sbSql.AppendFormat("{0}, ", colSharesB);

            sbSql.AppendFormat("{0}, ", colSharesH);
            sbSql.AppendFormat("{0}, ", colStateOwnedLegalPersonShares);
            sbSql.AppendFormat("{0}, ", colStateShares);
            sbSql.AppendFormat("{0}, ", colStrategicInvestorsShares);
            sbSql.AppendFormat("{0}, ", colTotalShares);

            sbSql.AppendFormat("{0}) ", colTransferredAllottedShares);

            sbSql.Append("VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)");

            // 初始化出一个新的数据库连接 
            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                // 建立数据库连接 
                conn.Open();

                using (SqlCeCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sbSql.ToString();

                    cmd.Parameters.Add(new SqlCeParameter("p1", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter("p2", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter("p3", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p4", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p5", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p6", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p7", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p8", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p9", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p10", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p11", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter("p12", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p13", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p14", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p15", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p16", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p17", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p18", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p19", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p20", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p21", SqlDbType.Float));

                    cmd.Parameters["p1"].Size = 19;
                    cmd.Parameters["p2"].Size = 19;
                    cmd.Parameters["p11"].Size = 256;
                    cmd.Prepare();

                    foreach (var it in stockStructures)
                    {
                        cmd.Parameters["p1"].Value = it.DateOfChange.ToString("yyyy-MM-dd HH:mm:ss");
                        cmd.Parameters["p2"].Value = it.DateOfDeclaration.ToString("yyyy-MM-dd HH:mm:ss");
                        cmd.Parameters["p3"].Value = it.DomesticLegalPersonShares;
                        cmd.Parameters["p4"].Value = it.DomesticSponsorsShares;
                        cmd.Parameters["p5"].Value = it.ExecutiveShares;
                        cmd.Parameters["p6"].Value = it.FundsShares;
                        cmd.Parameters["p7"].Value = it.GeneralLegalPersonShares;
                        cmd.Parameters["p8"].Value = it.InternalStaffShares;
                        cmd.Parameters["p9"].Value = it.PreferredStock;
                        cmd.Parameters["p10"].Value = it.RaiseLegalPersonShares;
                        cmd.Parameters["p11"].Value = string.IsNullOrEmpty(it.Reason) ? "" : it.Reason;
                        cmd.Parameters["p12"].Value = it.RestrictedSharesA;
                        cmd.Parameters["p13"].Value = it.RestrictedSharesB;
                        cmd.Parameters["p14"].Value = it.SharesA;
                        cmd.Parameters["p15"].Value = it.SharesB;
                        cmd.Parameters["p16"].Value = it.SharesH;
                        cmd.Parameters["p17"].Value = it.StateOwnedLegalPersonShares;
                        cmd.Parameters["p18"].Value = it.StateShares;
                        cmd.Parameters["p19"].Value = it.StrategicInvestorsShares;
                        cmd.Parameters["p20"].Value = it.TotalShares;
                        cmd.Parameters["p21"].Value = it.TransferredAllottedShares;

                        cmd.ExecuteNonQuery();
                    }
                }

                conn.Close();
            }
        }

        public void UpdateRange(IEnumerable<IStockStructure> stockStructures)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("UPDATE {0} SET ", tableName);

            //sbSql.AppendFormat("{0}=@{0}, ", colDateOfChange);
            sbSql.AppendFormat("{0}=@{0}, ", colDateOfDeclaration);
            sbSql.AppendFormat("{0}=@{0}, ", colDomesticLegalPersonShares);
            sbSql.AppendFormat("{0}=@{0}, ", colDomesticSponsorsShares);
            sbSql.AppendFormat("{0}=@{0}, ", colExecutiveShares);
            sbSql.AppendFormat("{0}=@{0}, ", colFundsShares);
            sbSql.AppendFormat("{0}=@{0}, ", colGeneralLegalPersonShares);
            sbSql.AppendFormat("{0}=@{0}, ", colInternalStaffShares);
            sbSql.AppendFormat("{0}=@{0}, ", colPreferredStock);
            sbSql.AppendFormat("{0}=@{0}, ", colRaiseLegalPersonShares);
            sbSql.AppendFormat("{0}=@{0}, ", colReason);
            sbSql.AppendFormat("{0}=@{0}, ", colRestrictedSharesA);
            sbSql.AppendFormat("{0}=@{0}, ", colRestrictedSharesB);
            sbSql.AppendFormat("{0}=@{0}, ", colSharesA);
            sbSql.AppendFormat("{0}=@{0}, ", colSharesB);
            sbSql.AppendFormat("{0}=@{0}, ", colSharesH);
            sbSql.AppendFormat("{0}=@{0}, ", colStateOwnedLegalPersonShares);
            sbSql.AppendFormat("{0}=@{0}, ", colStateShares);
            sbSql.AppendFormat("{0}=@{0}, ", colStrategicInvestorsShares);
            sbSql.AppendFormat("{0}=@{0}, ", colTotalShares);
            sbSql.AppendFormat("{0}=@{0} ", colTransferredAllottedShares);

            sbSql.AppendFormat("WHERE {0}=@{0}", colDateOfChange);

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

                        foreach (var it in stockStructures)
                        {
                            cmd.Parameters.Add(new SqlCeParameter(colDateOfChange, it.DateOfChange.ToString("yyyy-MM-dd HH:mm:ss")));
                            cmd.Parameters.Add(new SqlCeParameter(colDateOfDeclaration, it.DateOfDeclaration.ToString("yyyy-MM-dd HH:mm:ss")));
                            cmd.Parameters.Add(new SqlCeParameter(colDomesticLegalPersonShares, it.DomesticLegalPersonShares));
                            cmd.Parameters.Add(new SqlCeParameter(colDomesticSponsorsShares, it.DomesticSponsorsShares));
                            cmd.Parameters.Add(new SqlCeParameter(colExecutiveShares, it.ExecutiveShares));
                            cmd.Parameters.Add(new SqlCeParameter(colFundsShares, it.FundsShares));
                            cmd.Parameters.Add(new SqlCeParameter(colGeneralLegalPersonShares, it.GeneralLegalPersonShares));
                            cmd.Parameters.Add(new SqlCeParameter(colInternalStaffShares, it.InternalStaffShares));
                            cmd.Parameters.Add(new SqlCeParameter(colPreferredStock, it.PreferredStock));
                            cmd.Parameters.Add(new SqlCeParameter(colRaiseLegalPersonShares, it.RaiseLegalPersonShares));
                            cmd.Parameters.Add(new SqlCeParameter(colReason, string.IsNullOrEmpty(it.Reason) ? "" : it.Reason));
                            cmd.Parameters.Add(new SqlCeParameter(colRestrictedSharesA, it.RestrictedSharesA));
                            cmd.Parameters.Add(new SqlCeParameter(colRestrictedSharesB, it.RestrictedSharesB));
                            cmd.Parameters.Add(new SqlCeParameter(colSharesA, it.SharesA));
                            cmd.Parameters.Add(new SqlCeParameter(colSharesB, it.SharesB));
                            cmd.Parameters.Add(new SqlCeParameter(colSharesH, it.SharesH));
                            cmd.Parameters.Add(new SqlCeParameter(colStateOwnedLegalPersonShares, it.StateOwnedLegalPersonShares));
                            cmd.Parameters.Add(new SqlCeParameter(colStateShares, it.StateShares));
                            cmd.Parameters.Add(new SqlCeParameter(colStrategicInvestorsShares, it.StrategicInvestorsShares));
                            cmd.Parameters.Add(new SqlCeParameter(colTotalShares, it.TotalShares));
                            cmd.Parameters.Add(new SqlCeParameter(colTransferredAllottedShares, it.TransferredAllottedShares));

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

        public IEnumerable<IStockStructure> GetAll()
        {
            List<StockStructure> result = new List<StockStructure>();
            string sql = string.Format("SELECT * FROM {0}", tableName);

            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                using (SqlCeCommand cmd = new SqlCeCommand(sql, conn))
                {
                    SqlCeDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        StockStructure dbo = new StockStructure
                        {
                            DateOfChange = DateTime.Parse(reader[colDateOfChange].ToString().Trim()),
                            DateOfDeclaration = DateTime.Parse(reader[colDateOfDeclaration].ToString().Trim()),
                            DomesticLegalPersonShares = Double.Parse(reader[colDomesticLegalPersonShares].ToString().Trim()),
                            DomesticSponsorsShares = Double.Parse(reader[colDomesticSponsorsShares].ToString().Trim()),
                            ExecutiveShares = Double.Parse(reader[colExecutiveShares].ToString().Trim()),
                            FundsShares = Double.Parse(reader[colFundsShares].ToString().Trim()),
                            GeneralLegalPersonShares = Double.Parse(reader[colGeneralLegalPersonShares].ToString().Trim()),
                            InternalStaffShares = Double.Parse(reader[colInternalStaffShares].ToString().Trim()),
                            PreferredStock = Double.Parse(reader[colPreferredStock].ToString().Trim()),
                            RaiseLegalPersonShares = Double.Parse(reader[colRaiseLegalPersonShares].ToString().Trim()),
                            Reason = reader[colReason].ToString().Trim(),
                            RestrictedSharesA = Double.Parse(reader[colRestrictedSharesA].ToString().Trim()),
                            RestrictedSharesB = Double.Parse(reader[colRestrictedSharesB].ToString().Trim()),
                            SharesA = Double.Parse(reader[colSharesA].ToString().Trim()),
                            SharesB = Double.Parse(reader[colSharesB].ToString().Trim()),
                            SharesH = Double.Parse(reader[colSharesH].ToString().Trim()),
                            StateOwnedLegalPersonShares = Double.Parse(reader[colStateOwnedLegalPersonShares].ToString().Trim()),
                            StateShares = Double.Parse(reader[colStateShares].ToString().Trim()),
                            StrategicInvestorsShares = Double.Parse(reader[colStrategicInvestorsShares].ToString().Trim()),
                            TotalShares = Double.Parse(reader[colTotalShares].ToString().Trim()),
                            TransferredAllottedShares = Double.Parse(reader[colTransferredAllottedShares].ToString().Trim()),
                        };
                        result.Add(dbo);
                    }
                    reader.Close();
                }

                conn.Close();
            }
            return result;
        }

        public IStockStructure Get(string keyCode)
        {
            StockStructure result = null;
            string sql = string.Format("SELECT * FROM {0} WHERE {1}='{2}'", tableName, colDateOfChange, keyCode);

            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                using (SqlCeCommand cmd = new SqlCeCommand(sql, conn))
                {
                    SqlCeDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        StockStructure dbo = new StockStructure
                        {
                            DateOfChange = DateTime.Parse(reader[colDateOfChange].ToString().Trim()),
                            DateOfDeclaration = DateTime.Parse(reader[colDateOfDeclaration].ToString().Trim()),
                            DomesticLegalPersonShares = Double.Parse(reader[colDomesticLegalPersonShares].ToString().Trim()),
                            DomesticSponsorsShares = Double.Parse(reader[colDomesticSponsorsShares].ToString().Trim()),
                            ExecutiveShares = Double.Parse(reader[colExecutiveShares].ToString().Trim()),
                            FundsShares = Double.Parse(reader[colFundsShares].ToString().Trim()),
                            GeneralLegalPersonShares = Double.Parse(reader[colGeneralLegalPersonShares].ToString().Trim()),
                            InternalStaffShares = Double.Parse(reader[colInternalStaffShares].ToString().Trim()),
                            PreferredStock = Double.Parse(reader[colPreferredStock].ToString().Trim()),
                            RaiseLegalPersonShares = Double.Parse(reader[colRaiseLegalPersonShares].ToString().Trim()),
                            Reason = reader[colReason].ToString().Trim(),
                            RestrictedSharesA = Double.Parse(reader[colRestrictedSharesA].ToString().Trim()),
                            RestrictedSharesB = Double.Parse(reader[colRestrictedSharesB].ToString().Trim()),
                            SharesA = Double.Parse(reader[colSharesA].ToString().Trim()),
                            SharesB = Double.Parse(reader[colSharesB].ToString().Trim()),
                            SharesH = Double.Parse(reader[colSharesH].ToString().Trim()),
                            StateOwnedLegalPersonShares = Double.Parse(reader[colStateOwnedLegalPersonShares].ToString().Trim()),
                            StateShares = Double.Parse(reader[colStateShares].ToString().Trim()),
                            StrategicInvestorsShares = Double.Parse(reader[colStrategicInvestorsShares].ToString().Trim()),
                            TotalShares = Double.Parse(reader[colTotalShares].ToString().Trim()),
                            TransferredAllottedShares = Double.Parse(reader[colTransferredAllottedShares].ToString().Trim()),
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
