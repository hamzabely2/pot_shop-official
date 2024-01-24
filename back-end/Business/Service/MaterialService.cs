using Context.Interface;
using Repository.Interface;

namespace Service
{
    public class MaterialService
    {
        private readonly PotShopIDbContext _context;
        private readonly MaterialIRepository _materialRepository;

        public MaterialService(PotShopIDbContext context, MaterialIRepository materialRepository)
        {
            _context = context;
            _materialRepository = materialRepository;

        }


    }
}
