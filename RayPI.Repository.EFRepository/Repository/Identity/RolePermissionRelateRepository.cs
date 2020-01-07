using System;
using System.Collections.Generic;
using System.Text;
using RayPI.Domain.IdentityDomain.Entity;
using RayPI.Domain.IdentityDomain.IRepository;

namespace RayPI.Repository.EFRepository.Repository.Identity
{
    public class RolePermissionRelateRepository : BaseRepository<RolePermissionRelateEntity>, IRolePermissionRelateRepository
    {
        public RolePermissionRelateRepository(RayDbContext myDbContext) : base(myDbContext)
        {
        }
    }
}
