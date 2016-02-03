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
    public class StockBonusRepository : SqlCeRepository
    {
        private const string tableName = "StockBonusTable";
        private const string colActualDispatchRate = "colActualDispatchRate";
        private const string colBAndHDividendAfterTax = "colBAndHDividendAfterTax";
        private const string colBAndHPreTaxDividend = "colBAndHPreTaxDividend";
        private const string colBonusRate = "colBonusRate";
        private const string colCapitalStockBaseDate = "colCapitalStockBaseDate";
        private const string colCapitalStockBeforeDispatch = "colCapitalStockBeforeDispatch";
        private const string colCapitalSurplusIncreaseRate = "colCapitalSurplusIncreaseRate";
        private const string colConvertibleBondDate = "colConvertibleBondDate";
        private const string colDateOfDeclaration = "colDateOfDeclaration";
        private const string colDescription = "colDescription";
        private const string colDispatchExpiryDate = "colDispatchExpiryDate";
        private const string colDispatchListingDate = "colDispatchListingDate";
        private const string colDispatchPrice = "colDispatchPrice";
        private const string colDispatchRate = "colDispatchRate";
        private const string colDividendAfterTax = "colDividendAfterTax";
        private const string colExchangeRate = "colExchangeRate";
        private const string colExdividendDate = "colExdividendDate";
        private const string colExpirationDate = "colExpirationDate";
        private const string colIncreaseRate = "colIncreaseRate";
        private const string colIssuingObject = "colIssuingObject";
        private const string colLastTradingDay = "colLastTradingDay";
        private const string colPreTaxDividend = "colPreTaxDividend";
        private const string colRegisterDate = "colRegisterDate";
        private const string colReserveSurplusIncreaseRate = "colReserveSurplusIncreaseRate";
        private const string colResolutionOfShareholdersMeetingDate = "colResolutionOfShareholdersMeetingDate";
        private const string colShareSplitCount = "colShareSplitCount";
        private const string colStartOrArriveDate = "colStartOrArriveDate";
        private const string colTotalDispatch = "colTotalDispatch";
        private const string colTransferredAllottedPrice = "colTransferredAllottedPrice";
        private const string colTransferredAllottedRate = "colTransferredAllottedRate";
        private const string colType = "colType";

        public StockBonusRepository(string fullPath) : base(fullPath) { }

        protected override void OnDbCreating()
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("CREATE TABLE {0}", tableName);

            sbSql.AppendFormat("({0} float, ", colActualDispatchRate);
            sbSql.AppendFormat("{0} float, ", colBAndHDividendAfterTax);
            sbSql.AppendFormat("{0} float, ", colBAndHPreTaxDividend);
            sbSql.AppendFormat("{0} float, ", colBonusRate);
            sbSql.AppendFormat("{0} nvarchar(19), ", colCapitalStockBaseDate);

            sbSql.AppendFormat("{0} float, ", colCapitalStockBeforeDispatch);
            sbSql.AppendFormat("{0} float, ", colCapitalSurplusIncreaseRate);
            sbSql.AppendFormat("{0} nvarchar(19), ", colConvertibleBondDate);
            sbSql.AppendFormat("{0} nvarchar(19)  PRIMARY KEY, ", colDateOfDeclaration);
            sbSql.AppendFormat("{0} nvarchar(256), ", colDescription);

            sbSql.AppendFormat("{0} nvarchar(19), ", colDispatchExpiryDate);
            sbSql.AppendFormat("{0} nvarchar(19), ", colDispatchListingDate);
            sbSql.AppendFormat("{0} float, ", colDispatchPrice);
            sbSql.AppendFormat("{0} float, ", colDispatchRate);
            sbSql.AppendFormat("{0} float, ", colDividendAfterTax);

            sbSql.AppendFormat("{0} float, ", colExchangeRate);
            sbSql.AppendFormat("{0} nvarchar(19), ", colExdividendDate);
            sbSql.AppendFormat("{0} nvarchar(19), ", colExpirationDate);
            sbSql.AppendFormat("{0} float, ", colIncreaseRate);
            sbSql.AppendFormat("{0} nvarchar(256), ", colIssuingObject);

            sbSql.AppendFormat("{0} nvarchar(19), ", colLastTradingDay);
            sbSql.AppendFormat("{0} float, ", colPreTaxDividend);
            sbSql.AppendFormat("{0} nvarchar(19), ", colRegisterDate);
            sbSql.AppendFormat("{0} float, ", colReserveSurplusIncreaseRate);
            sbSql.AppendFormat("{0} nvarchar(19), ", colResolutionOfShareholdersMeetingDate);

            sbSql.AppendFormat("{0} float, ", colShareSplitCount);
            sbSql.AppendFormat("{0} nvarchar(19), ", colStartOrArriveDate);
            sbSql.AppendFormat("{0} float, ", colTotalDispatch);
            sbSql.AppendFormat("{0} float, ", colTransferredAllottedPrice);
            sbSql.AppendFormat("{0} float, ", colTransferredAllottedRate);

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

        public bool Exists(IStockBonus stockBonus)
        {
            bool bExists = false;
            string sql =
                string.Format("SELECT * FROM {0} WHERE {1}='{2}'",
                tableName,
                colDateOfDeclaration,
                stockBonus.DateOfDeclaration.ToString("yyyy-MM-dd HH:mm:ss"));

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

        public void AddRange(IEnumerable<IStockBonus> stockBonuses)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("INSERT INTO {0}", tableName);

            sbSql.AppendFormat("({0}, ", colActualDispatchRate);
            sbSql.AppendFormat("{0}, ", colBAndHDividendAfterTax);
            sbSql.AppendFormat("{0}, ", colBAndHPreTaxDividend);
            sbSql.AppendFormat("{0}, ", colBonusRate);
            sbSql.AppendFormat("{0}, ", colCapitalStockBaseDate);

            sbSql.AppendFormat("{0}, ", colCapitalStockBeforeDispatch);
            sbSql.AppendFormat("{0}, ", colCapitalSurplusIncreaseRate);
            sbSql.AppendFormat("{0}, ", colConvertibleBondDate);
            sbSql.AppendFormat("{0}, ", colDateOfDeclaration);
            sbSql.AppendFormat("{0}, ", colDescription);

            sbSql.AppendFormat("{0}, ", colDispatchExpiryDate);
            sbSql.AppendFormat("{0}, ", colDispatchListingDate);
            sbSql.AppendFormat("{0}, ", colDispatchPrice);
            sbSql.AppendFormat("{0}, ", colDispatchRate);
            sbSql.AppendFormat("{0}, ", colDividendAfterTax);

            sbSql.AppendFormat("{0}, ", colExchangeRate);
            sbSql.AppendFormat("{0}, ", colExdividendDate);
            sbSql.AppendFormat("{0}, ", colExpirationDate);
            sbSql.AppendFormat("{0}, ", colIncreaseRate);
            sbSql.AppendFormat("{0}, ", colIssuingObject);

            sbSql.AppendFormat("{0}, ", colLastTradingDay);
            sbSql.AppendFormat("{0}, ", colPreTaxDividend);
            sbSql.AppendFormat("{0}, ", colRegisterDate);
            sbSql.AppendFormat("{0}, ", colReserveSurplusIncreaseRate);
            sbSql.AppendFormat("{0}, ", colResolutionOfShareholdersMeetingDate);

            sbSql.AppendFormat("{0}, ", colShareSplitCount);
            sbSql.AppendFormat("{0}, ", colStartOrArriveDate);
            sbSql.AppendFormat("{0}, ", colTotalDispatch);
            sbSql.AppendFormat("{0}, ", colTransferredAllottedPrice);
            sbSql.AppendFormat("{0}, ", colTransferredAllottedRate);

            sbSql.AppendFormat("{0}) ", colType);
            sbSql.Append("VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)");

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
                    cmd.Parameters.Add(new SqlCeParameter("p6", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p7", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter("p8", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter("p9", SqlDbType.NVarChar));

                    cmd.Parameters.Add(new SqlCeParameter("p10", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter("p11", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter("p12", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p13", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p14", SqlDbType.Float));

                    cmd.Parameters.Add(new SqlCeParameter("p15", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p16", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter("p17", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter("p18", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p19", SqlDbType.NVarChar));

                    cmd.Parameters.Add(new SqlCeParameter("p20", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter("p21", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p22", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter("p23", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p24", SqlDbType.NVarChar));

                    cmd.Parameters.Add(new SqlCeParameter("p25", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p26", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter("p27", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p28", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlCeParameter("p29", SqlDbType.Float));

                    cmd.Parameters.Add(new SqlCeParameter("p30", SqlDbType.Int));

                    cmd.Parameters["p8"].Size = 19;
                    cmd.Prepare();

                    foreach (var it in stockBonuses)
                    {
                        cmd.Parameters["p0"].Value = it.ActualDispatchRate;
                        cmd.Parameters["p1"].Value = it.BAndHDividendAfterTax;
                        cmd.Parameters["p2"].Value = it.BAndHPreTaxDividend;
                        cmd.Parameters["p3"].Value = it.BonusRate;
                        cmd.Parameters["p4"].Value = it.CapitalStockBaseDate.ToString("yyyy-MM-dd HH:mm:ss");

                        cmd.Parameters["p5"].Value = it.CapitalStockBeforeDispatch;
                        cmd.Parameters["p6"].Value = it.CapitalSurplusIncreaseRate;
                        cmd.Parameters["p7"].Value = it.ConvertibleBondDate.ToString("yyyy-MM-dd HH:mm:ss");
                        cmd.Parameters["p8"].Value = it.DateOfDeclaration.ToString("yyyy-MM-dd HH:mm:ss");
                        cmd.Parameters["p9"].Value = it.Description;

                        cmd.Parameters["p10"].Value = it.DispatchExpiryDate.ToString("yyyy-MM-dd HH:mm:ss");
                        cmd.Parameters["p11"].Value = it.DispatchListingDate.ToString("yyyy-MM-dd HH:mm:ss");
                        cmd.Parameters["p12"].Value = it.DispatchPrice;
                        cmd.Parameters["p13"].Value = it.DispatchRate;
                        cmd.Parameters["p14"].Value = it.DividendAfterTax;

                        cmd.Parameters["p15"].Value = it.ExchangeRate;
                        cmd.Parameters["p16"].Value = it.ExdividendDate.ToString("yyyy-MM-dd HH:mm:ss");
                        cmd.Parameters["p17"].Value = it.ExpirationDate.ToString("yyyy-MM-dd HH:mm:ss");
                        cmd.Parameters["p18"].Value = it.IncreaseRate;
                        cmd.Parameters["p19"].Value = it.IssuingObject;

                        cmd.Parameters["p20"].Value = it.LastTradingDay.ToString("yyyy-MM-dd HH:mm:ss");
                        cmd.Parameters["p21"].Value = it.PreTaxDividend;
                        cmd.Parameters["p22"].Value = it.RegisterDate.ToString("yyyy-MM-dd HH:mm:ss");
                        cmd.Parameters["p23"].Value = it.ReserveSurplusIncreaseRate;
                        cmd.Parameters["p24"].Value = it.ResolutionOfShareholdersMeetingDate.ToString("yyyy-MM-dd HH:mm:ss");

                        cmd.Parameters["p25"].Value = it.ShareSplitCount;
                        cmd.Parameters["p26"].Value = it.StartOrArriveDate.ToString("yyyy-MM-dd HH:mm:ss");
                        cmd.Parameters["p27"].Value = it.TotalDispatch;
                        cmd.Parameters["p28"].Value = it.TransferredAllottedPrice;
                        cmd.Parameters["p29"].Value = it.TransferredAllottedRate;

                        cmd.Parameters["p30"].Value = it.Type;

                        cmd.ExecuteNonQuery();
                    }
                }

                conn.Close();
            }
        }

        public void UpdateRange(IEnumerable<IStockBonus> stockBonuses)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("UPDATE {0} SET ", tableName);
            
            sbSql.AppendFormat("{0}=@{0}, ", colActualDispatchRate);
            sbSql.AppendFormat("{0}=@{0}, ", colBAndHDividendAfterTax);
            sbSql.AppendFormat("{0}=@{0}, ", colBAndHPreTaxDividend);
            sbSql.AppendFormat("{0}=@{0}, ", colBonusRate);
            sbSql.AppendFormat("{0}=@{0}, ", colCapitalStockBaseDate);

            sbSql.AppendFormat("{0}=@{0}, ", colCapitalStockBeforeDispatch);
            sbSql.AppendFormat("{0}=@{0}, ", colCapitalSurplusIncreaseRate);
            sbSql.AppendFormat("{0}=@{0}, ", colConvertibleBondDate);
            
            sbSql.AppendFormat("{0}=@{0}, ", colDescription);

            sbSql.AppendFormat("{0}=@{0}, ", colDispatchExpiryDate);
            sbSql.AppendFormat("{0}=@{0}, ", colDispatchListingDate);
            sbSql.AppendFormat("{0}=@{0}, ", colDispatchPrice);
            sbSql.AppendFormat("{0}=@{0}, ", colDispatchRate);
            sbSql.AppendFormat("{0}=@{0}, ", colDividendAfterTax);

            sbSql.AppendFormat("{0}=@{0}, ", colExchangeRate);
            sbSql.AppendFormat("{0}=@{0}, ", colExdividendDate);
            sbSql.AppendFormat("{0}=@{0}, ", colExpirationDate);
            sbSql.AppendFormat("{0}=@{0}, ", colIncreaseRate);
            sbSql.AppendFormat("{0}=@{0}, ", colIssuingObject);

            sbSql.AppendFormat("{0}=@{0}, ", colLastTradingDay);
            sbSql.AppendFormat("{0}=@{0}, ", colPreTaxDividend);
            sbSql.AppendFormat("{0}=@{0}, ", colRegisterDate);
            sbSql.AppendFormat("{0}=@{0}, ", colReserveSurplusIncreaseRate);
            sbSql.AppendFormat("{0}=@{0}, ", colResolutionOfShareholdersMeetingDate);

            sbSql.AppendFormat("{0}=@{0}, ", colShareSplitCount);
            sbSql.AppendFormat("{0}=@{0}, ", colStartOrArriveDate);
            sbSql.AppendFormat("{0}=@{0}, ", colTotalDispatch);
            sbSql.AppendFormat("{0}=@{0}, ", colTransferredAllottedPrice);
            sbSql.AppendFormat("{0}=@{0}, ", colTransferredAllottedRate);

            sbSql.AppendFormat("{0}=@{0} ", colType);
            sbSql.AppendFormat("WHERE {0}=@{0}", colDateOfDeclaration);

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

                        foreach (var it in stockBonuses)
                        {
                            cmd.Parameters.Add(new SqlCeParameter(colActualDispatchRate, it.ActualDispatchRate));
                            cmd.Parameters.Add(new SqlCeParameter(colBAndHDividendAfterTax, it.BAndHDividendAfterTax));
                            cmd.Parameters.Add(new SqlCeParameter(colBAndHPreTaxDividend, it.BAndHPreTaxDividend));
                            cmd.Parameters.Add(new SqlCeParameter(colBonusRate, it.BonusRate));
                            cmd.Parameters.Add(new SqlCeParameter(colCapitalStockBaseDate, it.CapitalStockBaseDate.ToString("yyyy-MM-dd HH:mm:ss")));

                            cmd.Parameters.Add(new SqlCeParameter(colCapitalStockBeforeDispatch, it.CapitalStockBeforeDispatch));
                            cmd.Parameters.Add(new SqlCeParameter(colCapitalSurplusIncreaseRate, it.CapitalSurplusIncreaseRate));
                            cmd.Parameters.Add(new SqlCeParameter(colConvertibleBondDate, it.ConvertibleBondDate.ToString("yyyy-MM-dd HH:mm:ss")));
                            cmd.Parameters.Add(new SqlCeParameter(colDateOfDeclaration, it.DateOfDeclaration.ToString("yyyy-MM-dd HH:mm:ss")));
                            cmd.Parameters.Add(new SqlCeParameter(colDescription, it.Description));

                            cmd.Parameters.Add(new SqlCeParameter(colDispatchExpiryDate, it.DispatchExpiryDate.ToString("yyyy-MM-dd HH:mm:ss")));
                            cmd.Parameters.Add(new SqlCeParameter(colDispatchListingDate, it.DispatchListingDate.ToString("yyyy-MM-dd HH:mm:ss")));
                            cmd.Parameters.Add(new SqlCeParameter(colDispatchPrice, it.DispatchPrice));
                            cmd.Parameters.Add(new SqlCeParameter(colDispatchRate, it.DispatchRate));
                            cmd.Parameters.Add(new SqlCeParameter(colDividendAfterTax, it.DividendAfterTax));

                            cmd.Parameters.Add(new SqlCeParameter(colExchangeRate, it.ExchangeRate));
                            cmd.Parameters.Add(new SqlCeParameter(colExdividendDate, it.ExdividendDate.ToString("yyyy-MM-dd HH:mm:ss")));
                            cmd.Parameters.Add(new SqlCeParameter(colExpirationDate, it.ExpirationDate.ToString("yyyy-MM-dd HH:mm:ss")));
                            cmd.Parameters.Add(new SqlCeParameter(colIncreaseRate, it.IncreaseRate));
                            cmd.Parameters.Add(new SqlCeParameter(colIssuingObject, it.IssuingObject));

                            cmd.Parameters.Add(new SqlCeParameter(colLastTradingDay, it.LastTradingDay.ToString("yyyy-MM-dd HH:mm:ss")));
                            cmd.Parameters.Add(new SqlCeParameter(colPreTaxDividend, it.PreTaxDividend));
                            cmd.Parameters.Add(new SqlCeParameter(colRegisterDate, it.RegisterDate.ToString("yyyy-MM-dd HH:mm:ss")));
                            cmd.Parameters.Add(new SqlCeParameter(colReserveSurplusIncreaseRate, it.ReserveSurplusIncreaseRate));
                            cmd.Parameters.Add(new SqlCeParameter(colResolutionOfShareholdersMeetingDate, it.ResolutionOfShareholdersMeetingDate.ToString("yyyy-MM-dd HH:mm:ss")));

                            cmd.Parameters.Add(new SqlCeParameter(colShareSplitCount, it.ShareSplitCount));
                            cmd.Parameters.Add(new SqlCeParameter(colStartOrArriveDate, it.StartOrArriveDate.ToString("yyyy-MM-dd HH:mm:ss")));
                            cmd.Parameters.Add(new SqlCeParameter(colTotalDispatch, it.TotalDispatch));
                            cmd.Parameters.Add(new SqlCeParameter(colTransferredAllottedPrice, it.TransferredAllottedPrice));
                            cmd.Parameters.Add(new SqlCeParameter(colTransferredAllottedRate, it.TransferredAllottedRate));

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

        public IEnumerable<IStockBonus> GetAll()
        {
            List<StockBonus> result = new List<StockBonus>();
            string sql = string.Format("SELECT * FROM {0}", tableName);

            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                using (SqlCeCommand cmd = new SqlCeCommand(sql, conn))
                {
                    SqlCeDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        StockBonus dbo = new StockBonus
                        {
                            ActualDispatchRate = Double.Parse(reader[colActualDispatchRate].ToString().Trim()),
                            BAndHDividendAfterTax = Double.Parse(reader[colBAndHDividendAfterTax].ToString().Trim()),
                            BAndHPreTaxDividend = Double.Parse(reader[colBAndHPreTaxDividend].ToString().Trim()),
                            BonusRate = Double.Parse(reader[colBonusRate].ToString().Trim()),
                            CapitalStockBaseDate = DateTime.Parse(reader[colCapitalStockBaseDate].ToString().Trim()),
                            CapitalStockBeforeDispatch = Double.Parse(reader[colCapitalStockBeforeDispatch].ToString().Trim()),
                            CapitalSurplusIncreaseRate = Double.Parse(reader[colCapitalSurplusIncreaseRate].ToString().Trim()),
                            ConvertibleBondDate = DateTime.Parse(reader[colConvertibleBondDate].ToString().Trim()),
                            DateOfDeclaration = DateTime.Parse(reader[colDateOfDeclaration].ToString().Trim()),
                            Description = reader[colDescription].ToString().Trim(),
                            DispatchExpiryDate = DateTime.Parse(reader[colDispatchExpiryDate].ToString().Trim()),
                            DispatchListingDate = DateTime.Parse(reader[colDispatchListingDate].ToString().Trim()),
                            DispatchPrice = Double.Parse(reader[colDispatchPrice].ToString().Trim()),
                            DispatchRate = Double.Parse(reader[colDispatchRate].ToString().Trim()),
                            DividendAfterTax = Double.Parse(reader[colDividendAfterTax].ToString().Trim()),
                            ExchangeRate = Double.Parse(reader[colExchangeRate].ToString().Trim()),
                            ExdividendDate = DateTime.Parse(reader[colExdividendDate].ToString().Trim()),
                            ExpirationDate = DateTime.Parse(reader[colExpirationDate].ToString().Trim()),
                            IncreaseRate = Double.Parse(reader[colIncreaseRate].ToString().Trim()),
                            IssuingObject = reader[colIssuingObject].ToString().Trim(),
                            LastTradingDay = DateTime.Parse(reader[colLastTradingDay].ToString().Trim()),
                            PreTaxDividend = Double.Parse(reader[colPreTaxDividend].ToString().Trim()),
                            RegisterDate = DateTime.Parse(reader[colRegisterDate].ToString().Trim()),
                            ReserveSurplusIncreaseRate = Double.Parse(reader[colReserveSurplusIncreaseRate].ToString().Trim()),
                            ResolutionOfShareholdersMeetingDate = DateTime.Parse(reader[colResolutionOfShareholdersMeetingDate].ToString().Trim()),
                            ShareSplitCount = Double.Parse(reader[colShareSplitCount].ToString().Trim()),
                            StartOrArriveDate = DateTime.Parse(reader[colStartOrArriveDate].ToString().Trim()),
                            TotalDispatch = Double.Parse(reader[colTotalDispatch].ToString().Trim()),
                            TransferredAllottedPrice = Double.Parse(reader[colTransferredAllottedPrice].ToString().Trim()),
                            TransferredAllottedRate = Double.Parse(reader[colTransferredAllottedRate].ToString().Trim()),
                            Type = (BounsType)Int32.Parse(reader[colType].ToString().Trim())
                        };
                        result.Add(dbo);
                    }
                    reader.Close();
                }

                conn.Close();
            }
            return result;
        }

        public IStockBonus Get(string keyCode)
        {
            StockBonus result = null;
            string sql = string.Format("SELECT * FROM {0} WHERE {1}='{2}'", tableName, colDateOfDeclaration, keyCode);

            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                using (SqlCeCommand cmd = new SqlCeCommand(sql, conn))
                {
                    SqlCeDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        StockBonus dbo = new StockBonus
                        {
                            ActualDispatchRate = Double.Parse(reader[colActualDispatchRate].ToString().Trim()),
                            BAndHDividendAfterTax = Double.Parse(reader[colBAndHDividendAfterTax].ToString().Trim()),
                            BAndHPreTaxDividend = Double.Parse(reader[colBAndHPreTaxDividend].ToString().Trim()),
                            BonusRate = Double.Parse(reader[colBonusRate].ToString().Trim()),
                            CapitalStockBaseDate = DateTime.Parse(reader[colCapitalStockBaseDate].ToString().Trim()),
                            CapitalStockBeforeDispatch = Double.Parse(reader[colCapitalStockBeforeDispatch].ToString().Trim()),
                            CapitalSurplusIncreaseRate = Double.Parse(reader[colCapitalSurplusIncreaseRate].ToString().Trim()),
                            ConvertibleBondDate = DateTime.Parse(reader[colConvertibleBondDate].ToString().Trim()),
                            DateOfDeclaration = DateTime.Parse(reader[colDateOfDeclaration].ToString().Trim()),
                            Description = reader[colDescription].ToString().Trim(),
                            DispatchExpiryDate = DateTime.Parse(reader[colDispatchExpiryDate].ToString().Trim()),
                            DispatchListingDate = DateTime.Parse(reader[colDispatchListingDate].ToString().Trim()),
                            DispatchPrice = Double.Parse(reader[colDispatchPrice].ToString().Trim()),
                            DispatchRate = Double.Parse(reader[colDispatchRate].ToString().Trim()),
                            DividendAfterTax = Double.Parse(reader[colDividendAfterTax].ToString().Trim()),
                            ExchangeRate = Double.Parse(reader[colExchangeRate].ToString().Trim()),
                            ExdividendDate = DateTime.Parse(reader[colExdividendDate].ToString().Trim()),
                            ExpirationDate = DateTime.Parse(reader[colExpirationDate].ToString().Trim()),
                            IncreaseRate = Double.Parse(reader[colIncreaseRate].ToString().Trim()),
                            IssuingObject = reader[colIssuingObject].ToString().Trim(),
                            LastTradingDay = DateTime.Parse(reader[colLastTradingDay].ToString().Trim()),
                            PreTaxDividend = Double.Parse(reader[colPreTaxDividend].ToString().Trim()),
                            RegisterDate = DateTime.Parse(reader[colRegisterDate].ToString().Trim()),
                            ReserveSurplusIncreaseRate = Double.Parse(reader[colReserveSurplusIncreaseRate].ToString().Trim()),
                            ResolutionOfShareholdersMeetingDate = DateTime.Parse(reader[colResolutionOfShareholdersMeetingDate].ToString().Trim()),
                            ShareSplitCount = Double.Parse(reader[colShareSplitCount].ToString().Trim()),
                            StartOrArriveDate = DateTime.Parse(reader[colStartOrArriveDate].ToString().Trim()),
                            TotalDispatch = Double.Parse(reader[colTotalDispatch].ToString().Trim()),
                            TransferredAllottedPrice = Double.Parse(reader[colTransferredAllottedPrice].ToString().Trim()),
                            TransferredAllottedRate = Double.Parse(reader[colTransferredAllottedRate].ToString().Trim()),
                            Type = (BounsType)Int32.Parse(reader[colType].ToString().Trim())
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
