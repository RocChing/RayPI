using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RayPI.Business.Business;
using RayPI.Business.Dto;
using RayPI.Domain.IdentityDomain;
using RayPI.Infrastructure.Auth;
using RayPI.Infrastructure.Auth.Jwt;
using RayPI.Infrastructure.Config;
using RayPI.Infrastructure.Security.Models;
using RayPI.Infrastructure.Security.Services;

namespace RayPI.OpenApi.Controllers
{
    /// <summary>
    /// 账号接口
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IdentityAppService _identityAppService;
        private readonly IIdentityDomainService _identityDomainService;
        private readonly IAuthService _authService;


        public AccountController(IdentityAppService identityAppService,
            IIdentityDomainService identityDomainService,
            IAuthService authService)
        {
            _identityAppService = identityAppService;
            _identityDomainService = identityDomainService;
            _authService = authService;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="request"></param>
        [HttpPost]
        public bool Register(RegisterDto request)
        {
            _identityAppService.Register(request);
            return true;
        }

        /// <summary>
        /// 登录获取token
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="pwd"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Token")]
        public JsonResult Login(string userName = "admin", string pwd = "123456")
        {
            long uid = _identityDomainService.Login(userName, pwd);

            List<string> roleList = _identityDomainService.GetRolesByUid(uid);
            string tokenStr = _authService.GetToken(userName, roleList);

            return new JsonResult(tokenStr);
        }

        public bool SetPermissions(long roleId, List<Permission> permissions)
        {
            List<string> permissionCodes = permissions.Select(x => $"{x.ResourceCode}_{x.OperateCode}").ToList();
            _identityDomainService.SetPermissions(roleId, permissionCodes);
            return true;
        }

        public UserInfoDto GetUserInfo(long uid)
        {

        }
    }
}