

using Entity.Model;
using Model.DetailsItem;

namespace Mapper.DetailsItem
{
    public static class DatailsItemMapper
    {

        /// <summary>
        /// DTO fot category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static CategoryDto TransformExiteCategory(Category category)
        {
            return new CategoryDto
            {
                Label = category.Label,
            };
        }
        public static Category TransformCreateCategory(CategoryDto request)
        {
            return new Category
            {
                Label = request.Label,
            };
        }

        /// <summary>
        /// DTO fot material
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static MaterialDto TransformExiteMaterial(Material material)
        {
            return new MaterialDto
            {
                Label = material.Label,
            };
        }
        public static Material TransformCreateMaterial(MaterialDto request)
        {
            return new Material
            {
                Label = request.Label,
            };
        }
    }
}
