
using Entity.Model;
using Model.Cart;
using Model.Item;

namespace Service.Interface.Order
{
    public interface ICartService
    {
        Task<CartItem> CreateCart(AddCart request);
        Task<IEnumerable<CartItem>> GetCartItemsByUserId();
        Task<IEnumerable<CartItem>> DeleteItemInTheCart(int ItemId);


        //void CalculateCartTotal(Cart cart);*/
    }
}
