
using Context.Interface;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Interface.User;

namespace Repository.User
{
    public class AdressRepository : GenericRepository<Adress>, AdressIRepository
    {
        public AdressRepository(PotShopIDbContext _idbcontext) : base(_idbcontext)
        {
            _table = _idbcontext.Set<Adress>();
        }
        private readonly DbSet<Adress> _table;



        public async Task<IEnumerable<Adress>> GetAdressesByUserId(int userId)
        {
            var user = await _idbcontext.Users
                .Include(u => u.Adresses)
                .FirstOrDefaultAsync(u => u.Id == userId)
                .ConfigureAwait(false);

            return user?.Adresses ?? Enumerable.Empty<Adress>();
        }



    }
}
