using Entity.Model;

namespace Repository.Interface.Item
{
    public interface ItemIRepository : IGenericRepository<Entity.Model.Item>
    {
        List<Entity.Model.Item> GetItemsWithDetails();
        Task<Entity.Model.Item> GetItemByName(string name);
        Task<Entity.Model.Item> GetItemDetailsByIdAsync(int itemId);
    }
}
