using Api.Data.Context.Model;


namespace Api.Data.Repository.Contract
{
    public interface IRepositoryUser : IGenericRepository<User>
    {
        Task<User> GetUserByName(string name);
        Task<User> GetUserById(string IdUser);
    }
}
