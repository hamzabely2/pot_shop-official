using Context.Interface;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Interface.Item;

namespace Repository.Item
{
    public class ColorRepository : GenericRepository<Color>, ColorIRepository
    {
        public ColorRepository(PotShopIDbContext idbcontext) : base(idbcontext)
        {
            _table = _idbcontext.Set<Color>();
        }
        private readonly DbSet<Color> _table;


        /// get color by name   <summary>
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<Color> GetColorByName(string hex)
        {
            Color color = await _table.FirstOrDefaultAsync(x => x.Hex == hex).ConfigureAwait(false);

            return color;
        }


      
    }
}
