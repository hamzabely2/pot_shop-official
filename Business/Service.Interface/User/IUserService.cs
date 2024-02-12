using Model.User;


namespace Service.Interface.User
{
    public interface IUserService
    {
        Task<List<Entity.Model.User>> GetAllUsers();
        Task<Entity.Model.User> GetUserByName();
        Task<string> Register(UserRegister request);
        Task<string> Login(UserLogin request);
        Task<UserRead> UpdateUser(UserUpdate request);
        Task<UserRead> UpdatePasswordUser(UserPassword request);
        Task<UserRead> DeleteUser(int userId);


    }
}
