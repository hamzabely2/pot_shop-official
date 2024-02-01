using Entity.Model;

namespace Repository.Interface.User
{
    public interface UserIRepository : IGenericRepository<Entity.Model.User>
    {
        Task<Entity.Model.User> GetUserByName(string name);
        Task<Entity.Model.User> GetUserByEmail(string email);

    }
}
