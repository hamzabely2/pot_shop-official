using Context.Interface;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Interface.Order;


namespace Repository.Order
{
    public class OrderRepository : GenericRepository<Entity.Model.Order>, IOrderRepository
    {
        public OrderRepository(PotShopIDbContext idbcontext) : base(idbcontext)
        {
            _table = _idbcontext.Set<Entity.Model.Order>();
        }
        private readonly DbSet<Entity.Model.Order> _table;


       /* public async Task<int> CreateOrderFromCart(int userId, List<CartItem> cartItems, string shippingAddress, string billingAddress, string paymentMethod)
        {
            Entity.Model.User user = await _idbcontext.Users
                .Include(u => u.Cart)
                    .ThenInclude(c => c.Items)
                .SingleOrDefaultAsync(u => u.Id == userId);

            if (user != null && user.Cart != null)
            {
                var order = new Entity.Model.Order
                {
                    UserId = user.Id,
                    TotalAmount = (decimal)cartItems.Sum(item => item.Price * item.Quantity),
                    OrderDate = DateTime.UtcNow,
                    ShippingAddress = shippingAddress,
                    BillingAddress = billingAddress,
                    PaymentMethod = paymentMethod,
                    OrderStatus = "Pending" 
                };

                foreach (var cartItem in cartItems)
                {
                    order.OrderItems.Add(new OrderItem
                    {
                        Item = cartItem.Item,
                        Quantity = cartItem.Quantity,
                        Subtotal = (decimal)(cartItem.Price * cartItem.Quantity)
                    });
                }

                _idbcontext.Orders.Add(order);
                await _idbcontext.SaveChangesAsync();

                user.Cart.Items.Clear();
                await   _idbcontext.SaveChangesAsync();

                return order.Id;
            }

            return -1; 
        }*/
    }
}
