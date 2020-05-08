﻿using LeaRun.Application.Entity.PerfGoal;
using LeaRun.Application.IService.PerfScheme;
using LeaRun.Data;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Service.PerfScheme
{
    /// <summary>
    /// 部门绩效方案设置
    /// </summary>
    public class PerfDeptSchemedataService : RepositoryFactory, IPerfDeptSchemedataService
    {
        /// <summary>
        /// 获取部门绩效方案编码列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<BpePA003Entity> GetBmList(string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT [JGFABH]
                                  ,[JGFAMC]
                            FROM [HQPAS].[BPMS].[BPE_PA003] C
                            LEFT JOIN [HQPAS].[BPMS].[BPE_PA001] P ON C.[FABH] = P.[FABH]
                            WHERE P.[STATUS] = '1' ");
            //绩效年度
            if (!queryParam["jxbm"].IsEmpty())
            {
                strSql.Append(" AND C.[JXBM] = @JXBM ");
                parameter.Add(DbParameters.CreateDbParameter("@JXBM", queryParam["jxbm"].ToString()));
            }
            strSql.Append(" ORDER BY P.[SYND] DESC,[JGFABH] ");
            return this.HQPASRepository().FindList<BpePA003Entity>(strSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// 获取部门绩效方案年度服务状态
        /// </summary>
        /// <param name="jgfabh">部门绩效方案编号</param>
        /// <returns>部门绩效方案年度服务状态</returns>
        public string GetPertFwzt(string jgfabh)
        {
            string fwzt = null;

            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT Y.[FWZT]
                            FROM [HQPAS].[BPMS].[BPE_PA003] P
                            LEFT JOIN [HQPAS].[BPMS].[BPE_SC001] Y ON P.[JXBM] = Y.[JXBM]
                            WHERE [JGFABH] = @JGFABH");
            parameter.Add(DbParameters.CreateDbParameter("@JGFABH", jgfabh));
            var sqlResult = this.HQPASRepository().FindObject(strSql.ToString(), parameter.ToArray());
            if (sqlResult != null)
            {
                fwzt = sqlResult.ToString();
            }

            return fwzt;
        }
    }
}