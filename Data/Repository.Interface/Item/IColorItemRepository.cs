using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.Item
{
    public interface IColorItemRepository : IGenericRepository<ColorItem>
    {
        Task<ColorItem> GetColorByItemIdAndColorId(int itemId, int colorId);
        Task DeleteColorByItemIdAndColorId(int itemId, int colorId);

    }
}
