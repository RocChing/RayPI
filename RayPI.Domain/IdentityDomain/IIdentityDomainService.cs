using System;
using System.Collections.Generic;
using System.Text;
using RayPI.Domain.IdentityDomain.Entity;

namespace RayPI.Domain.IdentityDomain
{
    public interface IIdentityDomainService
    {
        void Register(UserAccountEntity userAccountEntity);
    }
}
