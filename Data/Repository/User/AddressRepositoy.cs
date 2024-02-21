
using Context.Interface;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Interface.User;

namespace Repository.User
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(PotShopIDbContext _idbcontext) : base(_idbcontext)
        {
            _table = _idbcontext.Set<Address>();
        }
        private readonly DbSet<Address> _table;



        public async Task<IEnumerable<Address>> GetAddressesByUserId(int userId)
        {
            var user = await _idbcontext.Users
                .Include(u => u.Addresses)
                .FirstOrDefaultAsync(u => u.Id == userId)
                .ConfigureAwait(false);

            return user?.Addresses ?? Enumerable.Empty<Address>();
        }



    }
}
