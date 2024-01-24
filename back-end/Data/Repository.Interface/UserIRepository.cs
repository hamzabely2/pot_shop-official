using Entity.Model;

namespace Repository.Interface
{
    public interface UserIRepository : IGenericRepository<User>
    {
        Task<User> GetUserByName(string name);
        Task<User> GetUserByEmail(string email);

    }
}
