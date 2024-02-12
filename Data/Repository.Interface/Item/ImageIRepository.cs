using Entity.Model;

namespace Repository.Interface.Item
{
    public interface ImageIRepository : IGenericRepository<Image>
    {
        Task<List<Image>> GetImagesByItemId(int itemId);
        Task DeleteAllImagesForItem(int itemId);
    }
}
