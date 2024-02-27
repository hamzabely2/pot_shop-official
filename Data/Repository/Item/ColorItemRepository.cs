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


        public async Task<ColorItem> GetColorByItemIdAndColorId(int itemId, int colorId)
        {
            // Supposons que vous avez une méthode dans votre repository qui récupère une couleur en fonction de l'ID de l'article et de l'ID de couleur
            // Voici un exemple hypothétique de cette méthode :
            return await _table.FirstOrDefaultAsync(ci => ci.ItemId == itemId && ci.ColorId == colorId).ConfigureAwait(false);
        }

        public async Task DeleteColorByItemIdAndColorId(int itemId, int colorId)
        {
            var colorItem = await _idbcontext.ColorsItems
                                        .FirstOrDefaultAsync(ci => ci.ItemId == itemId && ci.ColorId == colorId)
                                        .ConfigureAwait(false);

            if (colorItem != null)
            {
                _idbcontext.ColorsItems.Remove(colorItem);
                await _idbcontext.SaveChangesAsync().ConfigureAwait(false);
            }
        }



    }
}
