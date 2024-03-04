using Entity.Model;
using Mapper.User;
using Microsoft.AspNetCore.Http;
using Model.User;
using Repository.Interface.User;
using Service.Interface.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace Service.User
{
    public class UserService : IUserService
    {

        private readonly UserIRepository _userRepository;
        private readonly IRoleService _roleService;
        private readonly RoleIRepository _roleRepository;
        private readonly IConnectionService _connectionService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(UserIRepository userRepository, IRoleService roleService, RoleIRepository roleRepository, IConnectionService connectionService, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _roleService = roleService;
            _roleRepository = roleRepository;
            _connectionService = connectionService;
            _httpContextAccessor = httpContextAccessor;

        }

        /// Get user by Name <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<Entity.Model.User> GetUserByName()
        {
            UserInfo userInfo = _connectionService.GetCurrentUserInfo(_httpContextAccessor);
            int userConnectedId = userInfo.Id;

            Entity.Model.User user = await _userRepository.GetByKeys(userConnectedId).ConfigureAwait(false);
         
            return user;
        }



        /// Get all users <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<List<Entity.Model.User>> GetAllUsers()
        {         
                var users = await _userRepository.GetAllAsync().ConfigureAwait(false);

                if (users == null || !users.Any())
                {
                    throw new ArgumentException("La récupération des utilisateurs a échoué ou la liste est vide.");
                }

                if (users != null)
                {
                return users.ToList();
                }   
               
                throw new Exception("Une erreur s'est produite lors de la récupération des utilisateurs.");
            
        }

        /// <summary>
        /// register user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>

        public async Task<string> Register(UserRegister request)
        {

            var firstNameExiste = _userRepository.GetUserByName(request.FirstName);
            if (firstNameExiste.Result != null)
                throw new ArgumentException("l'action a échoué : le nom existe déjà");

            var emailNameExiste = _userRepository.GetUserByEmail(request.Email);
            if (emailNameExiste.Result != null)
                throw new ArgumentException("l'action a échoué :l'email existe déjà");

            if (!_connectionService.IsValidEmail(request.Email))
                throw new ArgumentException("Adresse e-mail non valide");

            if (!_connectionService.IsPasswordValid(request.Password))
                throw new ArgumentException("les mots de passe doivent comporter au moins un chiffre ('0' - '9'). Les mots de passe doivent contenir au moins une majuscule ('A' - 'Z').");

            var passwordHash = _connectionService.HashPassword(request.Password);
            var newUser = UserMapper.TransformDtoRegister(request, passwordHash);

            
            var user = await _userRepository.CreateElementAsync(newUser).ConfigureAwait(false);
            if (user == null)
                throw new ArgumentException("L'enregistrement n'a pas réussi, quelque chose s'est mal passé");


            //addin role of a user
            var roleAssignmentResult = await _roleService.AssignRoleAsync(user.Id, 1);
            if (roleAssignmentResult == null)
            {
                throw new ArgumentException("L'enregistrement n'a pas réussi, quelque chose s'est mal passé lors de l'attribution du rôle");
            }

            var claims = new List<Claim>
            {
            new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
            new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            new Claim(ClaimTypes.Email, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

            };
            foreach (var roleUser in user.Roles_Users)
            {
                var role = await _roleRepository.GetRoleOfAUser(roleUser).ConfigureAwait(false);
                if (role != null)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Name));
                }
            }

            //create token
            var token = _connectionService.CreateToken(claims);
            _connectionService.AddTokenCookie(new JwtSecurityTokenHandler().WriteToken(token), _httpContextAccessor);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        /// Login <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<string> Login(UserLogin request)
        {
            var user = await _userRepository.GetUserByEmail(request.Email);
            if (user == null || !_connectionService.VerifyPassword(request.Password, user.PasswordHash))
            {
                throw new ArgumentException($"La connexion a échoué : e-mail ou mot de passe incorrect.");
            }

            if(user.Deactivated == true)
            {
                throw new ArgumentException("Votre compte est actuellement désactivé ou indisponible pour le moment. Pour plus d'informations, contactez le service client");
            }
           
            var role = _roleRepository.GetRole(user.Id); ;
            var claims = new List<Claim>
                {
                new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, role.Result[0].Name),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = _connectionService.CreateToken(claims);

            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.UtcNow.AddDays(1),
                HttpOnly = true,
                Secure = true,
                Domain = "example.com"
            };

            _httpContextAccessor.HttpContext.Response.Cookies.Append("token", new JwtSecurityTokenHandler().WriteToken(token), cookieOptions);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        /// Update user <summary>
        /// </summary>
        /// <param name="userDto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<Entity.Model.User> UpdateUser(UserUpdate request)
        {
            var userInfo = _connectionService.GetCurrentUserInfo(_httpContextAccessor);
            int userConnectedId = userInfo.Id;
            string roleUser = userInfo.Role;

            Entity.Model.User userToUpdate;


            if (roleUser == RoleString.Admin)
            {
                userToUpdate = await _userRepository.GetByKeys(request.Id);
            }
            else
            {
                userToUpdate = await _userRepository.GetByKeys(userConnectedId);

            }


            if (userToUpdate == null)
                throw new ArgumentException("L'action a échoué : l'utilisateur n'a pas été trouvé");

            if (request.FirstName != userToUpdate.FirstName)
            {
                var userExistsUserName = await _userRepository.GetUserByName(request.FirstName);
                if (userExistsUserName != null)
                    throw new ArgumentException("L'action a échoué : le nom existe déjà");
            }

            if (request.Email != userToUpdate.Email)
            {
                var userExistsEmail = await _userRepository.GetUserByEmail(request.Email);
                if (userExistsEmail != null)
                    throw new ArgumentException("L'action a échoué : l'email existe déjà");
            }

            var user = UserMapper.TransformDtoUpdate(request, userToUpdate);
            var userUpdate = await _userRepository.UpdateElementAsync(user).ConfigureAwait(false);
            if (userUpdate == null)
                throw new ArgumentException("L'action a échoué : la modification des données utilisateur a échoué");

            return userUpdate;
        }


        /// Update password to user <summary>
        /// </summary>
        /// <param name="userDto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<UserRead> UpdatePasswordUser(UserPassword request)
        {
            var userInfo = _connectionService.GetCurrentUserInfo(_httpContextAccessor);
            int userConnectedId = userInfo.Id;
            var user = await _userRepository.GetByKeys(userConnectedId);

            if (!_connectionService.VerifyPassword(request.OldPassword, user.PasswordHash))
            {
                throw new ArgumentException($"La connexion a échoué : l'ancien mot de passe n'est pas correct");
            }

            if (request.ConfirmNewPassword != request.NewPassword)
                throw new ArgumentException("L'action a échoué: le nouveau mot de passe ne correspond pas au mot de passe de confirmation");


            if (!_connectionService.IsPasswordValid(request.NewPassword))
                throw new ArgumentException("L'action a échoué: les mots de passe doivent comporter au moins un chiffre ('0' - '9'). Les mots de passe doivent contenir au moins une majuscule ('A' - 'Z').\\\"\"");

            if (request.OldPassword == request.NewPassword)
                throw new ArgumentException("L'action a échoué: le nouveau mot de passe est le même que l'ancien");

            var passwordHash = _connectionService.HashPassword(request.NewPassword);
            user.PasswordHash = passwordHash;

            await _userRepository.UpdateElementAsync(user);
            var changePasswordResult = UserMapper.TransformDtoExit(user);

            return changePasswordResult;
        }


        /// Delete user<summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<UserRead> DeleteUser()
        {
            var userInfo = _connectionService.GetCurrentUserInfo(_httpContextAccessor);
            int userConnectedId = userInfo.Id;
            var user = await _userRepository.GetByKeys(userConnectedId);

            if (user == null)
                throw new ArgumentException("L'action a échoué : l'ulisateur n'a pas été trouvée");

            await _roleService.DeleteRoleAsync(userConnectedId);
            Entity.Model.User userDelete = await _userRepository.DeleteElementAsync(user);
            if (userDelete == null)
                throw new ArgumentException($"L'utilisateur ne existe pas.");

            return UserMapper.TransformDtoExit(userDelete);
        }
        }
    
}
