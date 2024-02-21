using Entity.Model;

namespace Repository.Interface.Item
{
    public interface ColorIRepository : IGenericRepository<Color>
    {
        Task<Color> GetColorByName(string label);
    }
}
