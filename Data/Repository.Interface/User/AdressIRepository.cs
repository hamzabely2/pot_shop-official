using Entity.Model;

namespace Repository.Interface.User
{
    public interface AdressIRepository : IGenericRepository<Adress>
    {

        Task<IEnumerable<Adress>> GetAdressesByUserId(int userId);
    }
}
