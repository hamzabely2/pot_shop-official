using Model.Item;

namespace Service.Interface.Item
{
    public interface IItemService
    {
        Task<List<ReadItem>> GetListItem();
        Task<ReadItem> GetItemById(int itemId);
        Task<ReadItem> UpdateItem( int itemId, ItemUpdate request);
        Task<string> DeleteItem(int itemId);
        Task<ReadItem> CreateItem(ItemAdd request);
    }
}
