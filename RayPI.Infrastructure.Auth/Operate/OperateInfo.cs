//微软包
using Microsoft.AspNetCore.Http;
//本地项目包
using RayPI.Infrastructure.Auth.Models;
using RayPI.Infrastructure.Auth.Jwt;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace RayPI.Infrastructure.Auth.Operate
{
    /// <summary>
    /// 操作人信息
    /// </summary>
    public class OperateInfo : IOperateInfo
    {
        private readonly HttpContext _httpContext;

        private readonly IJwtService _jwtService;

        public OperateInfo(IHttpContextAccessor httpContextAccessor, IJwtService jwtService)
        {
            _httpContext = httpContextAccessor.HttpContext;
            _jwtService = jwtService;
        }

        /// <summary>
        /// 令牌字符串
        /// </summary>
        public string TokenStr => _httpContext.Request.Headers["Authorization"].ToString();


        private JwtSecurityToken jwtSecurityToken => _jwtService.GetJwtSecurityToken(TokenStr);

        public string Uname => jwtSecurityToken?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value ?? "";
        public long Uid => long.TryParse(jwtSecurityToken?.Subject, out long uid) ? uid : -1L;
    }
}
