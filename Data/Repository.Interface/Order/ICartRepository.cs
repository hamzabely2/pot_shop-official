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
        Task SaveOrUpdate(Cart cart);
        Task<List<CartItem>> AddOrUpdateItemInCart(int userId, CartItem newItem);
        Task<List<CartItem>> GetCartItemsForUser(int userId);
        Task<List<CartItem>> RemoveItemFromCart(int userId, int itemId);

        Task<List<CartItem>> UpdateCartItemQuantity(int userId, int itemId, int newQuantity);
    }
}
