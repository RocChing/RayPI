using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayPI.Domain.IdentityDomain.Entity;
using RayPI.Domain.IdentityDomain.IRepository;

namespace RayPI.Domain.IdentityDomain
{
    public class IdentityDomainService : IIdentityDomainService
    {
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRelateRepository _userRoleRelateRepository;
        private readonly IRolePermissionRelateRepository _rolePermissionRelateRepository;

        public IdentityDomainService(IUserAccountRepository userAccountRepository,
            IRoleRepository roleRepository,
            IUserRoleRelateRepository userRoleRelateRepository,
            IRolePermissionRelateRepository rolePermissionRelateRepository)
        {
            _userAccountRepository = userAccountRepository;
            _roleRepository = roleRepository;
            _userRoleRelateRepository = userRoleRelateRepository;
            _rolePermissionRelateRepository = rolePermissionRelateRepository;
        }

        public void Register(UserAccountEntity userAccountEntity)
        {
            long userId = _userAccountRepository.Add(userAccountEntity);
            var roleEntity = new RoleEntity
            {
                IsAdminRole = false,
                Code = "register_role",
                Name = "注册用户"
            };
            long roleId = _roleRepository.Add(roleEntity);

            var userRoleRelateEntity = new UserRoleRelateEntity
            {
                UserId = userId,
                RoleId = roleId
            };
            _userRoleRelateRepository.Add(userRoleRelateEntity);
        }

        public long Login(string userName, string pwdHash)
        {
            return _userAccountRepository.Find(x => x.UserName == userName && x.PwdHash == pwdHash)?.UserId ?? 0;
        }

        public List<string> GetRolesByUid(long id)
        {
            var userRoles = _userRoleRelateRepository.GetAllMatching(x => x.UserId == id);
            var roleIds = userRoles.Select(x => x.RoleId);
            var roles = _roleRepository.GetAllMatching(x => roleIds.Contains(x.Id));
            return roles.Select(x => x.Code).ToList();
        }

        public void SetPermissions(long roleId, List<string> permissionCodes)
        {
            var p = permissionCodes.Select(x => new RolePermissionRelateEntity
            {
                RoleId = roleId,
                PermissionCode = x
            });
            _rolePermissionRelateRepository.Add(p);
        }
    }
}
