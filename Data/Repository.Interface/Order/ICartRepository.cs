using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.Order
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<List<Cart>> GetCartItemsByUserId(int userId);
        Task<Cart> GetCartItemByUserIdAndItemId(int userId, int itemId);
        Task DeleteCartItemsByUserId(int userId);
    }
}
