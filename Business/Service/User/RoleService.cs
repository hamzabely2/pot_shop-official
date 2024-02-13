
using Context.Interface;
using Entity.Model;
using Repository.Interface.User;
using Service.Interface.User;

namespace Service.User
{
    public class RoleService : IRoleService
    {
        private readonly PotShopIDbContext _context;
        private readonly RoleIRepository _roleRepository;
        private readonly UserIRepository _userRepository;
        private readonly RoleUserIRepository _roleUserRepository;

        public RoleService(PotShopIDbContext context, RoleIRepository roleRepository, UserIRepository userRepository, RoleUserIRepository roleUserRepository)
        {
            _context = context;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _roleUserRepository = roleUserRepository;
        }

        /// <summary>
        /// adding roles
        /// </summary>
        public async void AddRoles()
        {
            var roles = new List<string>
            {
                 "User","Admin","SuperAdmin",
            };

            foreach (var role in roles)
            {
                if (!_context.Roles.Any(c => c.Name == role))
                {
                    var nouvelleDonnee = new Role { Name = role };
                    _context.Roles.Add(nouvelleDonnee);
                }
            }

            _context.SaveChanges();
        }



        public async Task<RoleUser> AssignRoleAsync(int userId, int roleId)
        {
            var user = await _userRepository.GetByKeys(userId);
            var role = await _roleRepository.GetByKeys(roleId);

            if (user != null && role != null)
            {
                var userRole = new RoleUser
                {
                    UserId = userId,
                    RoleId = roleId
                };

                var addedRoleUser = await _roleUserRepository.CreateElementAsync(userRole);
                await _context.SaveChangesAsync();

                return addedRoleUser;
            }
            throw new ArgumentException("L'enregistrement n'a pas réussi, quelque chose s'est mal passé");
        }


        public async Task DeleteRoleAsync(int userId)
        {
            var rolesUsers = _context.UsersRoles.Where(ru => ru.UserId == userId);
            _context.UsersRoles.RemoveRange(rolesUsers);

            await _context.SaveChangesAsync();
        }
    }
}
