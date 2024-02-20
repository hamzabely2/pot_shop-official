using Entity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Item;
using Service.Interface.Item;

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
                _logger.LogInformation("la liste des artciles", result);
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
        public async Task<ActionResult> CreateItem(ItemAdd request)
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
        //[Authorize(Roles = RoleString.Admin)]
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
        [HttpDelete("delete/{itemId}")]
       //[Authorize(Roles = RoleString.Admin)]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> DeleteItem(int itemId)
        {
            try
            {
                var result = await _itemService.DeleteItem(itemId);
                string message = "article a été supprime avec succès";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
