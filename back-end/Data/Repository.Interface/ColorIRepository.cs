using Entity.Model;

namespace Repository.Interface
{
    public interface ColorIRepository : IGenericRepository<Color>
    {
        Task<Color> GetColorByName(string label);
    }
}
