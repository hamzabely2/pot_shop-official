using Entity.Model;

namespace Repository.Interface.Item
{
    public interface CategoryIRepository : IGenericRepository<Category>
    {
        Task<Category> GetCategoryByName(string label);
    }
}
