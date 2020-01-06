using System;
using System.Collections.Generic;
using System.Text;
using RayPI.Business.Dto;
using RayPI.Domain.IdentityDomain;
using RayPI.Domain.IdentityDomain.Entity;

namespace RayPI.Business.Business
{
    public class IdentityAppService
    {
        private readonly IIdentityDomainService _identityDomainService;

        public IdentityAppService(IIdentityDomainService identityDomainService)
        {
            _identityDomainService = identityDomainService;
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
    }
}
