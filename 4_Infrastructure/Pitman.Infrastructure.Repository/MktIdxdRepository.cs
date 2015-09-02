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
    public class MktIdxdRepository : IMktIdxdRepository
    {
        public string GetLastTradeDateByCode(string code)
        {
            SqlConnection conn = null;
            string strSelectMaxTradeDate = "SELECT Max([tradeDate]) FROM [dbo].[MktIdxd] WHERE ticker='" + code + "'";

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

        public string GetLastTradeDateByTime(string dateTime)
        {
            SqlConnection conn = null;
            string strSelectMaxTradeDate = "SELECT Max([tradeDate]) FROM [dbo].[MktIdxd] WHERE ticker='000001' AND tradeDate <= '" + dateTime + "'";

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

        public string GetNextTradeDateByTime(string dateTime)
        {
            SqlConnection conn = null;
            string strSelectMaxTradeDate = "SELECT Min([tradeDate]) FROM [dbo].[MktIdxd] WHERE ticker='000001' AND tradeDate > '" + dateTime + "'";

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

        public bool Insert(MktIdxd mktIdxd)
        {
            SqlConnection conn = null;
            string sqlInsert = string.Format("INSERT INTO [dbo].[MktIdxd]([indexID],[tradeDate],[ticker],[porgFullName],[secShortName],[exchangeCD] ,[preCloseIndex],[openIndex],[lowestIndex],[highestIndex],[closeIndex],[turnoverVol],[turnoverValue],[CHG],[CHGPct]) VALUES('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7},{8},{9},{10},{11},{12},{13},{14})",
                    mktIdxd.indexID, mktIdxd.tradeDate, mktIdxd.ticker, mktIdxd.porgFullName, mktIdxd.secShortName, mktIdxd.exchangeCD, mktIdxd.preCloseIndex, mktIdxd.openIndex, mktIdxd.lowestIndex, mktIdxd.highestIndex, mktIdxd.closeIndex, mktIdxd.turnoverVol, mktIdxd.turnoverValue, mktIdxd.CHG, mktIdxd.CHGPct);

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

        public bool Insert(List<MktIdxd> mktIdxdList)
        {
            SqlConnection conn = null;
            StringBuilder sb = new StringBuilder();
            foreach (MktIdxd mktIdxd in mktIdxdList)
            {
                string sqlInsert = string.Format("INSERT INTO [dbo].[MktIdxd]([indexID],[tradeDate],[ticker],[porgFullName],[secShortName],[exchangeCD] ,[preCloseIndex],[openIndex],[lowestIndex],[highestIndex],[closeIndex],[turnoverVol],[turnoverValue],[CHG],[CHGPct]) VALUES('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7},{8},{9},{10},{11},{12},{13},{14})",
                mktIdxd.indexID, mktIdxd.tradeDate, mktIdxd.ticker, mktIdxd.porgFullName, mktIdxd.secShortName, mktIdxd.exchangeCD, mktIdxd.preCloseIndex, mktIdxd.openIndex, mktIdxd.lowestIndex, mktIdxd.highestIndex, mktIdxd.closeIndex, mktIdxd.turnoverVol, mktIdxd.turnoverValue, mktIdxd.CHG, mktIdxd.CHGPct);
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
    }
}
