using Entity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DetailsItem;
using Model.Item;
using Service.Interface.Item;
using System.Collections.Generic;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : Controller
    {

        private readonly IItemService _itemService;
        private readonly ILogger<ItemController> _logger;

        public ItemController(IItemService itemService, ILogger<ItemController> logger)
        {
            _itemService = itemService;
            _logger = logger;
        }

        /// get item <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("filtered")]
        [ProducesResponseType(typeof(IEnumerable<ReadItem>), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> GetFilteredItems(FilteredItem request)
        {
            try
            {
                var result = await _itemService.GetFilteredItems(request).ConfigureAwait(false);
                string message = "article filtre";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }



        /// get list item <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<ReadItem>), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> GetListItem()
        {
            try
            {
                var result = await _itemService.GetListItem().ConfigureAwait(false);
                _logger.LogInformation("La liste des artciles", result);
                string message = "la liste des artciles";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// get item by id <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{itemId}")]
        [ProducesResponseType(typeof(IEnumerable<ReadItem>), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> GetItemById(int itemId)
        {
            try
            {
                var result = await _itemService.GetItemById(itemId).ConfigureAwait(false);
                string message = "article";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// create item <summary>
        /// </summary>
        /// <param name="itemDto"></param>
        /// <returns></returns>
        [HttpPost("create")]
        [Authorize(Roles = RoleString.Admin)]
        [ProducesResponseType(typeof(ReadItem), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> CreateItem([FromForm] ItemAdd request)
        {
            try
            {
                var result = await _itemService.CreateItem(request).ConfigureAwait(false);
                string message = "article a  été ajouté avec succès";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// update item <summary>
        /// </summary>
        /// <param name="itemDto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("update/{itemId}")]
        [Authorize(Roles = RoleString.Admin)]
        [ProducesResponseType(typeof(ReadItem), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> UpdateItem(ItemUpdate request, int itemId)
        {
            try
            {
                var result = await _itemService.UpdateItem(itemId,request);
                string message = "article a été modifie avec succès";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// delete item by id <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete/{id}")]
        [Authorize(Roles = RoleString.Admin)]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> DeleteItem(int id)
        {
            try
            {
                var result = await _itemService.DeleteItem(id);
                string message = "article a été supprime avec succès";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// add image by item <summary>
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost("create/image")]
        [Authorize(Roles = RoleString.Admin)]
        [ProducesResponseType(typeof(ReadItem), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> AddImageByItem([FromForm]  AddImageByItem request)
        {
            try
            {
                var result = await _itemService.AddImageByItem(request).ConfigureAwait(false);
                string message = "L'image a été ajoutée avec succès";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// delete image by item <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete/image")]
        [Authorize(Roles = RoleString.Admin)]
        [ProducesResponseType(typeof(ReadItem), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> DeleteColorByItem(DeleteImageByItem request)
        {
            try
            {
                var result = await _itemService.DeleteImageByItem(request);
                string message = "la couleur a été supprime avec succès";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// add color by item <summary>
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost("create/color")]
        [Authorize(Roles = RoleString.Admin)]
        [ProducesResponseType(typeof(ReadItem), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> AddColorByItem(AddColorByItem request)
        {
            try
            {
                var result = await _itemService.AddColorByItem(request).ConfigureAwait(false);
                string message = "La couleur a été ajoutée avec succès";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        /// delete color by item <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete/color")]
        [Authorize(Roles = RoleString.Admin)]
        [ProducesResponseType(typeof(ReadItem), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> DeleteColorByItem(AddColorByItem request)
        {
            try
            {
                var result = await _itemService.DeleteColorByItem(request);
                string message = "la couleur a été supprime avec succès";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
