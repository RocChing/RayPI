using System;
using System.Collections.Generic;
using System.Text;

namespace RayPI.Business.Dto
{
    public class RegisterDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string PwdHash { get; set; }
    }
}
