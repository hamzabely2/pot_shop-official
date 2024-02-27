using AutoMapper;
using Context.Interface;
using Entity.Model;
using Model.DetailsItem;
using Model.Item;
using Org.BouncyCastle.Asn1.Ocsp;
using Repository.Interface.Item;
using Service.Interface.Item;
using System.Drawing;
using System.IO;

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


        /// <summary>
        /// get item filtred
        /// </summary>
        /// <param name="colors"></param>
        /// <param name="categories"></param>
        /// <param name="materials"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>

        public async Task<List<ReadItem>> GetFilteredItems(FilteredItem request)
        {
            var items = await _itemRepository.GetAllAsync().ConfigureAwait(false);

            if (items == null)
            {
                throw new ArgumentException("Aucun article trouvé.");
            }

            var filteredItems = new List<Entity.Model.Item>();
            foreach (var item in items)
            {
                var itemDetails = await GetItemDetails(item.Id).ConfigureAwait(false);

                var matchColor = !request.colors.Any() || (itemDetails.Colors != null && itemDetails.Colors.Any(ci => request.colors.Contains(ci.Label)));
                var matchCategory = !request.categories.Any() || (itemDetails.Categories != null && request.categories.Contains(itemDetails.Categories.Label));
                var matchMaterial = !request.materials.Any() || (itemDetails.Materials != null && request.materials.Contains(itemDetails.Materials.Label));

                if (matchColor || matchCategory || matchMaterial)
                {
                    filteredItems.Add(item);
                }
            }

            var filteredItemDtos = new List<ReadItem>();

            foreach (var item in filteredItems)
            {
                var readItem = await GetItemDetails(item.Id).ConfigureAwait(false);
                filteredItemDtos.Add(readItem);
            }

            return filteredItemDtos;
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

            var readItem = await GetItemDetails(item.Id).ConfigureAwait(false);

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
                await request.ImagesData.OpenReadStream().CopyToAsync(memoryStream);
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
        public async Task<ReadItem> DeleteItem(int itemId)
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
                return _mapper.Map<ReadItem>(existingItem);
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

            var readItem = _mapper.Map<ReadItem>(item);

            readItem.Colors = _mapper.Map<List<ColorDto>>(colors);

            return readItem;
        }

        /// <summary>
        /// add image by item
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<ReadItem> AddImageByItem(AddImageByItem request)
        {
            var memoryStream = new MemoryStream();

            var item = await _itemRepository.GetItemByIdWithDetails(request.ItemId).ConfigureAwait(false);

            if (item == null)
            {
                throw new ArgumentException("L'article n'a pas été trouvé.");
            }

            if (request.ImageData != null)
            {
                await request.ImageData.OpenReadStream().CopyToAsync(memoryStream);
            }

            var image = new Image { ItemId = item.Id, ImageData = memoryStream.ToArray()};

             await _imageRepository.CreateElementAsync(image).ConfigureAwait(false);

            var exiteItem = await GetItemDetails(item.Id).ConfigureAwait(false);

            return exiteItem;

        }

        /// <summary>
        /// add color by item
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<ReadItem> AddColorByItem(AddColorByItem request)
        {
            var item = await _itemRepository.GetItemByIdWithDetails(request.ItemId).ConfigureAwait(false);

            if (item == null)
            {
                throw new ArgumentException("L'article n'a pas été trouvé.");
            }

            var existingColor = await _colorItemRepository.GetColorByItemIdAndColorId(item.Id, request.ColorId).ConfigureAwait(false);

            if (existingColor != null)
            {
                throw new ArgumentException("La couleur spécifiée est déjà associée à cet article.");
            }

            var color = new ColorItem { ItemId = item.Id, ColorId = request.ColorId };

            await _colorItemRepository.CreateElementAsync(color).ConfigureAwait(false);
            var exiteItem = await GetItemDetails(item.Id).ConfigureAwait(false);

            return exiteItem;
        }

        /// <summary>
        /// delete color by item
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<ReadItem> DeleteColorByItem(AddColorByItem request)
        {
            var item = await _itemRepository.GetItemByIdWithDetails(request.ItemId).ConfigureAwait(false);

            if (item == null)
            {
                throw new ArgumentException("L'article n'a pas été trouvé.");
            }


            await _colorItemRepository.DeleteColorByItemIdAndColorId(item.Id, request.ColorId).ConfigureAwait(false);

            var exiteItem = await GetItemDetails(item.Id).ConfigureAwait(false);

            return exiteItem;
        }

    }
}
