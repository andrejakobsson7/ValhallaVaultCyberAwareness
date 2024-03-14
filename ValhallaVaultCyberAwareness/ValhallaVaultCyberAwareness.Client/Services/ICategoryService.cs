using ValhallaVaultCyberAwareness.Client.ViewModels;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public interface ICategoryService
    {
        public HttpClient Client { get; set; }
        public Task<List<CategoryModel>> GetAllCategoriesAsync();
        public Task<CategoryModel> GetCategoryByIdAsync(int categoryId);
        public Task<List<CategoryScoreViewModel>> GetAllCategoriesWithUserScores(string userId);
        public Task<bool> AddCategoryAsync(CategoryModel newCategory);

        public Task<bool> RemoveCategoryAsync(int categoryId);
        public Task<bool> UpdateCategoryAsync(CategoryModel category);

    }
}
