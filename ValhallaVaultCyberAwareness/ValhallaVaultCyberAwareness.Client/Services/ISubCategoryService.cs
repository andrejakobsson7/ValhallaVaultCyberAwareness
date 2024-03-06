using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public interface ISubCategoryService
    {
        public HttpClient Client { get; set; }

        public Task<List<SubCategoryModel>> GetSubCategoriesBySegmentIdAsync(int subCategoryId);
        public Task<bool> AddSubCategoryAsync(SubCategoryModel newSubCategory);

        public Task<bool> RemoveSubCategoryAsync(int subCategoryId);
        public Task<bool> UpdateSubCategoryAsync(SubCategoryModel subCategory);
    }
}
