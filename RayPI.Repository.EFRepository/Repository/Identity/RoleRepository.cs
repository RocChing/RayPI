using RayPI.Domain.IdentityDomain.Entity;
using RayPI.Domain.IRepository;
using RayPI.Repository.EFRepository;
using RayPI.Repository.EFRepository.Repository;

namespace RayPI.Domain.IdentityDomain.IRepository
{
    public class RoleRepository: BaseRepository<RoleEntity>,IRoleRepository
    {
        public RoleRepository(RayDbContext myDbContext) : base(myDbContext)
        {
        }
    }
}
