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
    public class EquRepository : IEquRepository
    {
        public bool Insert(Equ equ)
        {
            //权宜之计，改为参数化方法会报“将截断字符串或二进制数据”异常，故将’替换成"
            if (equ.primeOperating != null)
            {
                equ.primeOperating = equ.primeOperating.Replace('\'', '\"');
            }

            SqlConnection conn = null;
            string sqlInsert = string.Format("Insert Into Equ([secID],[ticker],[exchangeCD],[ListSectorCD],[ListSector],[transCurrCD],[secShortName],[secFullName],[listStatusCD],[listDate],[delistDate],[equTypeCD],[equType],[exCountryCD],[partyID],[totalShares],[nonrestFloatShares],[nonrestfloatA],[officeAddr],[primeOperating]) Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}',{15},{16},{17},'{18}','{19}')",
                equ.secID, equ.ticker, equ.exchangeCD, equ.ListSectorCD, equ.ListSector, equ.transCurrCD, equ.secShortName, equ.secFullName, equ.listStatusCD, equ.listDate, equ.delistDate ?? string.Empty, equ.equTypeCD, equ.equType, equ.exCountryCD, equ.partyID, equ.totalShares, equ.nonrestFloatShares, equ.nonrestfloatA, equ.officeAddr ?? string.Empty, equ.primeOperating ?? string.Empty);

            try
            {
                conn = new SqlConnection(SqlHelper.SqlConStr);
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                cmd.ExecuteNonQuery();
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

        public bool DeleteAllEqus()
        {
            SqlConnection conn = null;
            string sqlDelete = "Delete From Equ";

            try
            {
                conn = new SqlConnection(SqlHelper.SqlConStr);
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlDelete, conn);
                cmd.ExecuteNonQuery();
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

        public List<string> GetAllTickers()
        {
            SqlConnection conn = null;
            string strSelect = "SELECT distinct [ticker] FROM [Equ]";

            try
            {
                conn = new SqlConnection(SqlHelper.SqlConStr);
                conn.Open();

                SqlCommand cmd = new SqlCommand(strSelect, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                List<string> codeList = new List<string>();
                while (reader.Read())
                {
                    codeList.Add(reader["ticker"].ToString().Trim());
                }
                reader.Close();
                return codeList;
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

        public List<Equ> GetAllEqus()
        {
            SqlConnection conn = null;
            string strSelect = "SELECT * FROM [Equ]";

            try
            {
                conn = new SqlConnection(SqlHelper.SqlConStr);
                conn.Open();

                SqlCommand cmd = new SqlCommand(strSelect, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                List<Equ> equList = new List<Equ>();
                while (reader.Read())
                {
                    Equ equ = new Equ { 
                        ID = int.Parse(reader["ID"].ToString()),
                        secID = reader["secID"].ToString().Trim(),
                        ticker = reader["ticker"].ToString().Trim(),
                        exchangeCD = reader["exchangeCD"].ToString().Trim(),
                        ListSectorCD = reader["ListSectorCD"].ToString().Trim(),
                        ListSector = reader["ListSector"].ToString().Trim(),
                        transCurrCD = reader["transCurrCD"].ToString().Trim(),
                        secShortName = reader["secShortName"].ToString().Trim(),
                        secFullName = reader["secFullName"].ToString().Trim(),
                        listStatusCD = reader["listStatusCD"].ToString().Trim(),
                        listDate = reader["listDate"].ToString().Trim(),
                        delistDate = reader["delistDate"].ToString().Trim(),
                        equTypeCD = reader["equTypeCD"].ToString().Trim(),
                        equType = reader["equType"].ToString().Trim(),
                        exCountryCD = reader["exCountryCD"].ToString().Trim(),
                        partyID = reader["partyID"].ToString().Trim(),
                        totalShares = double.Parse(reader["totalShares"].ToString()),
                        nonrestFloatShares = double.Parse(reader["nonrestFloatShares"].ToString()),
                        nonrestfloatA = double.Parse(reader["nonrestfloatA"].ToString()),
                        officeAddr = reader["officeAddr"].ToString().Trim(),
                        primeOperating = reader["primeOperating"].ToString().Trim()
                    };
                    equList.Add(equ);
                }
                reader.Close();
                return equList;
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
