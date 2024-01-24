using Entity.Model;

namespace Repository.Interface
{
    public interface ItemIRepository : IGenericRepository<Item>
    {
        List<Item> GetItemsWithDetails();
        Task<Item> GetItemByName(string name);
    }
}
