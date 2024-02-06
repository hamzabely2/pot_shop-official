using Context.Interface;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Interface.Order;

namespace Repository.Order
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(PotShopIDbContext _idbcontext)
            : base(_idbcontext)
        {
            _table = _idbcontext.Set<Cart>();
        }

        private readonly DbSet<Cart> _table;

        public async Task<List<Cart>> GetCartItemsByUserId(int userId)
        {
            return await _idbcontext
                .Carts.Include(cart => cart.Items)
                .Where(cart => cart.UserId == userId)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<Cart> GetCartItemByUserIdAndItemId(int userId, int itemId)
        {
            return await _table
                .Where(c => c.UserId == userId && c.ItemId == itemId)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }

        public async Task DeleteCartItemsByUserId(int userId)
        {
            var cartItems = await _table.Where(c => c.UserId == userId).ToListAsync();
            _table.RemoveRange(cartItems);
            await _idbcontext.SaveChangesAsync();
        }
    }
}
