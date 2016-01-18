namespace Pitman.Infrastructure.EF.Repository
{
    public enum ContextType
    {
        /// <summary>
        /// K线
        /// </summary>
        KLine,
        /// <summary>
        /// 证券信息
        /// </summary>
        Security,
        /// <summary>
        /// 分红配股
        /// </summary>
        StockBonus,
        /// <summary>
        /// 基本信息
        /// </summary>
        StockProfile,
        /// <summary>
        /// 股本结构
        /// </summary>
        StockStructure,
        /// <summary>
        /// 机构参与度
        /// </summary>
        Participation
    }
}
