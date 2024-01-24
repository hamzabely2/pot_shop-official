
using Context.Interface;
using Entity.Model;
using Repository.Interface;

namespace Repository
{
    public class RoleUserRepository : GenericRepository<RoleUser>, RoleUserIRepository
    {
        public RoleUserRepository(PotShopIDbContext idbcontext) : base(idbcontext)
        {
        }


    }
}
