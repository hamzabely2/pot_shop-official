using Api.Data.Context.Contract;
using Api.Data.Context.Model;
using Api.Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;


namespace Api.Data.Repository
{
    public class RepositoryAddress : GenericRepository<Address>, IRepositoryAddress
    {
        public RepositoryAddress(IDBContext _idbcontext) : base(_idbcontext)
        {
            _table = _idbcontext.Set<Address>();
        }
        private readonly DbSet<Address> _table;


        //add adresse to user
        public async Task<Boolean> AddAdressToUser(string IdUser, int IdAdresse)
        {
            var user = await _idbcontext.Users.FindAsync(IdUser);
            var adresse = await _table.FindAsync(IdAdresse);

            if (user != null && adresse != null)
            {
                var addressUser = new AddressUser
                {
                    UserId = IdUser,
                    AddresseId = IdAdresse
                };

                _idbcontext.Addresses_Users.Add(addressUser);
                await _idbcontext.SaveChangesAsync();

                return true;
            }
            return false;
        }

        /// <summary>
        /// get addresses for user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<Address>> GetAdressesForUser(string IdUser)
        {
            var adresseIds = await _idbcontext.Addresses_Users
                .Where(au => au.UserId == IdUser)
                .Select(au => au.AddresseId)
                .ToListAsync();

            var adresses = await _idbcontext.Addresses
                .Where(a => adresseIds.Contains(a.Id))
                .ToListAsync();

            return adresses;
        }

    }
}
