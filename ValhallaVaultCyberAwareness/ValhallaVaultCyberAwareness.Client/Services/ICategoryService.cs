using ValhallaVaultCyberAwareness.Client.ViewModels;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public interface ICategoryService
    {
        public HttpClient Client { get; set; }
        public Task<List<CategoryModel>> GetAllCategoriesAsync();
        public Task<CategoryModel> GetCategoryByIdAsync(int categoryId);
        /// <summary>
        /// Method to retrieve all categories
        /// </summary>
        /// <param name="segmentId"></param>
        /// <param name="userId"></param>
        /// <returns>All categories converted as viewmodels that holds all neccessary information for making decisions in the UI.</returns>
        /// <exception cref="JsonException"></exception>
        /// <exception cref="HttpRequestException"></exception>
        public Task<List<CategoryScoreViewModel>> GetAllCategoriesWithUserScores(string userId);
        public Task<CategoryScoreViewModel> GetCategoryWithUserScore(int categoryId, string userId);
        public Task<bool> AddCategoryAsync(CategoryModel newCategory);

        public Task<bool> RemoveCategoryAsync(int categoryId);
        public Task<bool> UpdateCategoryAsync(CategoryModel category);

    }
}
