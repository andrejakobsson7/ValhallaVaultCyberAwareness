using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public interface ISubCategoryService
    {
        public HttpClient Client { get; set; }

        public Task<SubCategoryModel> GetSubCategoryById(int subCategoryId);
    }
}
