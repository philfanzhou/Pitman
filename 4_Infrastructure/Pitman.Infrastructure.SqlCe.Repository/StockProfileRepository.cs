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
    public class StockProfileRepository : SqlCeRepository
    {
        private const string tableName = "StockProfileTable";
        private const string colAccountingFirm = "colAccountingFirm";
        private const string colArea = "colArea";
        private const string colBoardSecretary = "colBoardSecretary";
        private const string colBusinessRegistration = "colBusinessRegistration";
        private const string colChairman = "colChairman";
        private const string colCodeA = "colCodeA";
        private const string colCodeB = "colCodeB";
        private const string colCodeH = "colCodeH";
        private const string colCompanyProfile = "colCompanyProfile";
        private const string colContactNumber = "colContactNumber";
        private const string colEmail = "colEmail";
        private const string colEnglishName = "colEnglishName";
        private const string colEstablishmentDate = "colEstablishmentDate";
        private const string colExchange = "colExchange";
        private const string colFax = "colFax";
        private const string colFullName = "colFullName";
        private const string colGeneralManager = "colGeneralManager";
        private const string colIndependentDirectors = "colIndependentDirectors";
        private const string colIndustry = "colIndustry";
        private const string colLawOffice = "colLawOffice";
        private const string colLegalRepresentative = "colLegalRepresentative";
        private const string colListDate = "colListDate";
        private const string colNameUsedBefore = "colNameUsedBefore";
        private const string colNumberOfEmployees = "colNumberOfEmployees";
        private const string colNumberOfManagement = "colNumberOfManagement";
        private const string colOfficeAddress = "colOfficeAddress";
        private const string colPrimeBusiness = "colPrimeBusiness";
        private const string colRegisteredAddress = "colRegisteredAddress";
        private const string colRegisteredCapital = "colRegisteredCapital";
        private const string colSecuritiesAffairsRepresentatives = "colSecuritiesAffairsRepresentatives";
        private const string colShortNameA = "colShortNameA";
        private const string colShortNameB = "colShortNameB";
        private const string colShortNameH = "colShortNameH";
        private const string colWebsite = "colWebsite";
        private const string colZipCode = "colZipCode";

        public StockProfileRepository(string fullPath) : base(fullPath) { }

        protected override void OnDbCreating()
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("CREATE TABLE {0}", tableName);
            sbSql.AppendFormat("({0} nvarchar(256), ", colAccountingFirm);
            sbSql.AppendFormat("{0} nvarchar(256), ", colArea);
            sbSql.AppendFormat("{0} nvarchar(256), ", colBoardSecretary);
            sbSql.AppendFormat("{0} nvarchar(256), ", colBusinessRegistration);
            sbSql.AppendFormat("{0} nvarchar(256), ", colChairman);
            sbSql.AppendFormat("{0} nvarchar(16)  PRIMARY KEY, ", colCodeA);
            sbSql.AppendFormat("{0} nvarchar(16), ", colCodeB);
            sbSql.AppendFormat("{0} nvarchar(16), ", colCodeH);
            sbSql.AppendFormat("{0} nvarchar(1024), ", colCompanyProfile);
            sbSql.AppendFormat("{0} nvarchar(256), ", colContactNumber);
            sbSql.AppendFormat("{0} nvarchar(256), ", colEmail);
            sbSql.AppendFormat("{0} nvarchar(256), ", colEnglishName);
            sbSql.AppendFormat("{0} nvarchar(19), ", colEstablishmentDate);
            sbSql.AppendFormat("{0} int, ", colExchange);
            sbSql.AppendFormat("{0} nvarchar(256), ", colFax);
            sbSql.AppendFormat("{0} nvarchar(256), ", colFullName);
            sbSql.AppendFormat("{0} nvarchar(256), ", colGeneralManager);
            sbSql.AppendFormat("{0} nvarchar(256), ", colIndependentDirectors);
            sbSql.AppendFormat("{0} nvarchar(256), ", colIndustry);
            sbSql.AppendFormat("{0} nvarchar(256), ", colLawOffice);
            sbSql.AppendFormat("{0} nvarchar(256), ", colLegalRepresentative);
            sbSql.AppendFormat("{0} nvarchar(19), ", colListDate);
            sbSql.AppendFormat("{0} nvarchar(256), ", colNameUsedBefore);
            sbSql.AppendFormat("{0} int, ", colNumberOfEmployees);
            sbSql.AppendFormat("{0} int, ", colNumberOfManagement);
            sbSql.AppendFormat("{0} nvarchar(256), ", colOfficeAddress);
            sbSql.AppendFormat("{0} nvarchar(1024), ", colPrimeBusiness);
            sbSql.AppendFormat("{0} nvarchar(256), ", colRegisteredAddress);
            sbSql.AppendFormat("{0} nvarchar(256), ", colRegisteredCapital);
            sbSql.AppendFormat("{0} nvarchar(256), ", colSecuritiesAffairsRepresentatives);
            sbSql.AppendFormat("{0} nvarchar(64), ", colShortNameA);
            sbSql.AppendFormat("{0} nvarchar(64), ", colShortNameB);
            sbSql.AppendFormat("{0} nvarchar(64), ", colShortNameH);
            sbSql.AppendFormat("{0} nvarchar(256), ", colWebsite);
            sbSql.AppendFormat("{0} nvarchar(256))", colZipCode);

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

        public bool Exists(IStockProfile stockProfile)
        {
            bool bExists = false;
            string sql =
                string.Format("SELECT * FROM {0} WHERE {1}='{2}'",
                tableName,
                colCodeA,
                stockProfile.CodeA);

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

        public void AddRange(IEnumerable<IStockProfile> stockProfiles)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("INSERT INTO {0}", tableName);

            sbSql.AppendFormat("({0}, ", colAccountingFirm);
            sbSql.AppendFormat("{0}, ", colArea);
            sbSql.AppendFormat("{0}, ", colBoardSecretary);
            sbSql.AppendFormat("{0}, ", colBusinessRegistration);
            sbSql.AppendFormat("{0}, ", colChairman);

            sbSql.AppendFormat("{0}, ", colCodeA);
            sbSql.AppendFormat("{0}, ", colCodeB);
            sbSql.AppendFormat("{0}, ", colCodeH);
            sbSql.AppendFormat("{0}, ", colCompanyProfile);
            sbSql.AppendFormat("{0}, ", colContactNumber);

            sbSql.AppendFormat("{0}, ", colEmail);
            sbSql.AppendFormat("{0}, ", colEnglishName);
            sbSql.AppendFormat("{0}, ", colEstablishmentDate);
            sbSql.AppendFormat("{0}, ", colExchange);
            sbSql.AppendFormat("{0}, ", colFax);

            sbSql.AppendFormat("{0}, ", colFullName);
            sbSql.AppendFormat("{0}, ", colGeneralManager);
            sbSql.AppendFormat("{0}, ", colIndependentDirectors);
            sbSql.AppendFormat("{0}, ", colIndustry);
            sbSql.AppendFormat("{0}, ", colLawOffice);

            sbSql.AppendFormat("{0}, ", colLegalRepresentative);
            sbSql.AppendFormat("{0}, ", colListDate);
            sbSql.AppendFormat("{0}, ", colNameUsedBefore);
            sbSql.AppendFormat("{0}, ", colNumberOfEmployees);
            sbSql.AppendFormat("{0}, ", colNumberOfManagement);

            sbSql.AppendFormat("{0}, ", colOfficeAddress);
            sbSql.AppendFormat("{0}, ", colPrimeBusiness);
            sbSql.AppendFormat("{0}, ", colRegisteredAddress);
            sbSql.AppendFormat("{0}, ", colRegisteredCapital);
            sbSql.AppendFormat("{0}, ", colSecuritiesAffairsRepresentatives);

            sbSql.AppendFormat("{0}, ", colShortNameA);
            sbSql.AppendFormat("{0}, ", colShortNameB);
            sbSql.AppendFormat("{0}, ", colShortNameH);
            sbSql.AppendFormat("{0}, ", colWebsite);
            sbSql.AppendFormat("{0}) ", colZipCode);

            sbSql.Append("VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)");

            // 初始化出一个新的数据库连接 
            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                // 建立数据库连接 
                conn.Open();

                using (SqlCeCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sbSql.ToString();

                    cmd.Parameters.Add(new SqlCeParameter(colAccountingFirm, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colArea, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colBoardSecretary, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colBusinessRegistration, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colChairman, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colCodeA, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colCodeB, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colCodeH, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colCompanyProfile, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colContactNumber, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colEmail, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colEnglishName, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colEstablishmentDate, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colExchange, SqlDbType.Int));
                    cmd.Parameters.Add(new SqlCeParameter(colFax, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colFullName, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colGeneralManager, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colIndependentDirectors, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colIndustry, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colLawOffice, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colLegalRepresentative, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colListDate, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colNameUsedBefore, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colNumberOfEmployees, SqlDbType.Int));
                    cmd.Parameters.Add(new SqlCeParameter(colNumberOfManagement, SqlDbType.Int));
                    cmd.Parameters.Add(new SqlCeParameter(colOfficeAddress, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colPrimeBusiness, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colRegisteredAddress, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colRegisteredCapital, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colSecuritiesAffairsRepresentatives, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colShortNameA, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colShortNameB, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colShortNameH, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colWebsite, SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlCeParameter(colZipCode, SqlDbType.NVarChar));
                    
                    cmd.Parameters[colAccountingFirm].Size = 256;
                    cmd.Parameters[colArea].Size = 256;
                    cmd.Parameters[colBoardSecretary].Size = 256;
                    cmd.Parameters[colBusinessRegistration].Size = 256;
                    cmd.Parameters[colChairman].Size = 256;
                    cmd.Parameters[colCodeA].Size = 16;
                    cmd.Parameters[colCodeB].Size = 16;
                    cmd.Parameters[colCodeH].Size = 16;
                    cmd.Parameters[colCompanyProfile].Size = 1024;
                    cmd.Parameters[colContactNumber].Size = 256;
                    cmd.Parameters[colEmail].Size = 256;
                    cmd.Parameters[colEnglishName].Size = 256;
                    cmd.Parameters[colEstablishmentDate].Size = 19;
                    cmd.Parameters[colFax].Size = 256;
                    cmd.Parameters[colFullName].Size = 256;
                    cmd.Parameters[colGeneralManager].Size = 256;
                    cmd.Parameters[colIndependentDirectors].Size = 256;
                    cmd.Parameters[colIndustry].Size = 256;
                    cmd.Parameters[colLawOffice].Size = 256;
                    cmd.Parameters[colLegalRepresentative].Size = 256;
                    cmd.Parameters[colListDate].Size = 19;
                    cmd.Parameters[colNameUsedBefore].Size = 256;
                    cmd.Parameters[colOfficeAddress].Size = 256;
                    cmd.Parameters[colPrimeBusiness].Size = 1024;
                    cmd.Parameters[colRegisteredAddress].Size = 256;
                    cmd.Parameters[colRegisteredCapital].Size = 256;
                    cmd.Parameters[colSecuritiesAffairsRepresentatives].Size = 256;
                    cmd.Parameters[colShortNameA].Size = 64;
                    cmd.Parameters[colShortNameB].Size = 64;
                    cmd.Parameters[colShortNameH].Size = 64;
                    cmd.Parameters[colWebsite].Size = 256;
                    cmd.Parameters[colZipCode].Size = 256;

                    cmd.Prepare();

                    foreach (var it in stockProfiles)
                    {
                        cmd.Parameters[colAccountingFirm].Value = it.AccountingFirm;
                        cmd.Parameters[colArea].Value = it.Area;
                        cmd.Parameters[colBoardSecretary].Value = it.BoardSecretary;
                        cmd.Parameters[colBusinessRegistration].Value = it.BusinessRegistration;
                        cmd.Parameters[colChairman].Value = it.Chairman;
                        cmd.Parameters[colCodeA].Value = it.CodeA;
                        cmd.Parameters[colCodeB].Value = it.CodeB;
                        cmd.Parameters[colCodeH].Value = it.CodeH;
                        cmd.Parameters[colCompanyProfile].Value = it.CompanyProfile;
                        cmd.Parameters[colContactNumber].Value = it.ContactNumber;
                        cmd.Parameters[colEmail].Value = it.Email;
                        cmd.Parameters[colEnglishName].Value = it.EnglishName;
                        cmd.Parameters[colEstablishmentDate].Value = it.EstablishmentDate.ToString("yyyy-MM-dd HH:mm:ss");
                        cmd.Parameters[colExchange].Value = it.Exchange;
                        cmd.Parameters[colFax].Value = it.Fax;
                        cmd.Parameters[colFullName].Value = it.FullName;
                        cmd.Parameters[colGeneralManager].Value = it.GeneralManager;
                        cmd.Parameters[colIndependentDirectors].Value = it.IndependentDirectors;
                        cmd.Parameters[colIndustry].Value = it.Industry;
                        cmd.Parameters[colLawOffice].Value = it.LawOffice;
                        cmd.Parameters[colLegalRepresentative].Value = it.LegalRepresentative;
                        cmd.Parameters[colListDate].Value = it.ListDate.ToString("yyyy-MM-dd HH:mm:ss");
                        cmd.Parameters[colNameUsedBefore].Value = it.NameUsedBefore;
                        cmd.Parameters[colNumberOfEmployees].Value = it.NumberOfEmployees;
                        cmd.Parameters[colNumberOfManagement].Value = it.NumberOfManagement;
                        cmd.Parameters[colOfficeAddress].Value = it.OfficeAddress;
                        cmd.Parameters[colPrimeBusiness].Value = it.PrimeBusiness;
                        cmd.Parameters[colRegisteredAddress].Value = it.RegisteredAddress;
                        cmd.Parameters[colRegisteredCapital].Value = it.RegisteredCapital;
                        cmd.Parameters[colSecuritiesAffairsRepresentatives].Value = it.SecuritiesAffairsRepresentatives;
                        cmd.Parameters[colShortNameA].Value = it.ShortNameA;
                        cmd.Parameters[colShortNameB].Value = it.ShortNameB;
                        cmd.Parameters[colShortNameH].Value = it.ShortNameH;
                        cmd.Parameters[colWebsite].Value = it.Website;
                        cmd.Parameters[colZipCode].Value = it.ZipCode;

                        cmd.ExecuteNonQuery();
                    }
                }

                conn.Close();
            }
        }

        public void UpdateRange(IEnumerable<IStockProfile> stockProfiles)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat("UPDATE {0} SET ", tableName);

            sbSql.AppendFormat("{0}=@{0}, ", colAccountingFirm);
            sbSql.AppendFormat("{0}=@{0}, ", colArea);
            sbSql.AppendFormat("{0}=@{0}, ", colBoardSecretary);
            sbSql.AppendFormat("{0}=@{0}, ", colBusinessRegistration);
            sbSql.AppendFormat("{0}=@{0}, ", colChairman);
            //sbSql.AppendFormat("{0}=@{0}, ", colCodeA);
            sbSql.AppendFormat("{0}=@{0}, ", colCodeB);
            sbSql.AppendFormat("{0}=@{0}, ", colCodeH);
            sbSql.AppendFormat("{0}=@{0}, ", colCompanyProfile);
            sbSql.AppendFormat("{0}=@{0}, ", colContactNumber);
            sbSql.AppendFormat("{0}=@{0}, ", colEmail);
            sbSql.AppendFormat("{0}=@{0}, ", colEnglishName);
            sbSql.AppendFormat("{0}=@{0}, ", colEstablishmentDate);
            sbSql.AppendFormat("{0}=@{0}, ", colExchange);
            sbSql.AppendFormat("{0}=@{0}, ", colFax);
            sbSql.AppendFormat("{0}=@{0}, ", colFullName);
            sbSql.AppendFormat("{0}=@{0}, ", colGeneralManager);
            sbSql.AppendFormat("{0}=@{0}, ", colIndependentDirectors);
            sbSql.AppendFormat("{0}=@{0}, ", colIndustry);
            sbSql.AppendFormat("{0}=@{0}, ", colLawOffice);
            sbSql.AppendFormat("{0}=@{0}, ", colLegalRepresentative);
            sbSql.AppendFormat("{0}=@{0}, ", colListDate);
            sbSql.AppendFormat("{0}=@{0}, ", colNameUsedBefore);
            sbSql.AppendFormat("{0}=@{0}, ", colNumberOfEmployees);
            sbSql.AppendFormat("{0}=@{0}, ", colNumberOfManagement);
            sbSql.AppendFormat("{0}=@{0}, ", colOfficeAddress);
            sbSql.AppendFormat("{0}=@{0}, ", colPrimeBusiness);
            sbSql.AppendFormat("{0}=@{0}, ", colRegisteredAddress);
            sbSql.AppendFormat("{0}=@{0}, ", colRegisteredCapital);
            sbSql.AppendFormat("{0}=@{0}, ", colSecuritiesAffairsRepresentatives);
            sbSql.AppendFormat("{0}=@{0}, ", colShortNameA);
            sbSql.AppendFormat("{0}=@{0}, ", colShortNameB);
            sbSql.AppendFormat("{0}=@{0}, ", colShortNameH);
            sbSql.AppendFormat("{0}=@{0}, ", colWebsite);
            sbSql.AppendFormat("{0}=@{0} ", colZipCode);

            sbSql.AppendFormat("WHERE {0}=@{0}", colCodeA);

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

                        foreach (var it in stockProfiles)
                        {
                            cmd.Parameters.Add(new SqlCeParameter(colAccountingFirm, it.AccountingFirm));
                            cmd.Parameters.Add(new SqlCeParameter(colArea, it.Area));
                            cmd.Parameters.Add(new SqlCeParameter(colBoardSecretary, it.BoardSecretary));
                            cmd.Parameters.Add(new SqlCeParameter(colBusinessRegistration, it.BusinessRegistration));
                            cmd.Parameters.Add(new SqlCeParameter(colChairman, it.Chairman));
                            cmd.Parameters.Add(new SqlCeParameter(colCodeA, it.CodeA));
                            cmd.Parameters.Add(new SqlCeParameter(colCodeB, it.CodeB));
                            cmd.Parameters.Add(new SqlCeParameter(colCodeH, it.CodeH));
                            cmd.Parameters.Add(new SqlCeParameter(colCompanyProfile, it.CompanyProfile));
                            cmd.Parameters.Add(new SqlCeParameter(colContactNumber, it.ContactNumber));
                            cmd.Parameters.Add(new SqlCeParameter(colEmail, it.Email));
                            cmd.Parameters.Add(new SqlCeParameter(colEnglishName, it.EnglishName));
                            cmd.Parameters.Add(new SqlCeParameter(colEstablishmentDate, it.EstablishmentDate.ToString("yyyy-MM-dd HH:mm:ss")));
                            cmd.Parameters.Add(new SqlCeParameter(colExchange, it.Exchange));
                            cmd.Parameters.Add(new SqlCeParameter(colFax, it.Fax));
                            cmd.Parameters.Add(new SqlCeParameter(colFullName, it.FullName));
                            cmd.Parameters.Add(new SqlCeParameter(colGeneralManager, it.GeneralManager));
                            cmd.Parameters.Add(new SqlCeParameter(colIndependentDirectors, it.IndependentDirectors));
                            cmd.Parameters.Add(new SqlCeParameter(colIndustry, it.Industry));
                            cmd.Parameters.Add(new SqlCeParameter(colLawOffice, it.LawOffice));
                            cmd.Parameters.Add(new SqlCeParameter(colLegalRepresentative, it.LegalRepresentative));
                            cmd.Parameters.Add(new SqlCeParameter(colListDate, it.ListDate.ToString("yyyy-MM-dd HH:mm:ss")));
                            cmd.Parameters.Add(new SqlCeParameter(colNameUsedBefore, it.NameUsedBefore));
                            cmd.Parameters.Add(new SqlCeParameter(colNumberOfEmployees, it.NumberOfEmployees));
                            cmd.Parameters.Add(new SqlCeParameter(colNumberOfManagement, it.NumberOfManagement));
                            cmd.Parameters.Add(new SqlCeParameter(colOfficeAddress, it.OfficeAddress));
                            cmd.Parameters.Add(new SqlCeParameter(colPrimeBusiness, it.PrimeBusiness));
                            cmd.Parameters.Add(new SqlCeParameter(colRegisteredAddress, it.RegisteredAddress));
                            cmd.Parameters.Add(new SqlCeParameter(colRegisteredCapital, it.RegisteredCapital));
                            cmd.Parameters.Add(new SqlCeParameter(colSecuritiesAffairsRepresentatives, it.SecuritiesAffairsRepresentatives));
                            cmd.Parameters.Add(new SqlCeParameter(colShortNameA, it.ShortNameA));
                            cmd.Parameters.Add(new SqlCeParameter(colShortNameB, it.ShortNameB));
                            cmd.Parameters.Add(new SqlCeParameter(colShortNameH, it.ShortNameH));
                            cmd.Parameters.Add(new SqlCeParameter(colWebsite, it.Website));
                            cmd.Parameters.Add(new SqlCeParameter(colZipCode, it.ZipCode));

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

        public IEnumerable<IStockProfile> GetAll()
        {
            List<StockProfile> result = new List<StockProfile>();
            string sql = string.Format("SELECT * FROM {0}", tableName);

            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                using (SqlCeCommand cmd = new SqlCeCommand(sql, conn))
                {
                    SqlCeDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        StockProfile dbo = new StockProfile
                        {
                            AccountingFirm = reader[colAccountingFirm].ToString().Trim(),
                            Area = reader[colArea].ToString().Trim(),
                            BoardSecretary = reader[colBoardSecretary].ToString().Trim(),
                            BusinessRegistration = reader[colBusinessRegistration].ToString().Trim(),
                            Chairman = reader[colChairman].ToString().Trim(),
                            CodeA = reader[colCodeA].ToString().Trim(),
                            CodeB = reader[colCodeB].ToString().Trim(),
                            CodeH = reader[colCodeH].ToString().Trim(),
                            CompanyProfile = reader[colCompanyProfile].ToString().Trim(),
                            ContactNumber = reader[colContactNumber].ToString().Trim(),
                            Email = reader[colEmail].ToString().Trim(),
                            EnglishName = reader[colEnglishName].ToString().Trim(),
                            EstablishmentDate = DateTime.Parse(reader[colEstablishmentDate].ToString().Trim()),
                            Exchange = (Market)Int32.Parse(reader[colExchange].ToString().Trim()),
                            Fax = reader[colFax].ToString().Trim(),
                            FullName = reader[colFullName].ToString().Trim(),
                            GeneralManager = reader[colGeneralManager].ToString().Trim(),
                            IndependentDirectors = reader[colIndependentDirectors].ToString().Trim(),
                            Industry = reader[colIndustry].ToString().Trim(),
                            LawOffice = reader[colLawOffice].ToString().Trim(),
                            LegalRepresentative = reader[colLegalRepresentative].ToString().Trim(),
                            ListDate = DateTime.Parse(reader[colListDate].ToString().Trim()),
                            NameUsedBefore = reader[colNameUsedBefore].ToString().Trim(),
                            NumberOfEmployees = Int32.Parse(reader[colNumberOfEmployees].ToString().Trim()),
                            NumberOfManagement = Int32.Parse(reader[colNumberOfManagement].ToString().Trim()),
                            OfficeAddress = reader[colOfficeAddress].ToString().Trim(),
                            PrimeBusiness = reader[colPrimeBusiness].ToString().Trim(),
                            RegisteredAddress = reader[colRegisteredAddress].ToString().Trim(),
                            RegisteredCapital = reader[colRegisteredCapital].ToString().Trim(),
                            SecuritiesAffairsRepresentatives = reader[colSecuritiesAffairsRepresentatives].ToString().Trim(),
                            ShortNameA = reader[colShortNameA].ToString().Trim(),
                            ShortNameB = reader[colShortNameB].ToString().Trim(),
                            ShortNameH = reader[colShortNameH].ToString().Trim(),
                            Website = reader[colWebsite].ToString().Trim(),
                            ZipCode = reader[colZipCode].ToString().Trim(),
                        };
                        result.Add(dbo);
                    }
                    reader.Close();
                }

                conn.Close();
            }
            return result;
        }

        public IStockProfile Get(string keyCode)
        {
            StockProfile result = null;
            string sql = string.Format("SELECT * FROM {0} WHERE {1}='{2}'", tableName, colCodeA, keyCode);

            using (SqlCeConnection conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                using (SqlCeCommand cmd = new SqlCeCommand(sql, conn))
                {
                    SqlCeDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        StockProfile dbo = new StockProfile
                        {
                            AccountingFirm = reader[colAccountingFirm].ToString().Trim(),
                            Area = reader[colArea].ToString().Trim(),
                            BoardSecretary = reader[colBoardSecretary].ToString().Trim(),
                            BusinessRegistration = reader[colBusinessRegistration].ToString().Trim(),
                            Chairman = reader[colChairman].ToString().Trim(),
                            CodeA = reader[colCodeA].ToString().Trim(),
                            CodeB = reader[colCodeB].ToString().Trim(),
                            CodeH = reader[colCodeH].ToString().Trim(),
                            CompanyProfile = reader[colCompanyProfile].ToString().Trim(),
                            ContactNumber = reader[colContactNumber].ToString().Trim(),
                            Email = reader[colEmail].ToString().Trim(),
                            EnglishName = reader[colEnglishName].ToString().Trim(),
                            EstablishmentDate = DateTime.Parse(reader[colEstablishmentDate].ToString().Trim()),
                            Exchange = (Market)Int32.Parse(reader[colExchange].ToString().Trim()),
                            Fax = reader[colFax].ToString().Trim(),
                            FullName = reader[colFullName].ToString().Trim(),
                            GeneralManager = reader[colGeneralManager].ToString().Trim(),
                            IndependentDirectors = reader[colIndependentDirectors].ToString().Trim(),
                            Industry = reader[colIndustry].ToString().Trim(),
                            LawOffice = reader[colLawOffice].ToString().Trim(),
                            LegalRepresentative = reader[colLegalRepresentative].ToString().Trim(),
                            ListDate = DateTime.Parse(reader[colListDate].ToString().Trim()),
                            NameUsedBefore = reader[colNameUsedBefore].ToString().Trim(),
                            NumberOfEmployees = Int32.Parse(reader[colNumberOfEmployees].ToString().Trim()),
                            NumberOfManagement = Int32.Parse(reader[colNumberOfManagement].ToString().Trim()),
                            OfficeAddress = reader[colOfficeAddress].ToString().Trim(),
                            PrimeBusiness = reader[colPrimeBusiness].ToString().Trim(),
                            RegisteredAddress = reader[colRegisteredAddress].ToString().Trim(),
                            RegisteredCapital = reader[colRegisteredCapital].ToString().Trim(),
                            SecuritiesAffairsRepresentatives = reader[colSecuritiesAffairsRepresentatives].ToString().Trim(),
                            ShortNameA = reader[colShortNameA].ToString().Trim(),
                            ShortNameB = reader[colShortNameB].ToString().Trim(),
                            ShortNameH = reader[colShortNameH].ToString().Trim(),
                            Website = reader[colWebsite].ToString().Trim(),
                            ZipCode = reader[colZipCode].ToString().Trim(),
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
