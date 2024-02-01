using Entity.Model;

namespace Repository.Interface.User
{
    public interface RoleIRepository : IGenericRepository<Role>
    {
        Task<Role> GetRoleOfAUser(RoleUser roleUser);

        Task<List<Role>> GetRole(int userId);
    }
}
