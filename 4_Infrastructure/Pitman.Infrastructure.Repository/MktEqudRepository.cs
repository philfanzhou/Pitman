using Pitman.Infrastructure.IRepository;
using Pitman.Metadata;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Infrastructure.Repository
{
    public class MktEqudRepository : IMktEqudRepository
    {
        public string GetLastTradeDate(string code)
        {
            SqlConnection conn = null;
            string strSelectMaxTradeDate = "SELECT Max([tradeDate]) FROM [dbo].[MktEqud] WHERE ticker='" + code + "'";

            try
            {                
                conn = new SqlConnection(SqlHelper.SqlConStr);
                conn.Open();

                SqlCommand cmd = new SqlCommand(strSelectMaxTradeDate, conn);
                object objMaxTradeDate = cmd.ExecuteScalar();
                return objMaxTradeDate == null ? string.Empty : objMaxTradeDate.ToString().Trim();
            }
            catch
            {
                return null;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        public bool Insert(MktEqud mktEqud)
        {
            SqlConnection conn = null;
            string sqlInsert = string.Format("INSERT INTO [dbo].[MktEqud]([secID],[tradeDate],[ticker],[secShortName],[exchangeCD],[preClosePrice],[actPreClosePrice],[openPrice],[highestPrice],[lowestPrice],[closePrice],[turnoverVol],[turnoverValue],[dealAmount],[turnoverRate],[accumAdjFactor],[negMarketValue],[marketValue],[PE],[PE1],[PB]) VALUES('{0}','{1}','{2}','{3}','{4}',{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20})",
                    mktEqud.secID, mktEqud.tradeDate, mktEqud.ticker, mktEqud.secShortName, mktEqud.exchangeCD, mktEqud.preClosePrice, mktEqud.actPreClosePrice, mktEqud.openPrice, mktEqud.highestPrice, mktEqud.lowestPrice, mktEqud.closePrice, mktEqud.turnoverVol, mktEqud.turnoverValue, mktEqud.dealAmount, mktEqud.turnoverRate, mktEqud.accumAdjFactor, mktEqud.negMarketValue, mktEqud.marketValue, mktEqud.PE, mktEqud.PE1, mktEqud.PB);

            try
            {
                conn = new SqlConnection(SqlHelper.SqlConStr);
                conn.Open();

                SqlCommand sqlCmd = new SqlCommand(sqlInsert, conn);
                sqlCmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        public bool Insert(List<MktEqud> mktEqudList)
        {
            SqlConnection conn = null;
            StringBuilder sb = new StringBuilder();
            foreach (MktEqud mktEqud in mktEqudList)
            {
                string sqlInsert = string.Format("INSERT INTO [dbo].[MktEqud]([secID],[tradeDate],[ticker],[secShortName],[exchangeCD],[preClosePrice],[actPreClosePrice],[openPrice],[highestPrice],[lowestPrice],[closePrice],[turnoverVol],[turnoverValue],[dealAmount],[turnoverRate],[accumAdjFactor],[negMarketValue],[marketValue],[PE],[PE1],[PB]) VALUES('{0}','{1}','{2}','{3}','{4}',{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20})",
                    mktEqud.secID, mktEqud.tradeDate, mktEqud.ticker, mktEqud.secShortName, mktEqud.exchangeCD, mktEqud.preClosePrice, mktEqud.actPreClosePrice, mktEqud.openPrice, mktEqud.highestPrice, mktEqud.lowestPrice, mktEqud.closePrice, mktEqud.turnoverVol, mktEqud.turnoverValue, mktEqud.dealAmount, mktEqud.turnoverRate, mktEqud.accumAdjFactor, mktEqud.negMarketValue, mktEqud.marketValue, mktEqud.PE, mktEqud.PE1, mktEqud.PB);
                sb.Append(sqlInsert);
                sb.Append(" \r\n");
            }

            try
            {
                if (sb.ToString() != string.Empty)
                {
                    conn = new SqlConnection(SqlHelper.SqlConStr);
                    conn.Open();

                    SqlCommand sqlInsert = new SqlCommand(sb.ToString(), conn);
                    sqlInsert.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        public List<MktEqud> GetAllMktEquds(string sqlWhere)
        {
            SqlConnection conn = null;
            StringBuilder strSelect = new StringBuilder("SELECT * FROM [MktEqud] WHERE 1=1");
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                strSelect.Append(" AND ");
                strSelect.Append(sqlWhere);
            }

            try
            {
                conn = new SqlConnection(SqlHelper.SqlConStr);
                conn.Open();

                SqlCommand cmd = new SqlCommand(strSelect.ToString(), conn);
                SqlDataReader reader = cmd.ExecuteReader();
                List<MktEqud> equdList = new List<MktEqud>();
                while (reader.Read())
                {
                    MktEqud equd = new MktEqud
                    {
                        ID = int.Parse(reader["ID"].ToString()),
                        secID = reader["secID"].ToString().Trim(),
                        tradeDate = reader["tradeDate"].ToString().Trim(),
                        ticker = reader["ticker"].ToString().Trim(),
                        secShortName = reader["secShortName"].ToString().Trim(),
                        exchangeCD = reader["exchangeCD"].ToString().Trim(),
                        preClosePrice = float.Parse(reader["preClosePrice"].ToString().Trim()),
                        actPreClosePrice = float.Parse(reader["actPreClosePrice"].ToString().Trim()),
                        openPrice = float.Parse(reader["openPrice"].ToString().Trim()),
                        highestPrice = float.Parse(reader["highestPrice"].ToString().Trim()),
                        lowestPrice = float.Parse(reader["lowestPrice"].ToString().Trim()),
                        closePrice = float.Parse(reader["closePrice"].ToString().Trim()),
                        turnoverVol = double.Parse(reader["turnoverVol"].ToString().Trim()),
                        turnoverValue = double.Parse(reader["turnoverValue"].ToString().Trim()),
                        dealAmount = double.Parse(reader["dealAmount"].ToString().Trim()),
                        turnoverRate = float.Parse(reader["turnoverRate"].ToString().Trim()),
                        accumAdjFactor = float.Parse(reader["accumAdjFactor"].ToString().Trim()),
                        negMarketValue = double.Parse(reader["negMarketValue"].ToString().Trim()),
                        marketValue = double.Parse(reader["marketValue"].ToString().Trim()),
                        PE = float.Parse(reader["PE"].ToString().Trim()),
                        PE1 = float.Parse(reader["PE1"].ToString().Trim()),
                        PB = float.Parse(reader["PB"].ToString().Trim())
                    };
                    equdList.Add(equd);
                }
                reader.Close();
                return equdList;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }
    }
}
