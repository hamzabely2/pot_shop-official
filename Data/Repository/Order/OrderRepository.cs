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


        public async Task<List<Entity.Model.Order>> GetOrdersByUserId(int userId)
        {
            return await _table
                .Where(order => order.UserId == userId)
                .ToListAsync();
        }

    }
}
