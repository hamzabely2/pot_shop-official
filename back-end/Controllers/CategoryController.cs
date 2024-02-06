﻿using Entity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DetailsItem;
using Service.Interface.Item;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly IDetailsItemService _categoryService;

        public CategoryController(IDetailsItemService categoryService)
        {
            _categoryService = categoryService;
        }

        /// get all categories <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        [Authorize(Roles = RoleString.Admin)]
        [ProducesResponseType(typeof(CategoryDto), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> GetAllCategory()
        {
            try
            {
                var result = await _categoryService.GetAllCategory();
                string message = "la liste des catégories";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        /// <summary>
        /// create category
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("create")]
        [Authorize(Roles = RoleString.Admin)]
        [ProducesResponseType(typeof(CategoryDto), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> CreateCategory(CategoryDto request)
        {
            try
            {
                var result = await _categoryService.CreateCategory(request);
                string message = "la catégorie  a été ajoute avec succès";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        /// <summary>
        /// delete category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpDelete("delete/{categoryId}")]
        [Authorize(Roles = RoleString.Admin)]
        [ProducesResponseType(typeof(CategoryDto), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 500)]
        [ProducesResponseType(typeof(StatusCodeResult), 400)]
        public async Task<ActionResult> DeleteCategory(int categoryId)
        {
            try
            {
                var result = await _categoryService.DeleteCategory(categoryId);
                string message = "la catégorie  a été supprime avec succès";
                return Ok(new { message, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
