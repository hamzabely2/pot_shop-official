using Model.User;


namespace Service.Interface
{
    public interface UserIService
    {
        Task<UserRead> GetUserByName(string name);
        Task<string> Register(UserRegister request);
        Task<string> Login(UserLogin request);
        Task<UserRead> Update(UserUpdate request);
        Task<UserRead> UpdatePassword(UserPassword request);
        Task<UserRead> Delete(int userId);
    }
}
