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

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetAllCategoryScoresByUserIdAsync(string userId)
        {
            var categoryScores = await _categoryRepo.GetAllCategoriesWithUserScores(userId);
            if (categoryScores != null)
            {
                List<CategoryScoreApiModel> apiCategoryScores = categoryScores.Select(s => new CategoryScoreApiModel(s)).ToList();

                var categoryScoresJson = JsonSerializer.Serialize(apiCategoryScores, _jsonSerializerOptions);
                return Ok(categoryScoresJson);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("{categoryId}/{userId}")]
        public async Task<IActionResult> GetCategoryWithUserScoresByUserIdAsync(int categoryId, string userId)
        {
            var categoryScore = await _categoryRepo.GetCategoryWithUserScoresByUserIdAsync(categoryId, userId);
            if (categoryScore != null)
            {
                CategoryScoreApiModel apiCategoryScore = new CategoryScoreApiModel(categoryScore);
                var categoryScoresJson = JsonSerializer.Serialize(apiCategoryScore, _jsonSerializerOptions);
                return Ok(categoryScoresJson);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryModel newCategory)
        {
            var category = await _categoryRepo.AddCategoryAsync(newCategory);
            if (category != null)
            {
                return Ok(category);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<CategoryModel>> UpdateCategory(CategoryModel category)
        {
            var categoryToUpdate = await _categoryRepo.UpdateCategoryAsync(category);

            if (categoryToUpdate != null)
            {
                return Ok(categoryToUpdate);

            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<CategoryModel>> DeleteCategory(int id)
        {
            var categoryToDelete = await _categoryRepo.DeleteCategoryAsync(id);

            if (categoryToDelete != false)
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

        //Temporary model that is returned from the API to enable that the client service can get access to navigation properties, since these are not serialized otherwise.

        public class CategoryScoreApiModel
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;
            public string? Description { get; set; }
            public List<SegmentModel> Segments { get; set; } = new();
            public List<SubCategoryModel> SubCategories { get; set; } = new();

            public List<QuestionModel> Questions { get; set; } = new();
            public List<AnswerModel> Answers { get; set; } = new();
            public List<UserAnswers> UserAnswers { get; set; } = new();

            public CategoryScoreApiModel(CategoryModel category)
            {
                Id = category.Id;
                Name = category.Name;
                Description = category.Description;
                for (int i = 0; i < category.Segments.Count; i++)
                {
                    Segments.Add(category.Segments[i]);
                    foreach (var subCategory in Segments[i].SubCategories)
                    {
                        SubCategories.Add(subCategory);
                        foreach (var question in subCategory.Questions)
                        {
                            Questions.Add(question);
                            foreach (var answer in question.Answers)
                            {
                                Answers.Add(answer);
                                foreach (var userAnswer in answer.UserAnswers)
                                {
                                    UserAnswers.Add(userAnswer);
                                }
                            }
                        }
                    }
                }

            }
        }
    }
}
