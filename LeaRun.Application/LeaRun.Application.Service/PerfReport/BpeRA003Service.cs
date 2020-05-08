using LeaRun.Application.Entity.PerfReport;
using LeaRun.Application.IService.PerfReport;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Service.PerfReport
{
    /// <summary>
    /// 综合评价等级报告
    /// </summary>
    public class BpeRA003Service : RepositoryFactory<BpeRA003Entity>, IBpeRA003Service
    {
        #region 获取数据

        /// <summary>
        /// 综合评价等级报告列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<BpeRA003Entity> GetList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<BpeRA003Entity>();
            var queryParam = queryJson.ToJObject();
            //绩效年度编码
            if (!queryParam["jxbm"].IsEmpty())
            {
                string keyword = queryParam["jxbm"].ToString();

                expression = expression.And(t => t.JXBM == keyword);
            }
            //科室编码
            if (!queryParam["deptcode"].IsEmpty())
            {
                string keyword = queryParam["deptcode"].ToString();

                expression = expression.And(t => t.JGBM == keyword);
            }
            expression = expression.And(t => t.STATUS == "1");

            return this.HQPASRepository().FindList(expression, pagination);
        }

        /// <summary>
        /// 综合评价等级报告实体
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <returns></returns>
        public BpeRA003Entity GetEntity(string keyvalue)
        {
            return this.HQPASRepository().FindEntity(keyvalue);
        }

        #endregion

        #region 提交数据
        /// <summary>
        /// 删除综合评价等级报告
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        public void RemoveForm(string keyvalue)
        {
            this.HQPASRepository().Delete(keyvalue);
        }
        /// <summary>
        /// 保存综合评价等级报告表单（新增、修改）
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <param name="entity">综合评价等级报告实体</param>
        /// <returns></returns>
        public void SaveForm(string keyvalue, BpeRA003Entity entity)
        {
            if (!string.IsNullOrEmpty(keyvalue))
            {
                entity.Modify(keyvalue);
                this.HQPASRepository().Update(entity);
            }
            else
            {
                entity.Create();
                this.HQPASRepository().Insert(entity);
            }
        }
        #endregion
    }
}