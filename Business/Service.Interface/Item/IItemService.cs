using Model.DetailsItem;
using Model.Item;

namespace Service.Interface.Item
{
    public interface IItemService
    {
        Task<List<ReadItem>> GetListItem();
        Task<ReadItem> GetItemById(int itemId);
        Task<ReadItem> UpdateItem( int itemId, ItemUpdate request);
        Task<ReadItem> DeleteItem(int itemId);
        Task<ReadItem> CreateItem(ItemAdd request);
        Task<ReadItem> GetItemDetails(int itemId);
        Task<ReadItem> AddColorByItem(AddColorByItem request);
        Task<ReadItem> AddImageByItem(AddImageByItem request);
        Task<ReadItem> DeleteColorByItem(AddColorByItem request);
        Task<List<ReadItem>> GetFilteredItems(FilteredItem request);
        Task<ReadItem> DeleteImageByItem(DeleteImageByItem request);
    }
}
