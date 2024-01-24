using Entity.Model;

namespace Repository.Interface
{
    public interface RoleIRepository : IGenericRepository<Role>
    {
        Task<Role> GetRoleOfAUser(RoleUser roleUser);

        Task<List<Role>> GetRole(int userId);
    }
}
