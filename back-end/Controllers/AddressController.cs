using Entity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Adress;
using Service.Interface.User;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = RoleString.User)]
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        /// add addresse <summary>
        /// </summary>
        /// <param name="commentsDto"></param>
        /// <returns></returns>
        [HttpPost("create")]
        [ProducesResponseType(typeof(ReadAddress), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult<ReadAddress>> CreateAddress(AddAddress request)
        {
            try
            {
                ReadAddress result = await _addressService.CreateAddress(request);
                string message = "l'adresse a été ajoutée avec succès";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        ///  get addresse for user <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet("user")]
        [ProducesResponseType(typeof(ReadAddress), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> GetAddressesOfAUser()
        {
            try
            {
                IEnumerable<ReadAddress> result = await _addressService.GetAddressesOfAUser();
                string message = "les adresses de cet utilisateur";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// update addresse <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <param name="adressId"></param>
        /// <returns></returns>
        [HttpPut("update/{addressId}")]
        [ProducesResponseType(typeof(ReadAddress), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> UpdateAddress(PutAddress request, int adressId)
        {
            try
            {
                ReadAddress result = await _addressService.UpdateAddress(request, adressId);
                string message = "la modification  de l'adresse a réussi";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// delete address <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(typeof(ReadAddress), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> DeleteAddress(int id)
        {
            try
            {
                var result = await _addressService.DeleteAddress(id);
                string message = "la suppression de l'adresse a réussi";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
