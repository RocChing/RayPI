using RayPI.Domain.IdentityDomain.Entity;
using RayPI.Domain.IRepository;
using RayPI.Repository.EFRepository;
using RayPI.Repository.EFRepository.Repository;

namespace RayPI.Domain.IdentityDomain.IRepository
{
    public class UserRoleRelateRepository : BaseRepository<UserRoleRelateEntity>, IUserRoleRelateRepository
    {
        public UserRoleRelateRepository(RayDbContext myDbContext) : base(myDbContext)
        {
        }
    }
}
