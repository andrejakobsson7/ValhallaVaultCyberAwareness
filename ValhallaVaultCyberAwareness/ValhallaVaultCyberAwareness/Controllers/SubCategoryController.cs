using Microsoft.AspNetCore.Mvc;
using ValhallaVaultCyberAwareness.Domain.Models;
using ValhallaVaultCyberAwareness.Repositories;

namespace ValhallaVaultCyberAwareness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        SubCategoryRepository _subCategoryRepo;

        public SubCategoryController(SubCategoryRepository subCategoryRepo)
        {
            _subCategoryRepo = subCategoryRepo;
        }

        [HttpGet]
        public async Task<ActionResult<SubCategoryModel>> GetSubCategoryBySegmentId(int segmentId)
        {
            var subCategory = await _subCategoryRepo.GetSubCategoryBySegmentId(segmentId);

            if (subCategory != null)
            {
                return Ok(subCategory);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<QuestionModel>> AddSubCategory(SubCategoryModel newSubCategory)
        {
            var subCategoryToAdd = await _subCategoryRepo.AddSubCategory(newSubCategory);

            if (subCategoryToAdd != null)
            {
                return Ok(subCategoryToAdd);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SubCategoryModel>> UpdateSubCategory(int id, SubCategoryModel subCategory)
        {
            var updatedSubCategory = _subCategoryRepo.UpdateSubCategoryAsync(id, subCategory);

            if (updatedSubCategory != null)
            {
                return Ok(updatedSubCategory);

            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SubCategoryModel>> DeleteSubCategory(int id)
        {
            var subCategoryToDelete = _subCategoryRepo.DeleteSubCategoryAsync(id);

            if (subCategoryToDelete != null)
            {
                return Ok(subCategoryToDelete);
            }
            return BadRequest();
        }
    }
}