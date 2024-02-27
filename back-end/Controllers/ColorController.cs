using Entity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DetailsItem;
using Service;
using Service.Interface.Item;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ColorController : Controller
    {

        private readonly IDetailsItemService _colorService;

        public ColorController(IDetailsItemService colorService)
        {
            _colorService = colorService;
        }

        /// get all colors <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(ColorDto), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> GetAllColor()
        {
            try
            {
                var result = await _colorService.GetAllColor();
                string message = "la liste des couleurs";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        /// <summary>
        /// create color
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("create")]
        [Authorize(Roles = RoleString.Admin)]
        [ProducesResponseType(typeof(ColorDto), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> CreateColor(ColorDto request)
        {
            try
            {
                var result = await _colorService.CreateColor(request);
                string message = "la couleur a été ajoute avec succès";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        /// <summary>
        /// delete color
        /// </summary>
        /// <param name="colorId"></param>
        /// <returns></returns>
        [HttpDelete("delete/{colorId}")]
        [Authorize(Roles = RoleString.Admin)]
        [ProducesResponseType(typeof(ColorDto), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> DeleteColor(int colorId)
        {
            try
            {
                var result = await _colorService.DeleteColor(colorId);
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
