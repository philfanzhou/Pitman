using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.SQLCE
{
    public class SQLCEWrapper
    {
        public string LocalDatabase = Environment.CurrentDirectory + "\\My Documents\\SQLKLineManager.sdf";
        public string ConnectionString = "Data Source=";
        public string LocalConnection = "";

        public SQLCEWrapper()
        {
            LocalConnection = ConnectionString + LocalDatabase;
        }

        //建立数据库 
        public bool CreateDatabase()
        {
            string folder = LocalDatabase.Substring(0, LocalDatabase.LastIndexOf('\\'));
            if (!System.IO.Directory.Exists(folder))
                System.IO.Directory.CreateDirectory(folder);

            // 确保数据库存在！ 
            // 如果数据库已经存在，则返回 true。 
            // 如果数据库不存在，则返回 false。 
            if (System.IO.File.Exists(LocalDatabase) == false)
            {
                try
                {
                    SqlCeEngine SQLCEEngine = new SqlCeEngine(LocalConnection);
                    SQLCEEngine.CreateDatabase();
                    return true;
                }
                catch (SqlCeException e)
                {
                    System.Diagnostics.Debug.Print(e.Message.ToString());
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        //删除数据库 
        public void DeleteDatabase()
        {
            using (SqlCeConnection conn = new SqlCeConnection(LocalConnection))
            {
                conn.Close();
            }

            // 删除数据库 
            if (System.IO.File.Exists(LocalDatabase) == true)
            {
                System.IO.File.Delete(LocalDatabase);
            }
        }

        //创建数据表 
        public bool CreateKLineTable()
        {
            try
            {
                // 初始化出一个新的数据库连接 
                using (SqlCeConnection conn = new SqlCeConnection(LocalConnection))
                {
                    // 建立数据库连接 
                    conn.Open();

                    using (SqlCeCommand cmdSqlCe = conn.CreateCommand())
                    {
                        cmdSqlCe.CommandText = "CREATE TABLE KLineTable(KLineTime nvarchar(19) PRIMARY KEY, KLineOpen money, KLineClose money, KLineHigh money, KLineLow money, KLineVolume float, KLineAmount float)";
                        cmdSqlCe.ExecuteNonQuery();
                    }

                    conn.Close();
                }
                return true;
            }
            catch (SqlCeException e)
            {
                System.Diagnostics.Debug.Print(e.Message.ToString());
                return false;
            }

            // strSQL CE 支持的数据类型及描述 
            // 数据类型 
            // bigint 
            // integer 
            // smallint 
            // tinyint 
            // bit 
            // numeric (p, s) 
            // money 
            // float 
            // real 
            // datetime 
            // national character(n) 
            // Synonym: 
            // nchar(n) 
            // national character varying(n) 
            // Synonym: 
            // nvarchar(n) 
            // ntext 
            // binary(n) 
            // varbinary(n) 
            // image 
            // uniqueidentifier 
            // IDENTITY [(s, i)] 
            // ROWGUIDCOL 
        }

        public bool InsertIntoDatas(List<IStockKLine> kLines)
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                // 初始化出一个新的数据库连接 
                using (SqlCeConnection conn = new SqlCeConnection(LocalConnection))
                {
                    // 建立数据库连接 
                    conn.Open();

                    using (SqlCeCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO KLineTable(KLineTime, KLineOpen, KLineClose, KLineHigh, KLineLow, KLineVolume, KLineAmount) VALUES (?, ?, ?, ?, ?, ?, ?)";

                        cmd.Parameters.Add(new SqlCeParameter("p1", SqlDbType.NVarChar));
                        cmd.Parameters.Add(new SqlCeParameter("p2", SqlDbType.Money));
                        cmd.Parameters.Add(new SqlCeParameter("p3", SqlDbType.Money));
                        cmd.Parameters.Add(new SqlCeParameter("p4", SqlDbType.Money));
                        cmd.Parameters.Add(new SqlCeParameter("p5", SqlDbType.Money));
                        cmd.Parameters.Add(new SqlCeParameter("p6", SqlDbType.Float));
                        cmd.Parameters.Add(new SqlCeParameter("p7", SqlDbType.Float));

                        cmd.Parameters["p1"].Size = 19;
                        cmd.Prepare();

                        foreach (var it in kLines)
                        {
                            cmd.Parameters["p1"].Value = it.Time.ToString("yyyyMMddHHmmss");
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
                sw.Stop();
                //显示此次插入所用时间  
                System.Diagnostics.Debug.Print(string.Format("Elapsed Time is {0} Milliseconds", sw.ElapsedMilliseconds));
                return true;
            }
            catch (SqlCeException e)
            {
                return false;
            }
        }
        
        //返回可交换的数据集 
        public DataSet SelectDataSet(string p_strSQL)
        {
            DataSet Result;
            SqlCeDataAdapter da;

            try
            {
                // 初始化出一个新的数据库连接 
                using (SqlCeConnection conn = new SqlCeConnection(LocalConnection))
                {

                    // 建立数据库连接 
                    conn.Open();

                    // 初始化一个新的命令 
                    da = new SqlCeDataAdapter(p_strSQL, conn);

                    Result = new DataSet();

                    da.Fill(Result);

                    conn.Close();
                }
            }
            catch (SqlCeException e)
            {
                throw new Exception("执行查询语句错误！" + e.Message.ToString() + p_strSQL);
            }
            return Result;
        }


    }
}
