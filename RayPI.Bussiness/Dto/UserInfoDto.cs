using System;
using System.Collections.Generic;
using System.Text;
using RayPI.Infrastructure.Auth;

namespace RayPI.Business.Dto
{
    public class UserInfoDto
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        public List<RoleDto> RoleDtos { get; set; }
    }

    public class RoleDto
    {
        /// <summary>
        /// 角色编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>
        public string Name { get; set; }

        public List<Permission> Permissions { get; set; }
    }
}
