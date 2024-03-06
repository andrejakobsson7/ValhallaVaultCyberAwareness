using Microsoft.AspNetCore.Mvc;
using ValhallaVaultCyberAwareness.Domain.Models;
using ValhallaVaultCyberAwareness.Repositories;

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
        [Route("{segmentId}")]
        public async Task<ActionResult<SubCategoryModel>> GetSubCategoriesBySegmentId(int segmentId)
        {
            var subCategories = await _subCategoryRepo.GetSubCategoriesBySegmentId(segmentId);

            if (subCategories != null)
            {
                return Ok(subCategories);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<SubCategoryModel>> AddSubCategory(SubCategoryModel newSubCategory)
        {
            var subCategoryToAdd = await _subCategoryRepo.AddSubCategory(newSubCategory);

            if (subCategoryToAdd != null)
            {
                return Ok(subCategoryToAdd);
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<SubCategoryModel>> UpdateSubCategory(SubCategoryModel subCategory)
        {
            var updatedSubCategory = await _subCategoryRepo.UpdateSubCategoryAsync(subCategory);

            if (updatedSubCategory != null)
            {
                return Ok(updatedSubCategory);

            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<SubCategoryModel>> DeleteSubCategory(int id)
        {
            var subCategoryToDelete = await _subCategoryRepo.DeleteSubCategoryAsync(id);

            if (subCategoryToDelete != false)
            {
                return Ok(subCategoryToDelete);
            }
            return BadRequest();
        }
    }
}