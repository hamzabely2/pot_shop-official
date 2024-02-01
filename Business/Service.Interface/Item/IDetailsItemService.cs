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
        void AddColors();
        Task<List<ColorDto>> GetAllColor();
        Task<ColorDto> CreateColor(ColorDto request);
        Task<ColorDto> DeleteColor(int colorId);
        /// <summary>
        /// crud for category
        /// </summary>
        void AddCategories();
        Task<List<CategoryDto>> GetAllCategory();
        Task<CategoryDto> CreateCategory(CategoryDto request);
        Task<CategoryDto> DeleteCategory(int categoryId);
        /// <summary>
        /// crud for material
        /// </summary>
        void AddMaterials();
        Task<List<MaterialDto>> GetAllMaterial();
        Task<MaterialDto> CreateMaterial(MaterialDto request);
        Task<MaterialDto> DeleteMaterial(int materilId);
    }
}
