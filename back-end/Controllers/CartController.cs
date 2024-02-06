﻿using Entity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Cart;
using Model.Item;
using Org.BouncyCastle.Asn1.Ocsp;
using Service.Interface.Order;
using Service.Order;

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


        /// delete item in the cards <summary>
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{itemId}")]
        [ProducesResponseType(typeof(IEnumerable<CartItem>), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> DeleteItemInTheCart(int itemId)
        {
            try
            {
                var result = await _cartService.DeleteItemInTheCart(itemId).ConfigureAwait(false);
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
