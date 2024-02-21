using Context.Interface;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Interface.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Item
{
    public class ColorItemRepository : GenericRepository<ColorItem>, IColorItemRepository
    {
        public ColorItemRepository(PotShopIDbContext idbcontext) : base(idbcontext)
        {
            _table = _idbcontext.Set<ColorItem>();
        }
        private readonly DbSet<ColorItem> _table;

   
    }
}
