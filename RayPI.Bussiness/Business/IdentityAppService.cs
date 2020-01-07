using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayPI.Business.Dto;
using RayPI.Domain.IdentityDomain;
using RayPI.Domain.IdentityDomain.Entity;
using RayPI.Domain.IdentityDomain.IRepository;
using RayPI.Infrastructure.Treasury.Models;

namespace RayPI.Business.Business
{
    public class IdentityAppService
    {
        private readonly IIdentityDomainService _identityDomainService;
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IRoleRepository _roleRepository;

        public IdentityAppService(IIdentityDomainService identityDomainService,
            IUserAccountRepository userAccountRepository,
            IRoleRepository roleRepository)
        {
            _identityDomainService = identityDomainService;
            _userAccountRepository = userAccountRepository;
            _roleRepository = roleRepository;
        }

        public void Register(RegisterDto request)
        {
            var userAccountEntity = new UserAccountEntity
            {
                UserName = request.UserName,
                PwdHash = request.PwdHash
            };
            _identityDomainService.Register(userAccountEntity);
        }

        public void LogIn()
        {

        }

        public void LogOut()
        {

        }

        public UserInfoDto GetUserInfo(long uid)
        {
            var user = _userAccountRepository.Find(x => x.Id == uid);
            var roles = _identityDomainService.GetRolesByUid(uid);
            var permissionCodes = _identityDomainService.GetPermissionsByRoleCodes(roles.Select(x => x.Code).ToArray());
            var roleDtos = roles.Select(x => new RoleDto
            {
                RoleId = x.Id,
                Code = x.Code,
                Name = x.Name,
                Permissions = permissionCodes.Select(p =>
                {
                    var strs = p.Split('_');
                    string res = strs[0];
                    string op = strs[1];
                    return new Infrastructure.Auth.Permission(op, res);
                }).ToList()
            });
            return new UserInfoDto
            {
                UserId = uid,
                UserName = user.UserName,
                RoleDtos = roleDtos.ToList()
            };
        }

        public PageResult<UserInfoDto> GetPageUserInfos(int pageIndex, int pageSize)
        {
            var pageUsers = _userAccountRepository.GetPageList<UserAccountEntity>(pageIndex, pageSize);
            var re = new PageResult<UserInfoDto>
            {
                PageIndex = pageUsers.PageIndex,
                PageSize = pageUsers.PageSize,
                TotalCount = pageUsers.TotalCount,
                TotalPages = pageUsers.TotalPages
            };
            List<long> ids = pageUsers.List.Select(x => x.Id).ToList();
            List<UserInfoDto> list = new List<UserInfoDto>();
            foreach (var id in ids)
            {
                list.Add(GetUserInfo(id));
            }
            re.List = list;
            return re;
        }

        public PageResult<RoleDto> GetPageRoles(int pageIndex, int pageSize)
        {
            var page = _roleRepository.GetPageList<RoleEntity>(pageIndex, pageSize);
            var re = new PageResult<RoleDto>
            {
                PageIndex = page.PageIndex,
                PageSize = page.PageSize,
                TotalCount = page.TotalCount,
                TotalPages = page.TotalPages,
                List = page.List.Select(x => new RoleDto
                {
                    Code = x.Code,
                    Name = x.Name,
                    RoleId = x.Id
                }).ToList()
            };
            return re;
        }
    }
}
