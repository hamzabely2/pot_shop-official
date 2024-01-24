using Entity.Model;

namespace Repository.Interface
{
    public interface AdressIRepository : IGenericRepository<Adress>
    {
        Task<bool> AddAdressToUser(int userId, int adressId);
        Task<List<Adress>> GetAdressesForUser(int userId);
    }
}
