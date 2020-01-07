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
            return _userAccountRepository.Find(x => x.UserName == userName && x.PwdHash == pwdHash)?.Id ?? 0;
        }

        public List<RoleEntity> GetRolesByUid(long id)
        {
            var userRoles = _userRoleRelateRepository.GetAllMatching(x => x.UserId == id);
            var roleIds = userRoles.Select(x => x.RoleId);
            var roles = _roleRepository.GetAllMatching(x => roleIds.Contains(x.Id));
            return roles.ToList();
        }

        public void SetPermissions(long roleId, List<string> permissionCodes)
        {
            string roleCode = _roleRepository.FindById(roleId).Code;
            var p = permissionCodes.Select(x => new RolePermissionRelateEntity
            {
                RoleCode = roleCode,
                PermissionCode = x
            });
            _rolePermissionRelateRepository.Add(p);
        }

        public List<string> GetPermissionsByRoleCodes(string[] roleCodes)
        {
            var rolePermissions = _rolePermissionRelateRepository.GetAllMatching(x => roleCodes.Contains(x.RoleCode));
            return rolePermissions.Select(x => x.PermissionCode).ToList();
        }

        public void DeleteUser(long uid)
        {
            //todo:需要添加事务
            _userAccountRepository.Delete(uid);
            _userRoleRelateRepository.Delete(x => x.UserId == uid);
        }
    }
}
