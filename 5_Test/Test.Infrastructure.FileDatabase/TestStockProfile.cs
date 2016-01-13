using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ore.Infrastructure.MarketData;
using Pitman.Infrastructure.FileDatabase;

namespace Test.Infrastructure.FileDatabase
{
    [TestClass]
    public class TestStockProfile
    {
        private IStockProfile ExampleStockProfile_600036()
        {
            return new StockProfileDataItem
            {
                AccountingFirm = "毕马威华振会计师事务所...",//"毕马威华振会计师事务所,毕马威会计师事务所",
                Area = "广东",
                BoardSecretary = "许世清",
                BusinessRegistration = "440301104433862",
                Chairman = "李建红",
                CodeA = "600036",
                CodeB = "--",
                CodeH = "03968",
                CompanyProfile = "本行系依据人民银于...",//"    本行系依据人民银于 1986 年 8月 11 日、 1987 年 3月 7日分别下发的《关于同意 试办招商银行的批复 》([1986]175号),并于 1987 年 3月 31 日在原深圳市蛇口工商局注册登记的综合性银 行,设立时 的注册资本为 1亿元。\n根据蛇口中华会计师事务所 1988 年 10 月 24 日出具的《验资报告书》(字 (1988 )第 50 号),截至 1988 年 10 月 22 日,本行实收注册资为港币 52,642,661.61 元 ,美14,784,944.08 元。\n根据人民银行于 1989 年 1月 17 日下发的《关于同意招商银行增资扩股等问题批 复》(( [1989]12 号),本行于 1989 年进行了增资扩股。\n根据蛇口中华会计师事务所于 1991 年 7月 23 日出具的《验资报告》(内字 (1991 )第 29 号),截至 1991 年 5月 30 日,本行的实收 注册资本为 4亿元。\n1989 年 1月 19 日,本行获得原深圳市蛇口工商局颁发更新的《企业法人营执照》 (注册号:蛇企字 0025 号),注册资本为 号),注册资本为 4亿元。\n\n根据原深圳市经济体制改革办公室于 1993 年 6月 26 日下发的《关于同意招商银行 进行内部股份改组的批复 》(深[1993]73 号),原深圳市证券管理办公室于 1994 年 4月 4日下发的《关于同意招商银行改组为股份有限(内部)公司批复》( 1994 )90 号)、于 1994 年 5月 25 日下发的《关于同意招商银行 调整新增股份数量和权结构的批复 》(深证办(1994 )132 号)和《关于同意招商银行股份有 限公司章程的批复》( 深证办1994 )133 号),本行获准改制为股份有限公司。\n1994 年 5月 10 日,深圳中洲会计师事务所出具《验资报告》( 1994 验字 第 413 号),验证了本行改制并增资扩股后的实收为 1,122,727,212 元。\n1994 年 9月 5日,本行取得国家工商总局换发的《企业法人营执照》(注册号: 10001686 -X),注册资本为 1,122,730,000",
                ContactNumber = "0755-83198888",
                Email = "cmb@cmbchina.com",
                EnglishName = "China Merchants Bank Co., Ltd.",
                EstablishmentDate = new DateTime(1987, 3, 31),
                Exchange = Market.XSHG,
                Fax = "0755-83195109",
                FullName = "招商银行股份有限公司",
                GeneralManager = "田惠宇",
                IndependentDirectors = "马泽华,黄桂林...",//"马泽华,黄桂林,潘承伟,潘英丽,梁锦松,赵军",
                Industry = "银行",
                LawOffice = "君合(深圳)律师事务所...",//"君合(深圳)律师事务所,史密夫律师事务所",
                LegalRepresentative = "李建红",
                ListDate = new DateTime(2002, 4, 9),
                NameUsedBefore = "招商银行->G招行",
                NumberOfEmployees = 75109,
                NumberOfManagement = 38,
                OfficeAddress = "中国广东省深圳市...",//"中国广东省深圳市福田区深南大道7088号",
                PrimeBusiness = "吸收公众存款；...",//"吸收公众存款；发放短期、中期和长期贷款；办理结算；办理票据贴现；发行金融债券；代理发行、代理兑付、承销政府债券；买卖政府债券；同业拆借；提供信用证服务及担保；代理收付款项及代理保险业务；提供保管箱服务。外汇存款；外汇贷款；外汇汇款；外币兑换；国际结算；结汇、售汇；同业外汇拆借；外汇票据的承兑和贴现；外汇借款；外汇担保；买卖和代理买卖股票以外的外币有价证券；发行和代理发行股票以外的外币有价证券；自营和代客外汇买卖；资信调查、咨询、见证业务；离岸金融业务。经中国银监会批准的其他业务。公司在商业银行中处于领先地位，已跻身世界银行150强，被英国《银行家》杂志评为中国最有竞争力的银行。在全国30多个经济中心城市设立了470多家机构，其中设立在长三角、珠三角、环渤海三大区域的网点占全部网点的62％。",
                RegisteredAddress = "中国广东省深圳...",//"中国广东省深圳市福田区深南大道7088号",
                RegisteredCapital = "252亿",
                SecuritiesAffairsRepresentatives = "吴涧兵",
                ShortNameA = "招商银行",
                ShortNameB = "--",
                ShortNameH = "招商银行",
                Website = "www.cmbchina.com",
                ZipCode = "518040"
            };
        }

