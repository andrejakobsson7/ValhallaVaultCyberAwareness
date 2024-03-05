using Microsoft.AspNetCore.Mvc;
using ValhallaVaultCyberAwareness.Domain.Models;
using ValhallaVaultCyberAwareness.Repositories;

namespace ValhallaVaultCyberAwareness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryRepository _categoryRepo;

        public CategoryController(CategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryModel>>> GetAllCategories()
        {
            var categories = await _categoryRepo.GetAllCategoriesWithInclude();

            if (categories != null)
            {
                return Ok(categories);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryModel>> UpdateCategory(int id, CategoryModel category)
        {
            var cateogryToUpdate = _categoryRepo.UpdateCategoryAsync(id, category);

            if (cateogryToUpdate != null)
            {
                return Ok(cateogryToUpdate);

            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryModel>> DeleteCategory(int id)
        {
            var categoryToDelete = _categoryRepo.DeleteCategoryAsync(id);

            if (categoryToDelete != null)
            {
                return Ok(categoryToDelete);
            }
            return BadRequest();
        }
    }
}
