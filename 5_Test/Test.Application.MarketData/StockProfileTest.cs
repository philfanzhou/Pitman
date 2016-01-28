using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ore.Infrastructure.MarketData;
using Pitman.Application.MarketData;
using Pitman.Distributed.DataTransferObject;
using Pitman.Domain.FileStructure;
using System;
using System.IO;
using System.Linq;

namespace Test.Application.MarketData
{
    [TestClass]
    public class StockProfileTest
    {
        private StockProfileDto example()
        {
            return new StockProfileDto()
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
        public void TestMethod1()
        {
            string dataFile = DataFiles.GetStockProfileFile();
            if (File.Exists(dataFile))
            {
                File.Delete(dataFile);
            }

            StockProfileDto insertData = example();

            var appService = new StockProfileAppService();

            // 测试插入数据
            appService.Add(insertData);
            Assert.IsTrue(appService.Exists(insertData));

            // 测试更新数据
            insertData.ShortNameA = "*招*商*银*行*";
            appService.Update(insertData);

            insertData.ShortNameB = "测试测试";
            appService.Update(insertData);

            Assert.IsTrue(appService.Exists(insertData));

            // 测试读取数据
            var securities = appService.GetAll().ToList();
            Assert.IsNotNull(securities);
            Assert.IsTrue(securities.Count == 1);
            Assert.AreEqual(insertData.CodeA, securities[0].CodeA);
            Assert.AreEqual(insertData.ShortNameA, securities[0].ShortNameA);
            Assert.AreEqual(insertData.ShortNameB, securities[0].ShortNameB);
        }
    }
}
