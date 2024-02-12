
using Context.Interface;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Interface.User;

namespace Repository.User
{
    public class UserRepository : GenericRepository<Entity.Model.User>, UserIRepository
    {
        public readonly DbSet<Entity.Model.User> _table;

        public UserRepository(PotShopIDbContext idbcontext) : base(idbcontext)
        {
            _table = _idbcontext.Set<Entity.Model.User>();
        }


        /// get user by name   <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<Entity.Model.User> GetUserByName(string name)
        {
            Entity.Model.User user = await _table.FirstOrDefaultAsync(x => x.FirstName == name).ConfigureAwait(false);

            return user;
        }


        /// get user by email   <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<Entity.Model.User> GetUserByEmail(string email)
        {
            Entity.Model.User user = await _table.FirstOrDefaultAsync(x => x.Email == email).ConfigureAwait(false);

            return user;
        }


    }
}
