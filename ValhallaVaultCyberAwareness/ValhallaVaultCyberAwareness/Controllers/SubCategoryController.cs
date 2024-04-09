using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Domain.Models;
using ValhallaVaultCyberAwareness.Repositories.Interfaces;

namespace ValhallaVaultCyberAwareness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        public ISubCategoryRepository _subCategoryRepo;

        public SubCategoryController(ISubCategoryRepository subCategoryRepo)
        {
            _subCategoryRepo = subCategoryRepo;
        }

        [HttpGet]
        [Route("{subCategoryId}")]
        public async Task<IActionResult> GetSubCategoryById(int subCategoryId)
        {
            var subCategory = await _subCategoryRepo.GetSubCategoryByIdAsync(subCategoryId);

            if (subCategory != null)
            {
                return Ok(subCategory);
            }

            return NotFound("Subcategory does not exist.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubcategories()
        {
            var subCategories = await _subCategoryRepo.GetSubCategoriesAsync();

            if (subCategories != null)
            {
                return Ok(subCategories);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<SubCategoryModel>> AddSubCategory(SubCategoryModel newSubCategory)
        {
            try
            {
                var subCategoryToAdd = await _subCategoryRepo.AddSubCategory(newSubCategory);
                return Ok(subCategoryToAdd);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<SubCategoryModel>> UpdateSubCategory(SubCategoryModel subCategory)
        {
            try
            {
                var updatedSubCategory = await _subCategoryRepo.UpdateSubCategoryAsync(subCategory);
                return Ok(updatedSubCategory);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<SubCategoryModel>> DeleteSubCategory(int id)
        {
            try
            {
                var subCategoryToDelete = await _subCategoryRepo.DeleteSubCategoryAsync(id);
                return Ok("Sub category was successfully deleted.");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }
    }
}