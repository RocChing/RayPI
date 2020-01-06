using RayPI.Domain.Entity;

namespace RayPI.Domain.IdentityDomain.Entity
{
    public class RoleEntity : EntityBase
    {
        /// <summary>
        /// 角色编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否为后台角色
        /// </summary>
        public bool IsAdminRole { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
	}
}
