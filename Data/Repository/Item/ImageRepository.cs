using Context.Interface;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Interface.Item;

namespace Repository.Item
{
    public class ImageRepository : GenericRepository<Image>, ImageIRepository
    {
        public ImageRepository(PotShopIDbContext idbcontext) : base(idbcontext)
        {
            _table = _idbcontext.Set<Image>();
        }
        private readonly DbSet<Image> _table;


        public async Task<List<Image>> GetImagesByItemId(int itemId)
        {
            return await _table
                .Where(i => i.ItemId == itemId)
                .ToListAsync()
                .ConfigureAwait(false);
        }
        public async Task DeleteAllImagesForItem(int itemId)
        {
            var imagesToDelete = await _table
                .Where(img => img.ItemId == itemId)
                .ToListAsync()
                .ConfigureAwait(false);

            foreach (var image in imagesToDelete)
            {
                _table.Remove(image);
            }

            await _idbcontext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
