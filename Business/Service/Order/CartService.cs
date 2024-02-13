using AutoMapper;
using Context.Interface;
using Entity.Model;
using Microsoft.AspNetCore.Http;
using Model.Cart;
using Model.Item;
using Org.BouncyCastle.Asn1.Ocsp;
using Repository.Interface.Item;
using Repository.Interface.Order;
using Service.Interface.Item;
using Service.Interface.Order;
using Service.Interface.User;
using Service.Item;

namespace Service.Order
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly PotShopIDbContext _table;
        private readonly ItemIRepository _itemRepository;
        private readonly IItemService _itemService;
        private readonly IConnectionService _connectionService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public CartService(
            IMapper mapper,
            PotShopIDbContext _idbcontext,
            ICartRepository cartRepository,
            ItemIRepository itemRepository,
            IConnectionService connectionService,
            IItemService itemService,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _cartRepository = cartRepository;
            _table = _idbcontext;
            _itemRepository = itemRepository;
            _connectionService = connectionService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _itemService = itemService;
        }

        /// <summary>
        /// create cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<CartItem> CreateCart(AddCart request)
        {
            var userInfo = _connectionService.GetCurrentUserInfo(_httpContextAccessor);
            int userId = userInfo.Id;

            if (userId == 0)
                throw new ArgumentException("L'action a échoué : l'utilisateur n'existe pas");

            var item = await _itemRepository.GetByKeys(request.ItemId).ConfigureAwait(false);
            if (item == null)
                throw new ArgumentException("L'action a échoué : l'article n'a pas été trouvé");

            var existingCartItem = await _cartRepository
                .GetCartItemByUserIdAndItemId(userId, request.ItemId)
                .ConfigureAwait(false);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity = request.Quantity;
                existingCartItem.Subtotal = item.Price * request.Quantity;
                existingCartItem.UpdateDate = DateTime.UtcNow;
                await _cartRepository.UpdateElementAsync(existingCartItem).ConfigureAwait(false);

                var cartItem = _mapper.Map<CartItem>(existingCartItem);
                cartItem.Items = await _itemService.GetItemDetails(request.ItemId).ConfigureAwait(false);
                return cartItem;
            }

            var cartEntity = _mapper.Map<Cart>(request);
            cartEntity.UserId = userId;
            cartEntity.Items = item;
            cartEntity.Subtotal = item.Price * request.Quantity;

            var createdCart = await _cartRepository
                .CreateElementAsync(cartEntity)
                .ConfigureAwait(false);

            var createdCartItem = _mapper.Map<CartItem>(createdCart);
            createdCartItem.Items = await _itemService.GetItemDetails(request.ItemId).ConfigureAwait(false);
            return createdCartItem;
        }


        /// <summary>
        /// get cart by user
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CartItem>> GetCartItemsByUserId()
        {
            var userInfo = _connectionService.GetCurrentUserInfo(_httpContextAccessor);
            int userId = userInfo.Id;

            var cartItems = await _cartRepository
                .GetCartItemsByUserId(userId)
                .ConfigureAwait(false);

            var cartItemsDto = new List<CartItem>();

            foreach (var cart in cartItems)
            {
                var cartItemDto = _mapper.Map<CartItem>(cart);
                cartItemDto.Items = await _itemService.GetItemDetails(cart.ItemId).ConfigureAwait(false);
                cartItemsDto.Add(cartItemDto);
            }

            return cartItemsDto;
        }


        /// <summary>
        /// delete item from the cart
        /// </summary>
        /// <param name="ItemId"></param>
        /// <returns></returns>
        /// <summary>
        public async Task<IEnumerable<CartItem>> DeleteItemInTheCart(int ItemId)
        {
            var userInfo = _connectionService.GetCurrentUserInfo(_httpContextAccessor);
            int userId = userInfo.Id;

            var cartItems = await _cartRepository.GetCartItemsByUserId(userId).ConfigureAwait(false);

            var existingCartItem = cartItems.FirstOrDefault(item => item.ItemId == ItemId);
            if(existingCartItem == null)
            {
                throw new Exception("L'action a échoué : l'article n'a pas été trouvé");
            }
            if (existingCartItem != null)
            {
                await _cartRepository.DeleteElementAsync(existingCartItem).ConfigureAwait(false);

                return cartItems.Select(cart => _mapper.Map<CartItem>(cart)).ToList();
            }

            throw new Exception("L'action a échoué");
        }
    }
}
