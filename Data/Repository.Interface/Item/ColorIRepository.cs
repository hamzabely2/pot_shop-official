using Entity.Model;

namespace Repository.Interface.Item
{
    public interface ColorIRepository : IGenericRepository<Color>
    {
        Task<Color> GetColorByName(string label);
        Task DeleteAllColorsForItem(int itemId);
    }
}
