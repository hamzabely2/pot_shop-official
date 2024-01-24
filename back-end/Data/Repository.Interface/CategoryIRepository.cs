using Entity.Model;

namespace Repository.Interface
{
    public interface CategoryIRepository : IGenericRepository<Category>
    {
        Task<Category> GetCategoryByName(string label);
    }
}
