using Entity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Cart;
using Model.Order;
using Org.BouncyCastle.Asn1.Ocsp;
using Service.Interface.Order;
using Service.Order;

namespace back_end.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = RoleString.User)]
    public class OrderController : Controller
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// create to order <summary>
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost("create")]
        [ProducesResponseType(typeof(IEnumerable<ReadOrder>), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> CreateOrderFromCart(AddOrder request)
        {
            
            try
            {
                ReadOrder result = await _orderService.CreateOrderFromCart(request).ConfigureAwait(false);
                string message = "la commande a été cree avec succès";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        /// get order by user <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<ReadOrder>), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> GetOrdersByUserId()
        {
            try
            {
                var result = await _orderService.GetOrdersByUserId().ConfigureAwait(false);
                string message = "la liste des commandes";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// delete order<summary>
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete")]
        [ProducesResponseType(typeof(IEnumerable<CartItem>), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> DeleteOrder(DeleteOrder request)
        {
            try
            {
                var result = await _orderService.DeleteOrder(request).ConfigureAwait(false);
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
