using AutoMapper;
using Context.Interface;
using Entity.Model;
using Model.DetailsItem;
using Repository.Interface.Item;
using Service.Interface.Item;

namespace Service.Item
{
    public class DetailsItemService : IDetailsItemService
    {
        private readonly PotShopIDbContext _context;
        private readonly ColorIRepository _colorRepository;
        private readonly CategoryIRepository _categoryRepository;
        private readonly MaterialIRepository _materialRepository;
        private readonly IMapper _mapper;

        public DetailsItemService(
            IMapper mapper,
            PotShopIDbContext context,
            ColorIRepository colorRepository,
            CategoryIRepository categoryRepository,
            MaterialIRepository materialRepository
        )
        {
            _context = context;
            _colorRepository = colorRepository;
            _categoryRepository = categoryRepository;
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// get all colors
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<List<ColorDto>> GetAllColor()
        {
            var colors = await _colorRepository.GetAllAsync().ConfigureAwait(false);
            if (colors == null)
                throw new ArgumentException("L'action a échoué");

            List<ColorDto> colorList = new();
            foreach (Color color in colors)
            {
                colorList.Add(_mapper.Map<ColorDto>(color));
            }
            return colorList;
        }

        /// <summary>
        /// create color
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ColorDto> CreateColor(ColorDto request)
        {
            var color = _mapper.Map<Color>(request);
            var LabelExiste = await _colorRepository.GetColorByName(request.Hex);
            if (LabelExiste != null)
                throw new ArgumentException("L'action a échoué: la couleur existe déjà");

            var colorCreated = await _colorRepository
                .CreateElementAsync(color)
                .ConfigureAwait(false);
            return _mapper.Map<ColorDto>(colorCreated);
        }

        /// <summary>
        /// delete color by id
        /// </summary>
        /// <param name="colorId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<ColorDto> DeleteColor(int colorId)
        {
            var color = await _colorRepository.GetByKeys(colorId).ConfigureAwait(false);
            if (color == null)
                throw new ArgumentException("L'action a échoué: la couleur n'existe pas");

            var colorDelete = await _colorRepository
                .DeleteElementAsync(color)
                .ConfigureAwait(false);
            return _mapper.Map<ColorDto>(colorDelete);
        }

        /// <summary>
        /// get all categories
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<List<CategoryDto>> GetAllCategory()
        {
            var categories = await _categoryRepository.GetAllAsync().ConfigureAwait(false);
            if (categories == null)
                throw new ArgumentException("L'action a échoué");

            List<CategoryDto> categoryList = new();
            foreach (Category categorie in categories)
            {
                categoryList.Add(_mapper.Map<CategoryDto>(categorie));
            }
            return categoryList;
        }

        /// <summary>
        /// create category
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CategoryDto> CreateCategory(CategoryDto request)
        {
            var category = _mapper.Map<Category>(request);
            var LabelExiste = await _categoryRepository.GetCategoryByName(request.Label);
            if (LabelExiste != null)
                throw new ArgumentException("L'action a échoué: la catégorie existe déjà");

            Category categoryCreated = await _categoryRepository
                .CreateElementAsync(category)
                .ConfigureAwait(false);
            return _mapper.Map<CategoryDto>(categoryCreated);
        }

        /// <summary>
        /// delete category by id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<CategoryDto> DeleteCategory(int categoryId)
        {
            Category category = await _categoryRepository.GetByKeys(categoryId).ConfigureAwait(false);
            if (category == null)
                throw new ArgumentException("L'action a échoué: la catégorie n'existe pas");

            Category categoryDelete = await _categoryRepository
                .DeleteElementAsync(category)
                .ConfigureAwait(false);
            return _mapper.Map<CategoryDto>(categoryDelete);
        }

        /// <summary>
        /// get all materials
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<List<MaterialDto>> GetAllMaterial()
        {
            var materials = await _materialRepository.GetAllAsync().ConfigureAwait(false);
            if (materials == null)
                throw new ArgumentException("L'action a échoué");

            List<MaterialDto> materialList = new();
            foreach (Material material in materials)
            {
                materialList.Add(_mapper.Map<MaterialDto>(material));
            }
            return materialList;
        }

        /// <summary>
        /// create material
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<MaterialDto> CreateMaterial(MaterialDto request)
        {
            Material material = _mapper.Map<Material>(request);
            var LabelExiste = await _materialRepository.GetMaterialByName(request.Label);
            if (LabelExiste != null)
                throw new ArgumentException("L'action a échoué: la matériel existe déjà");

            var materialCreated = await _materialRepository
                .CreateElementAsync(material)
                .ConfigureAwait(false);
            return _mapper.Map<MaterialDto>(materialCreated);
        }

        /// <summary>
        /// delete material by id
        /// </summary>
        /// <param name="materilId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<MaterialDto> DeleteMaterial(int materilId)
        {
            var material = await _materialRepository.GetByKeys(materilId).ConfigureAwait(false);
            if (material == null)
                throw new ArgumentException("L'action a échoué: la matériel n'existe pas");

            var materialDelete = await _materialRepository
                .DeleteElementAsync(material)
                .ConfigureAwait(false);
            return _mapper.Map<MaterialDto>(materialDelete);
        }
    }
}
