
using Context.Interface;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository
{
    public class UserRepository : GenericRepository<User>, UserIRepository
    {
        public readonly DbSet<User> _table;

        public UserRepository(PotShopIDbContext idbcontext) : base(idbcontext)
        {
            _table = _idbcontext.Set<User>();
        }

        /// get user by name   <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<User> GetUserByName(string name)
        {
            User user = await _table.FirstOrDefaultAsync(x => x.FirstName == name).ConfigureAwait(false);

            return user;
        }


        /// get user by email   <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<User> GetUserByEmail(string email)
        {
            User user = await _table.FirstOrDefaultAsync(x => x.Email == email).ConfigureAwait(false);

            return user;
        }


    }
}
