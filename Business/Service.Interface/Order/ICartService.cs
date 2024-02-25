
using Entity.Model;
using Model.Cart;
using Model.Item;

namespace Service.Interface.Order
{
    public interface ICartService
    {
        Task<CartItem> CreateCart(AddCart request);
        Task<IEnumerable<CartItem>> GetCartItemsByUserId();
        Task<IEnumerable<CartItem>> DeleteItemInTheCart(int id);
        Task<IEnumerable<CartItem>> UpdateCart(UpdateCart request);

        //void CalculateCartTotal(Cart cart);*/
    }
}
