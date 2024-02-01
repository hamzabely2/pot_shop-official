using Entity.Model;

namespace Repository.Interface.Item
{
    public interface MaterialIRepository : IGenericRepository<Material>
    {
        Task<Material> GetMaterialByName(string label);

    }
}
