using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Repositories.Interfaces
{
    public interface ISubCategoryRepository
    {
        public ApplicationDbContext _context { get; set; }
        public Task<List<SubCategoryModel>> GetSubCategoriesAsync();
        public Task<List<SubCategoryModel>> GetSubCategoriesWithIncludeAsync();
        public Task<List<SubCategoryModel>> GetSubCategoriesBySegmentId(int segmentId);
        public Task<SubCategoryModel> AddSubCategory(SubCategoryModel newSubCategory);
        public Task<bool> DeleteSubCategoryAsync(int Id);
        public Task<SubCategoryModel> UpdateSubCategoryAsync(SubCategoryModel newSubCategory);


    }
}
