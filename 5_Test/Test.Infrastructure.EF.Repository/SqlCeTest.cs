using Framework.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ore.Infrastructure.MarketData;
using Pitman.Infrastructure.EF.Repository;
using System;
using System.IO;

namespace Test.Infrastructure.EF.Repository
{
    [TestClass]
    public class SqlCeTest
    {
        private static string directory = Environment.CurrentDirectory + @"\Data\Day\Shanghai\";

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            if(Directory.Exists(directory) == false)
            {
                Directory.CreateDirectory(directory);
            }
        }

        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            string dir = Environment.CurrentDirectory + @"\Data";
            if (Directory.Exists(dir))
            {
                Directory.Delete(dir, true);
            }
        }

        [TestMethod]
        public void TestKLineReadAndWrite()
        {
            StockKLine insertData = new StockKLine()
            {
                Amount = 123214124,
                Close = 19.96,
                Open = 19.05,
                High = 19.98,
                Low = 19.01,
                Time = DateTime.Now.Date,
                Volume = 32342352352
            };
            
            string fileName = "600036_2015.sdf";
            string fullPath = Path.Combine(directory, fileName);

            // Add
            using (IRepositoryContext context = ContextFactory.Create(ContextType.KLine, fullPath))
            {
                var repository = new Repository<StockKLine>(context);
                repository.Add(insertData);
                repository.UnitOfWork.Commit();
            }

            // Read
            StockKLine readData;
            using (IRepositoryContext context = ContextFactory.Create(ContextType.KLine, fullPath))
            {
                var repository = new Repository<StockKLine>(context);
                readData = repository.Get(insertData.Time);
            }
            Assert.IsNotNull(readData);
            Assert.AreEqual(insertData.Time, readData.Time);

            // update
            StockKLine updatedData = readData;
            updatedData.Open = 100;
            using (IRepositoryContext context = ContextFactory.Create(ContextType.KLine, fullPath))
            {
                var repository = new Repository<StockKLine>(context);
                repository.Update(updatedData);
                repository.UnitOfWork.Commit();
            }
            // Read
            using (IRepositoryContext context = ContextFactory.Create(ContextType.KLine, fullPath))
            {
                var repository = new Repository<StockKLine>(context);
                readData = repository.Get(insertData.Time);
            }
            Assert.IsTrue(readData.Open - 100 < 0.0000001);
        }

        [TestMethod]
        public void TestSecurityReadAndWrite()
        {
            Security insertData = new Security()
            {
                Code = "600036",
                ShortName = "招商银行招商银行招商银行",
                Market = Market.XSHG,
                Type = SecurityType.Sotck
            };

            string fileName = "Security.sdf";
            string fullPath = Path.Combine(directory, fileName);

            // Add
            using (IRepositoryContext context = ContextFactory.Create(ContextType.Security, fullPath))
            {
                var repository = new Repository<Security>(context);
                repository.Add(insertData);
                repository.UnitOfWork.Commit();
            }

            // Read
            Security readData;
            using (IRepositoryContext context = ContextFactory.Create(ContextType.Security, fullPath))
            {
                var repository = new Repository<Security>(context);
                readData = repository.Get(insertData.Code);
            }
            Assert.IsNotNull(readData);
            Assert.AreEqual(insertData.ShortName, readData.ShortName);
        }

        [TestMethod]
        public void TestParticipationReadAndWrite()
        {
            Participation insertData = new Participation()
            {
                Time = new DateTime(2016, 1, 11),
                CostPrice1Day = 16.37,
                CostPrice20Day = 17.62,
                MainForceInflows = -18890.18,
                SuperLargeInflows = -13224.41,                
                Value = 37.97
            };

            string fileName = "Participation.sdf";
            string fullPath = Path.Combine(directory, fileName);

            // Add
            using (IRepositoryContext context = ContextFactory.Create(ContextType.Participation, fullPath))
            {
                var repository = new Repository<Participation>(context);
                repository.Add(insertData);
                repository.UnitOfWork.Commit();
            }

            // Read
            Participation readData;
            using (IRepositoryContext context = ContextFactory.Create(ContextType.Participation, fullPath))
            {
                var repository = new Repository<Participation>(context);
                readData = repository.Get(insertData.Time);
            }
            Assert.IsNotNull(readData);
            Assert.AreEqual(insertData.Time, readData.Time);
        }

        [TestMethod]
        public void TestStockBonusReadAndWrite()
        {
            StockBonus insertData = new StockBonus()
            {
                ActualDispatchRate = 0,
                BAndHDividendAfterTax = 0,
                BAndHPreTaxDividend = 0,
                BonusRate = 0,
                CapitalStockBaseDate = new DateTime(2015, 7, 2),
                CapitalStockBeforeDispatch = 0,
                CapitalSurplusIncreaseRate = 0,
                ConvertibleBondDate = new DateTime(2015, 7, 2),
                DateOfDeclaration = new DateTime(2015, 6, 25),
                Description = "",
                DispatchExpiryDate = new DateTime(2015, 7, 2),
                DispatchListingDate = new DateTime(2015, 7, 2),
                DispatchPrice = 0,
                DispatchRate = 0,
                DividendAfterTax = 0,
                ExchangeRate = 0,
                ExdividendDate = new DateTime(2015, 7, 2),
                ExpirationDate = new DateTime(2015, 7, 2),
                IncreaseRate = 0,
                IssuingObject = "",
                LastTradingDay = new DateTime(2015, 7, 2),
                PreTaxDividend = 0,
                RegisterDate = new DateTime(2015, 7, 2),
                ReserveSurplusIncreaseRate = 0,
                ResolutionOfShareholdersMeetingDate = new DateTime(2015, 7, 2),
                ShareSplitCount = 0,
                StartOrArriveDate = new DateTime(2015, 7, 2),
                TotalDispatch = 0,
                TransferredAllottedPrice = 0,
                TransferredAllottedRate = 0,
                Type = BounsType.ProfitSharing
            };
            string fileName = "StockBonusData.sdf";
            string fullPath = Path.Combine(directory, fileName);

            // Add
            using (IRepositoryContext context = ContextFactory.Create(ContextType.StockBonus, fullPath))
            {
                var repository = new Repository<StockBonus>(context);
                repository.Add(insertData);
                repository.UnitOfWork.Commit();
            }

            // Read
            StockBonus readData;
            using (IRepositoryContext context = ContextFactory.Create(ContextType.StockBonus, fullPath))
            {
                var repository = new Repository<StockBonus>(context);
                readData = repository.Get(insertData.DateOfDeclaration);
            }
            Assert.IsNotNull(readData);
            Assert.AreEqual(insertData.DateOfDeclaration, readData.DateOfDeclaration);

            // update
            StockBonus updatedData = readData;
            updatedData.PreTaxDividend = 10;
            using (IRepositoryContext context = ContextFactory.Create(ContextType.StockBonus, fullPath))
            {
                var repository = new Repository<StockBonus>(context);
                repository.Update(updatedData);
                repository.UnitOfWork.Commit();
            }
            // Read
            using (IRepositoryContext context = ContextFactory.Create(ContextType.StockBonus, fullPath))
            {
                var repository = new Repository<StockBonus>(context);
                readData = repository.Get(insertData.DateOfDeclaration);
            }
            Assert.AreEqual(readData.PreTaxDividend, 10);
        }

        [TestMethod]
        public void TestStockProfileReadAndWrite()
        {
            StockProfile insertData = new StockProfile()
            {
                AccountingFirm = "毕马威华振会计师事务所,毕马威会计师事务所",
                Area = "广东",
                BoardSecretary = "许世清",
                BusinessRegistration = "440301104433862",
                Chairman = "李建红",
                CodeA = "600036",
                CodeB = "--",
                CodeH = "03968",
                CompanyProfile = "    本行系依据人民银于 1986 年 8月 11 日、 1987 年 3月 7日分别下发的《关于同意 试办招商银行的批复 》([1986]175号),并于 1987 年 3月 31 日在原深圳市蛇口工商局注册登记的综合性银 行,设立时 的注册资本为 1亿元。\n根据蛇口中华会计师事务所 1988 年 10 月 24 日出具的《验资报告书》(字 (1988 )第 50 号),截至 1988 年 10 月 22 日,本行实收注册资为港币 52,642,661.61 元 ,美14,784,944.08 元。\n根据人民银行于 1989 年 1月 17 日下发的《关于同意招商银行增资扩股等问题批 复》(( [1989]12 号),本行于 1989 年进行了增资扩股。\n根据蛇口中华会计师事务所于 1991 年 7月 23 日出具的《验资报告》(内字 (1991 )第 29 号),截至 1991 年 5月 30 日,本行的实收 注册资本为 4亿元。\n1989 年 1月 19 日,本行获得原深圳市蛇口工商局颁发更新的《企业法人营执照》 (注册号:蛇企字 0025 号),注册资本为 号),注册资本为 4亿元。\n\n根据原深圳市经济体制改革办公室于 1993 年 6月 26 日下发的《关于同意招商银行 进行内部股份改组的批复 》(深[1993]73 号),原深圳市证券管理办公室于 1994 年 4月 4日下发的《关于同意招商银行改组为股份有限(内部)公司批复》( 1994 )90 号)、于 1994 年 5月 25 日下发的《关于同意招商银行 调整新增股份数量和权结构的批复 》(深证办(1994 )132 号)和《关于同意招商银行股份有 限公司章程的批复》( 深证办1994 )133 号),本行获准改制为股份有限公司。\n1994 年 5月 10 日,深圳中洲会计师事务所出具《验资报告》( 1994 验字 第 413 号),验证了本行改制并增资扩股后的实收为 1,122,727,212 元。\n1994 年 9月 5日,本行取得国家工商总局换发的《企业法人营执照》(注册号: 10001686 -X),注册资本为 1,122,730,000",
                ContactNumber = "0755-83198888",
                Email = "cmb@cmbchina.com",
                EnglishName = "China Merchants Bank Co., Ltd.",
                EstablishmentDate = new DateTime(1987, 3, 31),
                Exchange = Market.XSHG,
                Fax = "0755-83195109",
                FullName = "招商银行股份有限公司",
                GeneralManager = "田惠宇",
                IndependentDirectors = "马泽华,黄桂林,潘承伟,潘英丽,梁锦松,赵军",
                Industry = "银行",
                LawOffice = "君合(深圳)律师事务所,史密夫律师事务所",
                LegalRepresentative = "李建红",
                ListDate = new DateTime(2002, 4, 9),
                NameUsedBefore = "招商银行->G招行",
                NumberOfEmployees = 75109,
                NumberOfManagement = 38,
                OfficeAddress = "中国广东省深圳市福田区深南大道7088号",
                PrimeBusiness = "吸收公众存款；发放短期、中期和长期贷款；办理结算；办理票据贴现；发行金融债券；代理发行、代理兑付、承销政府债券；买卖政府债券；同业拆借；提供信用证服务及担保；代理收付款项及代理保险业务；提供保管箱服务。外汇存款；外汇贷款；外汇汇款；外币兑换；国际结算；结汇、售汇；同业外汇拆借；外汇票据的承兑和贴现；外汇借款；外汇担保；买卖和代理买卖股票以外的外币有价证券；发行和代理发行股票以外的外币有价证券；自营和代客外汇买卖；资信调查、咨询、见证业务；离岸金融业务。经中国银监会批准的其他业务。公司在商业银行中处于领先地位，已跻身世界银行150强，被英国《银行家》杂志评为中国最有竞争力的银行。在全国30多个经济中心城市设立了470多家机构，其中设立在长三角、珠三角、环渤海三大区域的网点占全部网点的62％。",
                RegisteredAddress = "中国广东省深圳市福田区深南大道7088号",
                RegisteredCapital = "252亿",
                SecuritiesAffairsRepresentatives = "吴涧兵",
                ShortNameA = "招商银行",
                ShortNameB = "--",
                ShortNameH = "招商银行",
                Website = "www.cmbchina.com",
                ZipCode = "518040"
            };
            string fileName = "StockProfile.sdf";
            string fullPath = Path.Combine(directory, fileName);

            // Add
            using (IRepositoryContext context = ContextFactory.Create(ContextType.StockProfile, fullPath))
            {
                var repository = new Repository<StockProfile>(context);
                repository.Add(insertData);
                repository.UnitOfWork.Commit();
            }

            // Read
            StockProfile readData;
            using (IRepositoryContext context = ContextFactory.Create(ContextType.StockProfile, fullPath))
            {
                var repository = new Repository<StockProfile>(context);
                readData = repository.Get(insertData.CodeA);
            }
            Assert.IsNotNull(readData);
            Assert.AreEqual(insertData.CodeA, readData.CodeA);

            // update
            StockProfile updatedData = readData;
            updatedData.CompanyProfile = "**************************";
            using (IRepositoryContext context = ContextFactory.Create(ContextType.StockProfile, fullPath))
            {
                var repository = new Repository<StockProfile>(context);
                repository.Update(updatedData);
                repository.UnitOfWork.Commit();
            }
            // Read
            using (IRepositoryContext context = ContextFactory.Create(ContextType.StockProfile, fullPath))
            {
                var repository = new Repository<StockProfile>(context);
                readData = repository.Get(insertData.CodeA);
            }
            Assert.AreEqual(readData.CompanyProfile, "**************************");
        }

        [TestMethod]
        public void TestStockStructureReadAndWrite()
        {
            StockStructure insertData = new StockStructure()
            {
                /// <summary>
                /// 变动日期
                /// </summary>
                DateOfChange = new DateTime(2016, 1, 15),
                /// <summary>
                /// 公告日期
                /// </summary>
                DateOfDeclaration = new DateTime(2016, 1, 17),
                /// <summary>
                /// 变更原因
                /// </summary>
                Reason = "*******************",

                /// <summary>
                /// 总股本
                /// </summary>
                TotalShares = 0,
                /// <summary>
                /// 流通A股
                /// </summary>
                SharesA = 0,
                /// <summary>
                /// 高管股
                /// </summary>
                ExecutiveShares = 0,
                /// <summary>
                /// 限售A股
                /// </summary>
                RestrictedSharesA = 0,
                /// <summary>
                /// 流通B股
                /// </summary>
                SharesB = 0,
                /// <summary>
                /// 限售B股
                /// </summary>
                RestrictedSharesB = 0,
                /// <summary>
                /// 流通H股
                /// </summary>
                SharesH = 0,
                /// <summary>
                /// 国家股
                /// </summary>
                StateShares = 0,
                /// <summary>
                /// 国有法人股
                /// </summary>
                StateOwnedLegalPersonShares = 0,
                /// <summary>
                /// 境内法人股
                /// </summary>
                DomesticLegalPersonShares = 0,
                /// <summary>
                /// 境内发起人股
                /// </summary>
                DomesticSponsorsShares = 0,
                /// <summary>
                /// 募集法人股
                /// </summary>
                RaiseLegalPersonShares = 0,
                /// <summary>
                /// 一般法人股
                /// </summary>
                GeneralLegalPersonShares = 0,
                /// <summary>
                /// 战略投资者持股
                /// </summary>
                StrategicInvestorsShares = 0,
                /// <summary>
                /// 基金持股
                /// </summary>
                FundsShares = 0,
                /// <summary>
                /// 转配股
                /// </summary>
                TransferredAllottedShares = 0,
                /// <summary>
                /// 内部职工股
                /// </summary>
                InternalStaffShares = 0,
                /// <summary>
                /// 优先股
                /// </summary>
                PreferredStock = 0,
            };
            string fileName = "StockStructure.sdf";
            string fullPath = Path.Combine(directory, fileName);

            // Add
            using (IRepositoryContext context = ContextFactory.Create(ContextType.StockStructure, fullPath))
            {
                var repository = new Repository<StockStructure>(context);
                repository.Add(insertData);
                repository.UnitOfWork.Commit();
            }

            // Read
            StockStructure readData;
            using (IRepositoryContext context = ContextFactory.Create(ContextType.StockStructure, fullPath))
            {
                var repository = new Repository<StockStructure>(context);
                readData = repository.Get(insertData.DateOfChange);
            }
            Assert.IsNotNull(readData);
            Assert.AreEqual(insertData.DateOfChange, readData.DateOfChange);

            // update
            StockStructure updatedData = readData;
            updatedData.SharesA = 100;
            using (IRepositoryContext context = ContextFactory.Create(ContextType.StockStructure, fullPath))
            {
                var repository = new Repository<StockStructure>(context);
                repository.Update(updatedData);
                repository.UnitOfWork.Commit();
            }
            // Read
            using (IRepositoryContext context = ContextFactory.Create(ContextType.StockStructure, fullPath))
            {
                var repository = new Repository<StockStructure>(context);
                readData = repository.Get(insertData.DateOfChange);
            }
            Assert.AreEqual(readData.SharesA, 100);
        }
    }
}
