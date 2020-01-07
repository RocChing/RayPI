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
using RayPI.Infrastructure.Treasury.Models;

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
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Token")]
        public JsonResult Login(string userName = "admin", string pwd = "123456")
        {
            long uid = _identityDomainService.Login(userName, pwd);

            List<string> roleCodeList = _identityDomainService.GetRolesByUid(uid).Select(x => x.Code).ToList();
            string tokenStr = _authService.GetToken(userName, roleCodeList);

            return new JsonResult(tokenStr);
        }

        /// <summary>
        /// 为角色赋权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="permissions"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Permission")]
        public bool SetPermissions(long roleId, List<Permission> permissions)
        {
            List<string> permissionCodes = permissions.Select(x => x.PermissionCode).ToList();
            _identityDomainService.SetPermissions(roleId, permissionCodes);
            return true;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("UserInfos/{uid}")]
        public UserInfoDto GetUserInfo(long uid)
        {
            return _identityAppService.GetUserInfo(uid);
        }

        /// <summary>
        /// 获取用户分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("UserInfos")]
        public PageResult<UserInfoDto> GetPageUserInfos(int pageIndex = 1, int pageSize = 10)
        {
            return _identityAppService.GetPageUserInfos(pageIndex, pageSize);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Users")]
        public bool DeleteUser(long uid)
        {
            _identityDomainService.DeleteUser(uid);
            return true;
        }
    }
}