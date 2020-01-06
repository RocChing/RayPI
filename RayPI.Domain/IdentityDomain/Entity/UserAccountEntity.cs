using System;
using RayPI.Domain.Entity;

namespace RayPI.Domain.IdentityDomain.Entity
{
    public class UserAccountEntity : EntityBase
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string PwdHash { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 生效时间
        /// </summary>
        public DateTime EffectiveTime { get; set; }

        /// <summary>
        /// 到期时间
        /// </summary>
        public DateTime ExpiredTime { get; set; }

        /// <summary>
        /// 是否禁用 true=是，false=否
        /// </summary>
        public bool IsDisable { get; set; }

    }
}