        private IStockProfile ExampleStockProfile_600518()
        {
            return new StockProfileDataItem
            {
                AccountingFirm = "广东正中珠江会计...",//"广东正中珠江会计师事务所(特殊普通合伙)",
                Area = "广东",
                BoardSecretary = "邱锡伟",
                BusinessRegistration = "440000000006711",
                Chairman = "马兴田",
                CodeA = "600518",
                CodeB = "--",
                CodeH = "--",
                CompanyProfile = "公司原名广东康美药...",//"    公司原名广东康美药业股份有限公司,于1997年6月9日经广东省人民政府粤办函[1997]346号文、广东省经济体制改革委员会粤体改[1997]077文批准,由普宁市康美实业有限公司、普宁市国际信息咨询服务有限公司、普宁市金信典当行有限公司3家法人企业和许燕君、许冬瑾2位自然人共同发起设立,并于1997年6月18日在广东省工商行政管理局取得《企业法人营业执照》;2001年2月6日公司采用上网定价方式成功发行境内上市人民币普通股(A股)股票,并在上海证券交易所上市交易。",
                ContactNumber = "0755-33187777-8009",
                Email = "kangmei@kangmei.com.cn",
                EnglishName = "Kangmei Pharmaceutical Co.,Ltd",
                EstablishmentDate = new DateTime(1997, 6, 18),
                Exchange = Market.XSHG,
                Fax = "0755-86275777",
                FullName = "康美药业股份有限公司",
                GeneralManager = "马兴田",
                IndependentDirectors = "李定安,张弘,江镇平",
                Industry = "医药行业",
                LawOffice = "国浩律师(广州)事务所",
                LegalRepresentative = "马兴田",
                ListDate = new DateTime(2001, 3, 19),
                NameUsedBefore = "康美药业->G康美",
                NumberOfEmployees = 7061,
                NumberOfManagement = 18,
                OfficeAddress = "广东省深圳市福田区下梅林泰科路",
                PrimeBusiness = "生产：中药饮片...",//"生产：中药饮片（净制、切制、醋制、酒制、盐制、炒、煅、蒸、煮、炖、燀、制炭、炙制、制霜、水飞，含毒性饮片，直接口服饮片），颗粒剂，片剂、硬胶囊剂（均含头孢菌素、青霉素类），原料药（甲磺酸多沙唑嗪、盐酸丙哌维林、泛酸钙、吉法酯、盐酸坦洛新、雷贝拉唑钠）含茶制品和代用茶（代用茶）、其他食品（汤料）；批发：中药材、中药饮片、中成药、化学原料药、化学药制剂、抗生素原料药、抗生素制剂、生化药品、生物制品（含体外诊断试剂、除疫苗）、第二类精神药品（制剂）、医疗用毒性药品（西药）、蛋白同化制剂、肽类激素、麻醉药品和第一类精神药品（区域性批发）；保健食品生产、销售（片剂（含片）、茶剂）；批发兼零售：预包装食品、散装食品（干果，坚果，烘培食品，糖果蜜饯，罐头，烹调佐料，腌制品，酒精饮料，非酒精饮料）（以上各项具体按本公司有效许可证经营）；销售：电子产品，五金、交电，金属材料（不含金、银），建筑材料，百货，工艺美术品（不含金、银饰品），针、纺织品、化妆品；食品销售管理；房地产投资，猪、鱼、鸡、鹅、鸭饲养，水果种植；自营和代理除国家组织统一联合经营的16种出口商品和国家实行核定、准予公司经营的14种进口商品以外的其他商品及技术的进出口（按省外经贸委粤外经贸进字[97]339号文经营）；医疗器械（凭有效医疗器械经营企业许可证经营），医疗用毒性药品（中药材）；信息服务业务（仅限互联网信息服务业务，按经营许可证许可项目经营）；在经核准的区域内直销经核准的产品（具体区域和产品以商务部直销行业管理网站公布的为准）、普通货运、商务信息咨询服务；会议展览服务；仓储服务；自有房产租赁。（依法须经批准的项目，经相关部门批准后方开展经营活动。）公司是国内首批通过中药饮片GMP认证的企业之一，通过近年来的经营扩张，已成为国内中药饮片行业的龙头企业，公司可生产的中药饮片1000多种，常年生产品种达600多种，规模优势较为突出。",
                RegisteredAddress = "广东省普宁市流沙镇长春路中段",
                RegisteredCapital = "44.0亿",
                SecuritiesAffairsRepresentatives = "温少生",
                ShortNameA = "康美药业",
                ShortNameB = "--",
                ShortNameH = "--",
                Website = "www.kangmei.com.cn",
                ZipCode = "518000"
            };
        }

        [TestMethod]
        public void TestMethod1()
        {
            IStockProfile stockProfile_600036 = ExampleStockProfile_600036();//招商银行
            IStockProfile stockProfile_600518 = ExampleStockProfile_600518();//康美药业

            var repository = new StockProfileDataRepository();
            if (!repository.Exists("600036"))
            {
                repository.Add(stockProfile_600036);
            }

            if (!repository.Exists("600518"))
            {
                repository.Add(stockProfile_600518);
            }

            var data_600036 = repository.GetData("600036");
            Assert.IsNotNull(data_600036);
            Assert.IsTrue(data_600036.ShortNameA == "招商银行");

            var data_600518 = repository.GetData("600518");
            Assert.IsNotNull(data_600518);
            Assert.IsTrue(data_600518.ShortNameA == "康美药业");
        }
    }
}
