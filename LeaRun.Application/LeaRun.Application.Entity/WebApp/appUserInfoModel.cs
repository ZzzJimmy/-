﻿namespace LeaRun.Application.Entity.WebApp
{
    /// <summary>
    /// 版 本
    /// Admin Studio
    /// 创建人：Admin
    /// 日 期：2016.06.07 10:58
    /// 描 述：用户管理（手机端接口使用）
    /// </summary>
    public class appUserInfoModel
    {
        #region 实体成员
        /// <summary>
        /// 用户主键
        /// </summary>		
        public string UserId { get; set; }
        /// <summary>
        /// 登录账户
        /// </summary>		
        public string Account { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>		
        public string RealName { get; set; }
        /// <summary>
        /// 机构主键
        /// </summary>		
        public string OrganizeId { get; set; }
        /// <summary>
        /// 部门主键
        /// </summary>		
        public string DepartmentId { get; set; }
        #endregion
    }
}
