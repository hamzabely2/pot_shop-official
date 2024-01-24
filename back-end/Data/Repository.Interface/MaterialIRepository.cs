using Entity.Model;

namespace Repository.Interface
{
    public interface MaterialIRepository : IGenericRepository<Material>
    {
        Task<Material> GetMaterialByName(string label);

    }
}
