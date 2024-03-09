using AutoMapper;
using Context.Interface;
using Entity.Model;
using Microsoft.AspNetCore.Http;
using Model.Order;
using Repository.Interface.Item;
using Repository.Interface.Order;
using Repository.Interface.User;
using Service.Interface.Order;
using Service.Interface.User;

namespace Service.Order
{
    public class OrderService : IOrderService
    {
        private readonly ICartRepository _cartRepository;
        private readonly PotShopIDbContext _table;
        private readonly ItemIRepository _itemRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IConnectionService _connectionService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public OrderService(
            IMapper mapper,
            PotShopIDbContext _idbcontext,
            ICartRepository cartRepository, 
            ItemIRepository itemRepository,
            IAddressRepository addressRepository,
            IConnectionService connectionService,
            IHttpContextAccessor httpContextAccessor,
            IOrderRepository orderRepository
        )
        {
            _cartRepository = cartRepository;
            _table = _idbcontext;
            _itemRepository = itemRepository;
            _connectionService = connectionService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _orderRepository = orderRepository;
            _addressRepository = addressRepository;
        }

        /// <summary>
        /// create order
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ReadOrder> CreateOrderFromCart(AddOrder request)
        {
            var userInfo = _connectionService.GetCurrentUserInfo(_httpContextAccessor);
            int userId = userInfo.Id;

            List<Cart> cartItems = await _cartRepository.GetCartItemsByUserId(userId);

            var orderItems = _mapper.Map<List<OrderItem>>(cartItems);

            foreach (var orderItem in orderItems)
            {
                var itemDetails = await _itemRepository.GetItemDetailsByIdAsync(orderItem.Item.Id);
                orderItem.Item = itemDetails;
                orderItem.Subtotal = itemDetails.Price * orderItem.Quantity;
            }

            if (!orderItems.Any())
            {
                throw new Exception("L'action a échoué : aucune produits est contenu dans le panier.");
            }


            Address adreessuser =  await _addressRepository.GetByKeys(request.AddressId).ConfigureAwait(false);
            var orderEntity = new Entity.Model.Order
            {


                TotalAmount = CalculateTotalAmount(orderItems),
                State = adreessuser.State,
                Street = adreessuser.Street,
                City = adreessuser.City,
                Code = adreessuser.Code,
                PaymentMethod = request.PaymentMethod,
                OrderStatus = "En attente",
                CreatedDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow
            };

            orderEntity.OrderItems.AddRange(orderItems);

            Entity.Model.Order newOrder = await _orderRepository
                .CreateElementAsync(orderEntity)
                .ConfigureAwait(false);

            if (newOrder == null)
            {
                throw new Exception("L'action a échoué : la commande n'a pas été ajoutée.");
            }
            else
            {
                await _cartRepository.DeleteCartItemsByUserId(userId);
                return _mapper.Map<ReadOrder>(newOrder);
            }
        }

        /// <summary>
        /// get order by user
        /// </summary>
        /// <returns></returns>
        public async Task<List<ReadOrder>> GetOrdersByUserId()
        {
            var userInfo = _connectionService.GetCurrentUserInfo(_httpContextAccessor);
            int userId = userInfo.Id;

            var orders = await _orderRepository.GetOrdersByUserId(userId);

            if (orders == null || !orders.Any())
            {
                throw new Exception("L'action a échoué : aucune commande n'a pas été trouvée.");
            }

            return _mapper.Map<List<ReadOrder>>(orders);
        }

        /// <summary>
        /// delete order
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Entity.Model.Order> DeleteOrder(DeleteOrder request)
        {
            Entity.Model.Order order = await _orderRepository
                .GetByKeys(request.OrderId)
                .ConfigureAwait(false);

            if (order == null)
                throw new Exception("L'action a échoué : la commande n'a pas été trouve");

            Entity.Model.Order orderDelete = await _orderRepository
                .DeleteElementAsync(order)
                .ConfigureAwait(false);

            if (orderDelete == null)
            {
                throw new Exception("L'action a échoué");
            }
            else
            {
                return orderDelete;
            }
        }

        /// <summary>
        /// calculate total amount order
        /// </summary>
        /// <param name="orderItems"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public float? CalculateTotalAmount(List<OrderItem> orderItems)
        {
            if (orderItems == null)
            {
                throw new ArgumentNullException(
                    nameof(orderItems),
                    "La liste d'éléments ne peut pas être nulle."
                );
            }

            float? totalAmount = orderItems.Sum(item => item.Subtotal);

            return totalAmount;
        }
    }
}
