using Context.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Interface.Item;

namespace Repository.Item
{
    public class ItemRepository : GenericRepository<Entity.Model.Item>, ItemIRepository
    {
        public ItemRepository(PotShopIDbContext _idbcontext) : base(_idbcontext)
        {
            _table = _idbcontext.Set<Entity.Model.Item>();
        }
        private readonly DbSet<Entity.Model.Item> _table;


        /// get by name   <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<Entity.Model.Item> GetItemByName(string name)
        {
            Entity.Model.Item item = await _table.FirstOrDefaultAsync(x => x.Name == name).ConfigureAwait(false);

            return item;
        }

        /// get b name   <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public List<Entity.Model.Item> GetItemsWithDetails()
        {
            return _table
                .Include(i => i.Colors)
                .Include(i => i.Categories)
                .Include(i => i.Materials)
                .Include(i => i.ImagesItems)
                    .ThenInclude(ii => ii.Images).ToList();
        }
    }
}
