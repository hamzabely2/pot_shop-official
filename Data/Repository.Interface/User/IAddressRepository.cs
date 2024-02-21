using Entity.Model;

namespace Repository.Interface.User
{
    public interface IAddressRepository : IGenericRepository<Address>
    {

        Task<IEnumerable<Address>> GetAddressesByUserId(int userId);
    }
}
