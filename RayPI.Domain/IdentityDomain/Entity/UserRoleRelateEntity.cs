using RayPI.Domain.Entity;

namespace RayPI.Domain.IdentityDomain.Entity
{
    public class UserRoleRelateEntity : EntityBase
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public long RoleId { get; set; }
	}
}
