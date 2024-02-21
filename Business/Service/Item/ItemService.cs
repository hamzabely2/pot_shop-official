using AutoMapper;
using Context.Interface;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Model.DetailsItem;
using Model.Item;
using Repository.Interface.Item;
using Service.Interface.Item;

namespace Service.Item
{
    public class ItemService : IItemService
    {
        private readonly ItemIRepository _itemRepository;
        private readonly ImageIRepository _imageRepository;
        private readonly ColorIRepository _colorRepository;
        private readonly IColorItemRepository _colorItemRepository;
        private readonly IDetailsItemService _detailsItemIService;
        private readonly IMapper _mapper;
        public ItemService(
            ImageIRepository imageRepository,
            PotShopIDbContext _idbcontext,
            ItemIRepository itemRepository,
            ColorIRepository colorRepository,
            IDetailsItemService detailsItemIService,
            IColorItemRepository colorItemRepository,
            IMapper mapper
        )
        {
            _itemRepository = itemRepository;
            _detailsItemIService = detailsItemIService;
            _mapper = mapper;
            _imageRepository = imageRepository;
            _colorRepository = colorRepository;
            _colorItemRepository = colorItemRepository;
        }

        /// Get item by id <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<ReadItem> GetItemById(int itemId)
        {
            var item = await _itemRepository.GetItemByIdWithDetails(itemId).ConfigureAwait(false);

            if (item == null)
            {
                throw new ArgumentException("L'articles n'a pas ete trouve non trouvé.");
            }
            var images = await _itemRepository.GetAllImagesForItem(itemId).ConfigureAwait(false);

            if (images.Any())
            {
                item.Images.AddRange(images);
            }
            var readItem = _mapper.Map<ReadItem>(item);

            return readItem;
        }

        /// Get list items> <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<List<ReadItem>> GetListItem()
        {
            var items = await _itemRepository.GetAllAsync().ConfigureAwait(false);

            if (items == null)
            {
                throw new ArgumentException("Aucun article trouvé.");
            }

            var itemDetailsDtos = new List<ReadItem>();

            foreach (var item in items)
            {
                var readItem = await GetItemDetails(item.Id).ConfigureAwait(false);

                itemDetailsDtos.Add(readItem);
            }

            return itemDetailsDtos;
        }

        /// Create item <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        public async Task<ReadItem> CreateItem(ItemAdd request)
        {
            var memoryStream = new MemoryStream();

            var existingItem = await _itemRepository
                .GetItemByName(request.Name)
                .ConfigureAwait(false);
            if (existingItem != null)
            {
                throw new ArgumentException("L'action a échoué : Le nom de l'article existe déjà.");
            }

            if (request.CategoryId == 0 || request.MaterialId == 0)
            {
                throw new ArgumentException(
                    "L'action a échoué : Les détails de l'article n'ont pas été précisés."
                );
            }

            if (request.ImagesData != null)
            {
                //await request.ImagesData.OpenReadStream().CopyToAsync(memoryStream);
            }


            var newItem = _mapper.Map<Entity.Model.Item>(request);
            newItem.CreatedDate = DateTime.Now;
            newItem.UpdateDate = DateTime.Now;
            await _itemRepository.CreateElementAsync(newItem).ConfigureAwait(false);

            var image = new Image { ItemId = newItem.Id, ImageData = memoryStream.ToArray() };

            var color = new ColorItem { ItemId = newItem.Id, ColorId = request.ColorId };

            await _imageRepository.CreateElementAsync(image).ConfigureAwait(false);
            await _colorItemRepository.CreateElementAsync(color).ConfigureAwait(false);
            var createdItem = await GetItemDetails(newItem.Id).ConfigureAwait(false);

            return createdItem;
        }

        /// Update item <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        ///
        public async Task<ReadItem> UpdateItem(int itemId, ItemUpdate request)
        {
            var existingItem = await _itemRepository.GetByKeys(itemId).ConfigureAwait(false);

            if (existingItem == null)
            {
                throw new ArgumentException("L'article n'a pas été trouvé");
            }

            _mapper.Map(request, existingItem);
            existingItem.UpdateDate = DateTime.UtcNow;

            await _itemRepository.UpdateElementAsync(existingItem).ConfigureAwait(false);

            var updatedItem = await GetItemDetails(itemId).ConfigureAwait(false);

            return updatedItem;
        }

        /// Delete item with image <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<string> DeleteItem(int itemId)
        {
            var existingItem = await _itemRepository.GetByKeys(itemId).ConfigureAwait(false);

            if (existingItem == null)
            {
                throw new ArgumentException("L'article n'a pas été trouvé");
            }

            await _imageRepository.DeleteAllImagesForItem(itemId).ConfigureAwait(false);
            await _itemRepository.DeleteElementAsync(existingItem).ConfigureAwait(false);

            var item = await _itemRepository.GetByKeys(itemId).ConfigureAwait(false);

            if (item == null)
            {
                return "artciles supprime avec succès et les images associées et ses coleaur";
            }
            else
            {
                throw new ArgumentException("L'action a échoué");
            }
        }

        /// <summary>
        /// get item with details
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<ReadItem> GetItemDetails(int itemId)
        {
            var item = await _itemRepository.GetItemByIdWithDetails(itemId).ConfigureAwait(false);

            if (item == null)
            {
                throw new ArgumentException("L'article n'a pas été trouvé.");
            }

            var images = await _itemRepository.GetAllImagesForItem(itemId).ConfigureAwait(false);
            item.Images.AddRange(images);

            var colors = await _itemRepository.GetAllColorsForItem(itemId).ConfigureAwait(false);

            // Mappez votre objet Item vers ReadItem en utilisant AutoMapper
            var readItem = _mapper.Map<ReadItem>(item);

            // Mappez les couleurs séparément
            readItem.Colors = _mapper.Map<List<ColorDto>>(colors);

            return readItem;
        }

    }
}
