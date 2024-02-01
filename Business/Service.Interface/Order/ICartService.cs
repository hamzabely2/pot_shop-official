
using Entity.Model;
using Model.Cart;

namespace Service.Interface.Order
{
    public interface ICartService
    {
        Task<CartItem> AddToCart(AddCart request);

        Task<List<CartItem>> GetCards();
        Task<List<CartItem>> RemoveItem(int itemId);

        //void CalculateCartTotal(Cart cart);
    }
}
