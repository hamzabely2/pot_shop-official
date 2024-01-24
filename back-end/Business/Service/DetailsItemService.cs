using Context.Interface;
using Entity.Model;
using Mapper.DetailsItem;
using Model.DetailsItem;
using Repository.Interface;
using Service.Interface;

namespace Service
{
    public class DetailsItemService : DetailsItemIService
    {
        private readonly PotShopIDbContext _context;
        private readonly ColorIRepository _colorRepository;
        private readonly CategoryIRepository _categoryRepository;
        private readonly MaterialIRepository _materialRepository;



        public DetailsItemService(PotShopIDbContext context, ColorIRepository colorRepository, CategoryIRepository categoryRepository, MaterialIRepository materialRepository)
        {
            _context = context;
            _colorRepository = colorRepository;
            _categoryRepository = categoryRepository;
            _materialRepository = materialRepository;


        }

        /// <summary>
        /// adding details 
        /// </summary>
        public void AddColors()
        {
            var couleurs = new List<string>
            {
                "Rouge", "Bleu", "Vert", "Jaune", "Orange",
                "Violet", "Rose", "Gris", "Marron", "Noir", "Blanc",
            };
            foreach (var couleur in couleurs)
            {
                if (!_context.Colors.Any(c => c.Label == couleur))
                {
                    var nouvelleDonnee = new Color { Label = couleur };
                    _context.Colors.Add(nouvelleDonnee);
                }
            }
            _context.SaveChanges();
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
                throw new ArgumentException("l'action a échoué");

            List<ColorDto> colorList = new();
            foreach (Color color in colors)
            {
                colorList.Add(DatailsItemMapper.TransformExiteColor(color));
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
            var color = DatailsItemMapper.TransformCreateColor(request);
            var LabelExiste = await _colorRepository.GetColorByName(request.Label);
            if (LabelExiste != null)
                throw new ArgumentException("l'action a échoué: la couleur existe déjà");

            var colorCreated = await _colorRepository.CreateElementAsync(color).ConfigureAwait(false);
            return DatailsItemMapper.TransformExiteColor(colorCreated);

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
                throw new ArgumentException("l'action a échoué: la couleur n'existe pas");

            var colorDelete = await _colorRepository.DeleteElementAsync(color).ConfigureAwait(false);
            return DatailsItemMapper.TransformExiteColor(colorDelete);
        }



        /// <summary>
        /// adding details 
        /// </summary>
        public void AddCategories()
        {
            var categories = new List<string>
            {
                "Tagine", "Pot de conservation", "Pot de jardin"

            };

            foreach (var category in categories)
            {
                if (!_context.Categories.Any(c => c.Label == category))
                {
                    var nouvelleDonnee = new Category { Label = category };
                    _context.Categories.Add(nouvelleDonnee);
                }
            }
            _context.SaveChanges();
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
                throw new ArgumentException("l'action a échoué");

            List<CategoryDto> categoryList = new();
            foreach (Category categorie in categories)
            {
                categoryList.Add(DatailsItemMapper.TransformExiteCategory(categorie));
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
            var category = DatailsItemMapper.TransformCreateCategory(request);
            var LabelExiste = await _categoryRepository.GetCategoryByName(request.Label);
            if (LabelExiste != null)
                throw new ArgumentException("l'action a échoué: la catégorie existe déjà");

            var categoryCreated = await _categoryRepository.CreateElementAsync(category).ConfigureAwait(false);
            return DatailsItemMapper.TransformExiteCategory(categoryCreated);

        }

        /// <summary>
        /// delete category by id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<CategoryDto> DeleteCategory(int categoryId)
        {
            var category = await _categoryRepository.GetByKeys(categoryId).ConfigureAwait(false);
            if (category == null)
                throw new ArgumentException("l'action a échoué: la catégorie n'existe pas");

            var categoryDelete = await _categoryRepository.DeleteElementAsync(category).ConfigureAwait(false);
            return DatailsItemMapper.TransformExiteCategory(categoryDelete);
        }
    }
}
