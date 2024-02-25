using Entity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Cart;
using Service.Interface.Order;

namespace back_end.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = RoleString.User)]
    public class CartController : Controller
    {

        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        /// create to cart <summary>
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost("create")]
        [ProducesResponseType(typeof(IEnumerable<Task<CartItem>>), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> CreateCart(AddCart request)
        {
            try
            {
                var result = await _cartService.CreateCart(request).ConfigureAwait(false);
                string message = "l'article a été ajouté avec succès dans le panier";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// get cards <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<CartItem>), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> GetCartItemsByUserId()
        {
            try
            {
                var result = await _cartService.GetCartItemsByUserId().ConfigureAwait(false);
                string message = "la liste des artilces dans le panier";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// update cart <summary>
        /// </summary>
        /// <param name=""></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("update")]
        [ProducesResponseType(typeof(IEnumerable<CartItem>), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> UpdateItem(UpdateCart request)
        {
            try
            {
                var result = await _cartService.UpdateCart(request);
                string message = "La quantité a été modifiée avec succèss";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// delete item in the cards <summary>
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(typeof(IEnumerable<CartItem>), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> DeleteItemInTheCart(int id)
        {
            try
            {
                var result = await _cartService.DeleteItemInTheCart(id).ConfigureAwait(false);
                string message = "l'article a été supprime avec succès";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
