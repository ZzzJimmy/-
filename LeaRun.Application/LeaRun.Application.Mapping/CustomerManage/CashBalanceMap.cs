using LeaRun.Application.Entity.CustomerManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CustomerManage
{
    /// <summary>
    /// 版 本
    /// Admin Studio
    /// 创 建：Admin
    /// 日 期：2016-04-28 16:48
    /// 描 述：现金余额
    /// </summary>
    public class CashBalanceMap : EntityTypeConfiguration<CashBalanceEntity>
    {
        public CashBalanceMap()
        {
            #region 表、主键
            //表
            this.ToTable("Client_CashBalance");
            //主键
            this.HasKey(t => t.CashBalanceId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
