using Context.Interface;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Interface.Item;

namespace Repository.Item
{
    public class ImageRepository : GenericRepository<ImageItem>, ImageIRepository
    {
        public ImageRepository(PotShopIDbContext idbcontext) : base(idbcontext)
        {
            _table = _idbcontext.Set<ImageItem>();
        }
        private readonly DbSet<ImageItem> _table;







    }
}
