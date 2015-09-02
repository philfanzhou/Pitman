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
    public class OrgPercentRepository : IOrgPercentRepository
    {
        public List<OrgPercent> GetOrgPercentByWhere(string sqlWhere)
        {
            SqlConnection conn = null;
            string strPercent = "SELECT * FROM [OrgPercent] WHERE 1=1";
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                strPercent += " AND " + sqlWhere;
            }

            try
            {
                conn = new SqlConnection(SqlHelper.SqlConStr);
                conn.Open();

                SqlCommand sqlPercent = new SqlCommand(strPercent, conn);
                SqlDataReader readerPercent = sqlPercent.ExecuteReader();
                List<OrgPercent> orgPercentList = new List<OrgPercent>();
                while (readerPercent.Read())
                {
                    OrgPercent orgPercent = new OrgPercent();
                    orgPercent.ID = int.Parse(readerPercent["ID"].ToString());
                    orgPercent.Code = readerPercent["Code"].ToString().Trim();
                    orgPercent.Day = readerPercent["Day"].ToString().Trim();
                    orgPercent.Value = Convert.ToSingle(readerPercent["Value"].ToString().Trim());
                    orgPercent.Zhuli = Convert.ToSingle(readerPercent["Zhuli"].ToString().Trim());
                    orgPercent.Chaoda = Convert.ToSingle(readerPercent["Chaoda"].ToString().Trim());
                    orgPercentList.Add(orgPercent);
                }
                readerPercent.Close();
                return orgPercentList;
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

        public bool Insert(OrgPercent orgPercent)
        {
            SqlConnection conn = null;
            string sqlInsert = string.Format("Insert Into OrgPercent Values('{0}','{1}','{2}','{3}','{4}')", orgPercent.Code, orgPercent.Day, orgPercent.Value, orgPercent.Zhuli, orgPercent.Chaoda);

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
    }
}
