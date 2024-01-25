using Entity.Model;

namespace Service.Interface
{
    public interface IRoleService
    {
        void AddRoles();
        Task<RoleUser> AssignRoleAsync(int userId, int roleId);
        Task DeleteRoleAsync(int userId);

    }
}
