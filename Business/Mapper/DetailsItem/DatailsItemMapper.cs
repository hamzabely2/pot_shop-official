

using Entity.Model;
using Model.DetailsItem;

namespace Mapper.DetailsItem
{
    public static class DatailsItemMapper
    {

        public static Category TransformCreateCategory(CategoryDto request)
        {
            return new Category
            {
                Label = request.Label,
            };
        }
    }
}
