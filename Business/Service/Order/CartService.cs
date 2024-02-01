using Context.Interface;
using Entity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Cart;
using Model.Item;
using Repository.Interface.Item;
using Repository.Interface.Order;
using Service.Interface.Item;
using Service.Interface.Order;
using Service.Interface.User;
using Service.User;

namespace Service.Order
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly PotShopIDbContext _table;
        private readonly ItemIRepository _itemRepository;
        private readonly IConnectionService _connectionService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartService(PotShopIDbContext _idbcontext, ICartRepository cartRepository, ItemIRepository itemRepository, IConnectionService connectionService, IHttpContextAccessor httpContextAccessor)
        {
            _cartRepository = cartRepository;
            _table = _idbcontext;
            _itemRepository = itemRepository;
            _connectionService = connectionService;
            _httpContextAccessor = httpContextAccessor;


        }
        public async Task<CartItem> AddToCart(AddCart request)
        {
            var userInfo = _connectionService.GetCurrentUserInfo(_httpContextAccessor);
            int userId = userInfo.Id;

            Entity.Model.Item item = await _itemRepository.GetByKeys(request.ItemId) ?? throw new ArgumentException("L'action a échoué : l'article n'existe pas");

            // Récupérer le panier de l'utilisateur
            List<CartItem> userCart = await _cartRepository.AddOrUpdateItemInCart(userId, new CartItem
            {
                ItemId = item.Id,
                Price = item.Price ?? 0,
                Quantity = request.Quantity
            });

            // Retourner l'article ajouté ou mis à jour
            return userCart.Last();
        }




        public async Task<List<CartItem>> GetCards()
        {
            var userInfo = _connectionService.GetCurrentUserInfo(_httpContextAccessor);
            int userId = userInfo.Id;
            var userCart = await _cartRepository.GetCartItemsForUser(userId).ConfigureAwait(false);
        
            return userCart;

        }

        public async Task<List<CartItem>> RemoveItem( int itemId)
        {
            var userInfo = _connectionService.GetCurrentUserInfo(_httpContextAccessor);
            int userId = userInfo.Id;

            List<CartItem> updatedCart = await _cartRepository.RemoveItemFromCart(userId, itemId);

            return updatedCart;
        }


    }
}
