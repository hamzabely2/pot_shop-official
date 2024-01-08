using Api.Data.Repository.Contract;
using Api.Data.Context.Contract;
using Microsoft.EntityFrameworkCore;

using Api.Data.Context.Model;
using System.Security.Cryptography;

namespace Api.Data.Repository
{
    public class RepositoryUser : GenericRepository<User>, IRepositoryUser
    {
        public RepositoryUser(IDBContext _idbcontext) : base(_idbcontext)
        {
            _table = _idbcontext.Set<User>();
        }

        public readonly DbSet<User> _table;

        /// get by name   <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<User> GetUserByName(string name)
        {
            User user = await _table.FirstOrDefaultAsync(x => x.UserName == name ).ConfigureAwait(false);
            if (user == null)
                throw new ArgumentException("l'action a échoué");
            return user;
        }

        /// get user by id   <summary>
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<User> GetUserById(string IdUser)
        {
            User user = await _idbcontext.Users.FirstOrDefaultAsync(x => x.Id == IdUser).ConfigureAwait(false);
            if (user == null)
                throw new ArgumentException("l'action a échoué");
            return user;
        }
    }
}
