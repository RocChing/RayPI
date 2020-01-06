//本地项目包
using RayPI.Infrastructure.Auth.Models;

namespace RayPI.Infrastructure.Auth.Operate
{
    /// <summary>
    /// 操作人信息[interface]
    /// </summary>
    public interface IOperateInfo
    {
        /// <summary>登录token</summary>
        /// <value>The token.</value>
        string TokenStr { get; }

        string Uname { get; }
        long Uid { get; }
    }
}
