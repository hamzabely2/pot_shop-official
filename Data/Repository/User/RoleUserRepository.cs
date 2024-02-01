
using Context.Interface;
using Entity.Model;
using Repository.Interface.User;

namespace Repository.User
{
    public class RoleUserRepository : GenericRepository<RoleUser>, RoleUserIRepository
    {
        public RoleUserRepository(PotShopIDbContext idbcontext) : base(idbcontext)
        {
        }


    }
}
