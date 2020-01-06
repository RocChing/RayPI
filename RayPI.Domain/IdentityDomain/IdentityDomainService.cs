using System;
using System.Collections.Generic;
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

        public IdentityDomainService(IUserAccountRepository userAccountRepository,
            IRoleRepository roleRepository,
            IUserRoleRelateRepository userRoleRelateRepository)
        {
            _userAccountRepository = userAccountRepository;
            _roleRepository = roleRepository;
            _userRoleRelateRepository = userRoleRelateRepository;
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
    }
}
