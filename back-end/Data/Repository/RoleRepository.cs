
using Context.Interface;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository
{
    public class RoleRepository : GenericRepository<Role>, RoleIRepository
    {
        private readonly DbSet<Role> _table;
        public RoleRepository(PotShopIDbContext idbcontext) : base(idbcontext)
        {
            _table = _idbcontext.Set<Role>();
        }

        public async Task<Role> GetRoleOfAUser(RoleUser roleUser)
        {
            Role role = _table.FirstOrDefault(r => r.Id == roleUser.RoleId);
            return role;
        }

        public async Task<List<Role>> GetRole(int userId)
        {
            return _idbcontext.Users
           .Where(u => u.Id == userId)
           .SelectMany(u => u.Roles_Users.Select(ru => ru.Roles))
           .ToList();
        }
    }
}
