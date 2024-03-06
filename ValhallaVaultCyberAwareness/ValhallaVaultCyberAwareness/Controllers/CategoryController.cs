using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using ValhallaVaultCyberAwareness.Domain.Models;
using ValhallaVaultCyberAwareness.Repositories;

namespace ValhallaVaultCyberAwareness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;
        private JsonSerializerOptions _jsonSerializerOptions = new()
        {
            ReferenceHandler = ReferenceHandler.Preserve
        };

        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepo.GetAllCategoriesWithInclude();

            if (categories != null)
            {
                //Convert to temporary api model that holds all information first hand.
                List<CategoryApiModel> apiCategories = categories.Select(c => new CategoryApiModel(c)).ToList();

                //To prevent cycles we need to serialize the object before returning it.
                var categoriesJson = JsonSerializer.Serialize(apiCategories, _jsonSerializerOptions);
                return Ok(categoriesJson);
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

        //Temporary model that is returned from the API to enable that the client service can get access to navigation properties,
        //since these are not serialized otherwise
        public class CategoryApiModel
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;
            public List<SegmentModel> Segments { get; set; } = new();
            public List<SubCategoryModel> SubCategories { get; set; } = new();

            public CategoryApiModel(CategoryModel category)
            {
                Id = category.Id;
                Name = category.Name;
                Segments = category.Segments;
                foreach (var segment in Segments)
                {
                    for (int i = 0; i < segment.SubCategories.Count; i++)
                    {
                        SubCategories.Add(segment.SubCategories[i]);
                    }
                }
            }
        }
    }
}
