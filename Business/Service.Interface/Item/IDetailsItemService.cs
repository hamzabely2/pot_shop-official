using Model.DetailsItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface.Item
{
    public interface IDetailsItemService
    {
        /// <summary>
        /// crud for  color
        /// </summary>
        Task<List<ColorDto>> GetAllColor();
        Task<ColorDto> CreateColor(ColorDto request);
        Task<ColorDto> DeleteColor(int colorId);

        /// <summary>
        /// crud for category
        /// </summary>
        Task<List<CategoryDto>> GetAllCategory();
        Task<CategoryDto> CreateCategory(CategoryDto request);
        Task<CategoryDto> DeleteCategory(int categoryId);

        /// <summary>
        /// crud for material
        /// </summary>
        Task<List<ReadMaterial>> GetAllMaterial();
        Task<ReadMaterial> CreateMaterial(ReadMaterial request);
        Task<ReadMaterial> DeleteMaterial(int materilId);
    }
}
