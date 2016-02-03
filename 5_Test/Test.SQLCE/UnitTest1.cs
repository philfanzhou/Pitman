using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ore.Infrastructure.MarketData;
using Pitman.Infrastructure.SqlCe.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Test.SQLCE
{
    [TestClass]
    public class UnitTest1
    {
        #region

        private IEnumerable<IStockKLine> ExampleStockKLineMin1(DateTime bgnDay, DateTime endDay)
        {
            List<IStockKLine> example = new List<IStockKLine>();

            while (bgnDay <= endDay)
            {
                if (bgnDay.DayOfWeek != DayOfWeek.Saturday && bgnDay.DayOfWeek != DayOfWeek.Sunday)
                {
                    DateTime bgnAm = new DateTime(bgnDay.Year, bgnDay.Month, bgnDay.Day, 9, 0, 0);
                    DateTime endAm = new DateTime(bgnDay.Year, bgnDay.Month, bgnDay.Day, 11, 30, 0);
                    while (bgnAm <= endAm)
                    {
                        example.Add(new StockKLine
                        {
                            Amount = 1945900,
                            Close = 17.79,
                            Time = bgnAm,
                            High = 17.79,
                            Low = 17.78,
                            Open = 17.79,
                            Volume = 109401
                        });
                        bgnAm = bgnAm.AddMinutes(1);
                    }

                    DateTime bgnPm = new DateTime(bgnDay.Year, bgnDay.Month, bgnDay.Day, 13, 0, 0);
                    DateTime endPm = new DateTime(bgnDay.Year, bgnDay.Month, bgnDay.Day, 15, 0, 0);
                    while (bgnPm <= endPm)
                    {
                        example.Add(new StockKLine
                        {
                            Amount = 1945900,
                            Close = 17.79,
                            Time = bgnPm,
                            High = 17.79,
                            Low = 17.78,
                            Open = 17.79,
                            Volume = 109401
                        });
                        bgnPm = bgnPm.AddMinutes(1);
                    }
                }
                bgnDay = bgnDay.AddDays(1);
            }

            return example;
        }

        private IStockKLine GetUpdateData(DateTime dt)
        {
            return new StockKLine
            {
                Amount = 1000000,
                Close = 10.00,
                Time = dt,
                High = 11.11,
                Low = 12.22,
                Open = 13.33,
                Volume = 200001
            };
        }

        private IEnumerable<IStockKLine> GetUpdateDatas(IEnumerable<IStockKLine> kLines)
        {
            List<IStockKLine> example = new List<IStockKLine>();
            foreach (StockKLine it in kLines)
            {
                it.Amount = 0;
                example.Add(it);
            }
            return example;
        }

        [TestMethod]
        public void TestMethod_KLine()
        {
            //SQLCEWrapper _sqlCeWrapper = new SQLCEWrapper();
            //_sqlCeWrapper.CreateDatabase();

            //_sqlCeWrapper.CreateKLineTable();
            string filePath = Path.Combine(Environment.CurrentDirectory, "TestKine.sdf");
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            DateTime startTime = new DateTime(2015, 1, 1);
            DateTime endTime = new DateTime(2015, 12, 31);
            List<IStockKLine> kLines = ExampleStockKLineMin1(startTime, endTime).ToList();
            System.Diagnostics.Debug.Print(string.Format("KLine data count is {0}", kLines.Count));

            KLineRepository repository = new KLineRepository(filePath);
            repository.AddRange(kLines);
            //_sqlCeWrapper.InsertIntoDatas(kLines);  

            List<IStockKLine> getKLines = repository.Get(kLines[60].Time, kLines[120].Time).ToList();

            Assert.IsTrue(repository.Exists(kLines[0]));
            Assert.IsFalse(repository.Exists(GetUpdateData(kLines[0].Time.AddYears(1))));

            var updateData = GetUpdateData(kLines[0].Time);           

            repository.UpdateRange(new IStockKLine[] { updateData });
            IList<IStockKLine> result0 = repository.GetAll().ToList();

            Assert.IsTrue(repository.Exists(updateData));

            List<IStockKLine> updateKLines = GetUpdateDatas(kLines).ToList();
            repository.UpdateRange(updateKLines);

            //string p_strSQL = "SELECT * FROM KLineTable;";
            //DataSet dataSet = _sqlCeWrapper.SelectDataSet(p_strSQL);
            IList<IStockKLine> result = repository.GetAll().ToList();

            //if (dataSet != null && dataSet.Tables.Count > 0)
            //{
            //    foreach (DataTable table in dataSet.Tables)
            //        System.Diagnostics.Debug.Print(string.Format("table Rows count is {0}", table.Rows.Count));
            //}
            if(result != null && result.Count > 0)
            {
                System.Diagnostics.Debug.Print(string.Format("KLine Data count is {0}", result.Count));
            }
            Assert.AreEqual(kLines.Count, result.Count);
            
            //_sqlCeWrapper.DeleteDatabase();
        }

        #endregion

        #region TestMethod_Security

        private List<ISecurity> ExampleSecurities()
        {
            return new List<ISecurity>()
            {
                new Security { Code = "166105", Market = Market.XSHG, ShortName =  "信达增利", Type = SecurityType.Sotck },
                new Security { Code = "201000", Market = Market.XSHG, ShortName =  "R003", Type = SecurityType.Sotck },
                new Security { Code = "600006", Market = Market.XSHG, ShortName =  "东风汽车", Type = SecurityType.Sotck },
                new Security { Code = "600518", Market = Market.XSHG, ShortName =  "康美药业", Type = SecurityType.Sotck },
                new Security { Code = "600036", Market = Market.XSHG, ShortName =  "招商银行", Type = SecurityType.Sotck },
                new Security { Code = "600298", Market = Market.XSHG, ShortName =  "安琪酵母", Type = SecurityType.Sotck },
                new Security { Code = "601933", Market = Market.XSHG, ShortName =  "永辉超市", Type = SecurityType.Sotck },
                new Security { Code = "600660", Market = Market.XSHG, ShortName =  "福耀玻璃", Type = SecurityType.Sotck },
                new Security { Code = "600196", Market = Market.XSHG, ShortName =  "复星医药", Type = SecurityType.Sotck },

                new Security { Code = "300118", Market = Market.XSHE, ShortName =  "东方日升", Type = SecurityType.Sotck },
                new Security { Code = "000800", Market = Market.XSHE, ShortName =  "一汽轿车", Type = SecurityType.Sotck },
                new Security { Code = "002122", Market = Market.XSHE, ShortName =  "天马股份", Type = SecurityType.Sotck },
                new Security { Code = "300490", Market = Market.XSHE, ShortName =  "华自科技", Type = SecurityType.Sotck },
                new Security { Code = "300477", Market = Market.XSHE, ShortName =  "合纵科技", Type = SecurityType.Sotck }
            };
        }

        private ISecurity ExampleSecurity()
        {
            return new Security { Code = "000400", Market = Market.XSHE, ShortName = "许继电气", Type = SecurityType.Sotck };
        }

        private IEnumerable<ISecurity> GetUpdateSecurityDatas(IEnumerable<ISecurity> securities)
        {
            List<ISecurity> example = new List<ISecurity>();
            foreach (Security it in securities)
            {
                it.Type = SecurityType.Unknown;
                example.Add(it);
            }
            return example;
        }

        [TestMethod]
        public void TestMethod_Security()
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, "TestSecurity.sdf");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            
            List<ISecurity> securities = ExampleSecurities();
            System.Diagnostics.Debug.Print(string.Format("Security data count is {0}", securities.Count));

            SecurityRepository repository = new SecurityRepository(filePath);
            repository.AddRange(securities);

            ISecurity get = repository.Get(securities[0].Code);

            Assert.IsTrue(repository.Exists(securities[0]));
            Assert.IsFalse(repository.Exists(ExampleSecurity()));

            var updateData = new Security { Code = "600518", Market = Market.XSHG, ShortName = "康*美*药*业", Type = SecurityType.Unknown };

            repository.UpdateRange(new ISecurity[] { updateData });
            IList<ISecurity> result0 = repository.GetAll().ToList();

            Assert.IsTrue(repository.Exists(updateData));

            List<ISecurity> updateSecurities = GetUpdateSecurityDatas(securities).ToList();
            repository.UpdateRange(updateSecurities);
            
            IList<ISecurity> result = repository.GetAll().ToList();
            
            if (result != null && result.Count > 0)
            {
                System.Diagnostics.Debug.Print(string.Format("Security Data count is {0}", result.Count));
            }
            Assert.AreEqual(securities.Count, result.Count);            
        }

        #endregion

        #region TestMethod_StockBonus

        private StockBonus ExampleStockBonus(DateTime dt)
        {
            return new StockBonus()
            {
                ActualDispatchRate = 0,
                BAndHDividendAfterTax = 0,
                BAndHPreTaxDividend = 0,
                BonusRate = 0,
                CapitalStockBeforeDispatch = 0,
                CapitalSurplusIncreaseRate = 0,
                DispatchPrice = 0,
                DispatchRate = 0,
                DividendAfterTax = 0,
                ExchangeRate = 0,
                IncreaseRate = 0,
                TotalDispatch = 0,
                TransferredAllottedPrice = 0,
                TransferredAllottedRate = 0,
                ShareSplitCount = 0,
                PreTaxDividend = 0,
                ReserveSurplusIncreaseRate = 0,
                Description = "Example Description",
                IssuingObject = "Example IssuingObject",
                Type = BounsType.ProfitSharing,

                CapitalStockBaseDate = new DateTime(2015, 7, 2),
                ConvertibleBondDate = new DateTime(2015, 7, 2),
                DateOfDeclaration = dt,
                DispatchExpiryDate = new DateTime(2015, 7, 2),
                DispatchListingDate = new DateTime(2015, 7, 2),
                ExdividendDate = new DateTime(2015, 7, 2),
                ExpirationDate = new DateTime(2015, 7, 2),
                LastTradingDay = new DateTime(2015, 7, 2),
                RegisterDate = new DateTime(2015, 7, 2),
                ResolutionOfShareholdersMeetingDate = new DateTime(2015, 7, 2),
                StartOrArriveDate = new DateTime(2015, 7, 2),
            };
        }

        [TestMethod]
        public void TestMethod_StockBonus()
        {
            StockBonus example = ExampleStockBonus(new DateTime(2015, 7, 2));
            StockBonus noEists = ExampleStockBonus(new DateTime(2015, 8, 2));

            string filePath = Path.Combine(Environment.CurrentDirectory, "TestStockBonus.sdf");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            StockBonusRepository repository = new StockBonusRepository(filePath);
            repository.AddRange(new IStockBonus[] { example });

            Assert.IsTrue(repository.Exists(example));
            Assert.IsFalse(repository.Exists(noEists));
            IStockBonus get = repository.Get(example.DateOfDeclaration.ToString("yyyy-MM-dd HH:mm:ss"));

            StockBonus updateData = example;
            updateData.Description = "Update Example";
            repository.UpdateRange(new IStockBonus[] { updateData });
            Assert.IsTrue(repository.Exists(updateData));

            IList<IStockBonus> result = repository.GetAll().ToList();
            Assert.AreEqual(1, result.Count);
        }

        #endregion

        #region TestMethod_Participation

        private Participation ExampleParticipation_600036(DateTime day)
        {
            return new Participation
            {
                CostPrice1Day = 16.37,
                CostPrice20Day = 17.62,
                MainForceInflows = -18890.18,
                SuperLargeInflows = -13224.41,
                Time = day,
                Value = 37.97
            };
        }

        private Participation ExampleParticipation_600518(DateTime day)
        {
            return new Participation
            {
                CostPrice1Day = 14.09,
                CostPrice20Day = 16.67,
                MainForceInflows = -11838.97,
                SuperLargeInflows = -4277.92,
                Time = day,
                Value = 34.32
            };
        }

        [TestMethod]
        public void TestMethod_Participation()
        {
            Participation example_600036 = ExampleParticipation_600036(new DateTime(2016, 1, 1));
            Participation example_600518 = ExampleParticipation_600518(new DateTime(2016, 1, 1));

            string filePath = Path.Combine(Environment.CurrentDirectory, "TestParticipation.sdf");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            ParticipationRepository repository = new ParticipationRepository(filePath);
            repository.AddRange(new IParticipation[] { example_600036 });

            Assert.IsTrue(repository.Exists(example_600036));
            Assert.IsFalse(repository.Exists(ExampleParticipation_600036(new DateTime(2016, 2, 1))));
            IParticipation get = repository.Get(example_600036.Time.ToString("yyyy-MM-dd HH:mm:ss"));

            Participation updateData = example_600518;
            repository.UpdateRange(new IParticipation[] { updateData });
            Assert.IsTrue(repository.Exists(updateData));

            updateData.CostPrice1Day = 100.00;
            repository.UpdateRange(new IParticipation[] { updateData });

            updateData.CostPrice20Day = 200.00;
            repository.UpdateRange(new IParticipation[] { updateData });

            IList<IParticipation> result = repository.GetAll().ToList();
            Assert.AreEqual(1, result.Count);
        }

        #endregion

        #region TestMethod_StockProfile

        private StockProfile ExampleStockProfile()
        {
            return new StockProfile()
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
        }

        [TestMethod]
        public void TestMethod_StockProfile()
        {
            StockProfile example = ExampleStockProfile();
            string filePath = Path.Combine(Environment.CurrentDirectory, "TestStockProfile.sdf");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            StockProfileRepository repository = new StockProfileRepository(filePath);
            repository.AddRange(new IStockProfile[] { example });

            Assert.IsTrue(repository.Exists(example));
            IStockProfile get = repository.Get(example.CodeA);

            StockProfile updateData = example;
            updateData.ShortNameA = "招商银行_UpdateTest";

            repository.UpdateRange(new IStockProfile[] { updateData });
            Assert.IsTrue(repository.Exists(updateData));
            
            IList<IStockProfile> result = repository.GetAll().ToList();
            Assert.AreEqual(1, result.Count);
        }

        #endregion
        
        #region TestMethod_StockStructure

        //count = 8
        private List<IStockStructure> ExampleStockStructure_600036()
        {
            List<IStockStructure> examples = new List<IStockStructure>();

            examples.Add(new StockStructure
            {
                DateOfChange = new DateTime(2013, 10, 2),
                DateOfDeclaration = new DateTime(2013, 9, 27),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 2062894.443,
                SharesB = 0,
                SharesH = 459090.117,
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 2521984.56,
                TransferredAllottedShares = 0
            });

            examples.Add(new StockStructure
            {                
                DateOfChange = new DateTime(2013, 9, 11),
                DateOfDeclaration = new DateTime(2013, 9, 9),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,                
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 2062894.443,
                SharesB = 0,
                SharesH = 391047.8,                
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 2453942.243,
                TransferredAllottedShares = 0
            });

            examples.Add(new StockStructure
            {                
                DateOfChange = new DateTime(2010, 4, 9),
                DateOfDeclaration = new DateTime(2010, 4, 8),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,                
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 1766613.089,
                SharesB = 0,
                SharesH = 391047.8,                
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 2157660.889,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructure
            {                
                DateOfChange = new DateTime(2010, 3, 19),
                DateOfDeclaration = new DateTime(2010, 3, 17),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,                
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 1766613.089,
                SharesB = 0,
                SharesH = 346060,                
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 2112673.089,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructure
            {                
                DateOfChange = new DateTime(2009, 11, 10),
                DateOfDeclaration = new DateTime(2009, 11, 12),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,                
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 1565889.002,
                SharesB = 0,
                SharesH = 346060,                
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 1911949.002,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructure
            {                
                DateOfChange = new DateTime(2009, 10, 30),
                DateOfDeclaration = new DateTime(2009, 11, 5),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,                
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 1565883.598,
                SharesB = 0,
                SharesH = 346060,                
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 1911943.598,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructure
            {                
                DateOfChange = new DateTime(2009, 9, 30),
                DateOfDeclaration = new DateTime(2009, 10, 10),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,                
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 1565881.043,
                SharesB = 0,
                SharesH = 346060,                
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 1911941.043,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructure
            {                
                DateOfChange = new DateTime(2009, 9, 29),
                DateOfDeclaration = new DateTime(2009, 10, 10),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,                
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 1565880.975,
                SharesB = 0,
                SharesH = 346060,                
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 1911940.975,
                TransferredAllottedShares = 0,
            });

            return examples;
        }
        //count = 18
        private List<IStockStructure> ExampleStockStructure_600518()
        {
            List<IStockStructure> examples = new List<IStockStructure>();
            examples.Add(new StockStructure
            {
                
                DateOfChange = new DateTime(2015, 6, 17),
                DateOfDeclaration = new DateTime(2015, 6, 10),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 439742.897,
                SharesB = 0,
                SharesH = 0,
                
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 439742.897,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructure
            {
                
                DateOfChange = new DateTime(2014, 12, 30),
                DateOfDeclaration = new DateTime(2014, 12, 25),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 219871.448,
                SharesB = 0,
                SharesH = 0,
                
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 219871.448,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructure
            {
                
                DateOfChange = new DateTime(2011, 1, 12),
                DateOfDeclaration = new DateTime(2011, 1, 10),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 219871.448,
                SharesB = 0,
                SharesH = 0,
                
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 219871.448,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructure
            {
                
                DateOfChange = new DateTime(2009, 5, 25),
                DateOfDeclaration = new DateTime(2009, 5, 26),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 169437.005,
                SharesB = 0,
                SharesH = 0,
                
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 169437.005,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructure
            {
                
                DateOfChange = new DateTime(2009, 4, 23),
                DateOfDeclaration = new DateTime(2009, 4, 16),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 152880,
                SharesB = 0,
                SharesH = 0,
                
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 152880,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructure
            {
                
                DateOfChange = new DateTime(2008, 10, 27),
                DateOfDeclaration = new DateTime(2008, 10, 21),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 76440,
                SharesB = 0,
                SharesH = 0,
                
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 76440,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructure
            {
                
                DateOfChange = new DateTime(2008, 3, 5),
                DateOfDeclaration = new DateTime(2008, 2, 27),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 20660.83,
                RestrictedSharesB = 0,
                SharesA = 55779.17,
                SharesB = 0,
                SharesH = 0,
                
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 76440,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructure
            {
                
                DateOfChange = new DateTime(2007, 10, 25),
                DateOfDeclaration = new DateTime(2007, 10, 19),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 13773.887,
                RestrictedSharesB = 0,
                SharesA = 37186.113,
                SharesB = 0,
                SharesH = 0,
                
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 50960,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructure
            {
                
                DateOfChange = new DateTime(2007, 9, 17),
                DateOfDeclaration = new DateTime(2007, 9, 14),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 15366.887,
                RestrictedSharesB = 0,
                SharesA = 35593.113,
                SharesB = 0,
                SharesH = 0,
                
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 50960,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructure
            {
                
                DateOfChange = new DateTime(2007, 5, 9),
                DateOfDeclaration = new DateTime(2007, 4, 25),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 15366.887,
                RestrictedSharesB = 0,
                SharesA = 28493.113,
                SharesB = 0,
                SharesH = 0,
                
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 43860,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructure
            {
                
                DateOfChange = new DateTime(2006, 10, 25),
                DateOfDeclaration = new DateTime(2006, 10, 20),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 7683.443,
                RestrictedSharesB = 0,
                SharesA = 14246.557,
                SharesB = 0,
                SharesH = 0,
                
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 21930,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructure
            {
                
                DateOfChange = new DateTime(2006, 8, 11),
                DateOfDeclaration = new DateTime(2006, 8, 7),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 10867.5,
                RestrictedSharesB = 0,
                SharesA = 11062.5,
                SharesB = 0,
                SharesH = 0,
                
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 21930,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructure
            {
                
                DateOfChange = new DateTime(2006, 7, 11),
                DateOfDeclaration = new DateTime(2006, 7, 10),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 12917.5,
                RestrictedSharesB = 0,
                SharesA = 9012.5,
                SharesB = 0,
                SharesH = 0,
                
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 21930,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructure
            {
                
                DateOfChange = new DateTime(2006, 5, 19),
                DateOfDeclaration = new DateTime(2006, 5, 12),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 10867.5,
                RestrictedSharesB = 0,
                SharesA = 5062.5,
                SharesB = 0,
                SharesH = 0,
                
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 15930,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructure
            {
                
                DateOfChange = new DateTime(2005, 10, 25),
                DateOfDeclaration = new DateTime(2005, 10, 20),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 7245,
                RestrictedSharesB = 0,
                SharesA = 3375,
                SharesB = 0,
                SharesH = 0,
                
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 10620,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructure
            {
                
                DateOfChange = new DateTime(2004, 5, 21),
                DateOfDeclaration = new DateTime(0001, 1, 1),
                DomesticLegalPersonShares = 7050,
                DomesticSponsorsShares = 7920,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 2700,
                SharesB = 0,
                SharesH = 0,
                
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 10620,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructure
            {
                
                DateOfChange = new DateTime(2001, 3, 19),
                DateOfDeclaration = new DateTime(0001, 1, 1),
                DomesticLegalPersonShares = 4700,
                DomesticSponsorsShares = 5280,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 1800,
                SharesB = 0,
                SharesH = 0,
                
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 7080,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructure
            {
                
                DateOfChange = new DateTime(2001, 2, 26),
                DateOfDeclaration = new DateTime(0001, 1, 1),
                DomesticLegalPersonShares = 4700,
                DomesticSponsorsShares = 5280,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 0,
                SharesB = 0,
                SharesH = 0,
                
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 5280,
                TransferredAllottedShares = 0,
            });

            return examples;
        }

        private IEnumerable<IStockStructure> GetUpdateDatas(IEnumerable<IStockStructure> updateDatas)
        {
            List<IStockStructure> example = new List<IStockStructure>();
            foreach (StockStructure it in updateDatas)
            {
                //it.Reason = "Test Update Data";
                it.DateOfDeclaration = DateTime.MinValue;
                example.Add(it);
            }
            return example;
        }

        [TestMethod]
        public void TestMethod_StockStructure()
        {
            List<IStockStructure> example_600036 = ExampleStockStructure_600036();
            List<IStockStructure> example_600518 = ExampleStockStructure_600518();

            string filePath = Path.Combine(Environment.CurrentDirectory, "TestStockStructure.sdf");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            StockStructureRepository repository = new StockStructureRepository(filePath);
            repository.AddRange(example_600036);

            IStockStructure get = repository.Get(example_600036[0].DateOfChange.ToString("yyyy-MM-dd HH:mm:ss"));

            Assert.IsTrue(repository.Exists(example_600036[0]));
            Assert.IsFalse(repository.Exists(example_600518[0]));

            StockStructure updateData = example_600036[0] as StockStructure;
            updateData.Reason = "TestMethod_StockStructure";

            repository.UpdateRange(new IStockStructure[] { updateData });
            IList<IStockStructure> result0 = repository.GetAll().ToList();

            Assert.IsTrue(repository.Exists(updateData));

            List<IStockStructure> updateDatas = GetUpdateDatas(example_600036).ToList();
            repository.UpdateRange(updateDatas);
            
            IList<IStockStructure> result = repository.GetAll().ToList();            
            Assert.AreEqual(example_600036.Count, result.Count);
        }

        #endregion
    }
}
