using Newtonsoft.Json;
using System.Net.Http.Json;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        public HttpClient Client { get; set; }

        public SubCategoryService(HttpClient client)
        {
            Client = client;
        }

        public async Task<List<SubCategoryModel>> GetSubCategoriesBySegmentIdAsync(int subCategoryId)
        {
            var apiResponse = await Client.GetAsync($"/api/SubCategory/{subCategoryId}/");
            if (apiResponse.IsSuccessStatusCode)
            {
                string jsonSubCategory = await apiResponse.Content.ReadAsStringAsync();
                List<SubCategoryModel> subCategories = JsonConvert.DeserializeObject<List<SubCategoryModel>>(jsonSubCategory);
                if (subCategories == null)
                {
                    throw new JsonException();
                }
                else
                {
                    return subCategories;
                }
            }
            throw new HttpRequestException();
        }

        public async Task<SubCategoryModel> GetSubCategoryById(int subCategoryId)
        {
            var apiResponse = await Client.GetAsync($"/api/subcategory/{subCategoryId}/");
            if (apiResponse.IsSuccessStatusCode)
            {
                string jsonSubCategory = await apiResponse.Content.ReadAsStringAsync();
                SubCategoryModel? subCategory = JsonConvert.DeserializeObject<SubCategoryModel>(jsonSubCategory);
                if (subCategory == null)
                {
                    throw new JsonException();
                }
                else
                {
                    return subCategory;
                }
            }
            throw new HttpRequestException();
        }

        public async Task<bool> AddSubCategoryAsync(SubCategoryModel newSubCategory)
        {
            var apiResponse = await Client.PostAsJsonAsync("/api/subcategory/", newSubCategory);
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveSubCategoryAsync(int subCategoryId)
        {
            var apiResponse = await Client.DeleteAsync($"/api/subcategory/{subCategoryId}/");
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateSubCategoryAsync(SubCategoryModel subCategory)
        {
            var apiResponse = await Client.PutAsJsonAsync($"/api/SubCategory/{subCategory.Id}/", subCategory);
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
