using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Repositories
{
    public interface ICategoryRepository
    {
        public ApplicationDbContext _context { get; set; }
        public Task<List<CategoryModel>> GetAllCategoriesAsync();
        public Task<List<CategoryModel>> GetAllCategoriesWithInclude();

        public Task<CategoryModel> GetCategoryById(int categoryId);

        public Task<CategoryModel> AddCategoryAsync(CategoryModel newCategory);

        public Task<bool> DeleteCategoryAsync(int Id);

        public Task<CategoryModel> UpdateCategoryAsync(CategoryModel newCategory);

        public Task<List<CategoryModel>> SearchCategoriesAsync(string searchTerm);
    }

}
