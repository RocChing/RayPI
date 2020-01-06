using System;
using System.Collections.Generic;
using System.Text;
using RayPI.Business.Dto;
using RayPI.Domain.IdentityDomain;
using RayPI.Domain.IdentityDomain.Entity;
using RayPI.Domain.IdentityDomain.IRepository;

namespace RayPI.Business.Business
{
    public class IdentityAppService
    {
        private readonly IIdentityDomainService _identityDomainService;
        private readonly IUserAccountRepository _userAccountRepository;

        public IdentityAppService(IIdentityDomainService identityDomainService,
            IUserAccountRepository userAccountRepository)
        {
            _identityDomainService = identityDomainService;
            _userAccountRepository = userAccountRepository;
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
            var user = _userAccountRepository.Find(x => x.UserId == uid);

            var roles = new List<RoleDto>();
            return new UserInfoDto
            {
                UserId = uid,
                UserName = user.UserName,
                RoleDtos = roles
            };
        }
    }
}
