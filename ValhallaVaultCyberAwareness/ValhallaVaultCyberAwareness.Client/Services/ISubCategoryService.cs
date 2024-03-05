using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public interface ISubCategoryService
    {
        public HttpClient Client { get; set; }

        public Task<SubCategoryModel> GetSubCategoryByIdAsync(int subCategoryId);
        public Task<bool> AddSubCategoryAsync(SubCategoryModel newSubCategory);

        public Task<bool> RemoveSubCategoryAsync(int subCategoryId);
        public Task<bool> UpdateSubCategoryAsync(SubCategoryModel subCategory);
    }
}
