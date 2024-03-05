using Newtonsoft.Json;
using System.Net.Http.Json;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        public HttpClient Client { get; set; } = new()
        {
            BaseAddress = new Uri("https://localhost:7107/SubCategory/")
        };

        public async Task<SubCategoryModel> GetSubCategoryByIdAsync(int subCategoryId)
        {
            var apiResponse = await Client.GetAsync($"{subCategoryId}");
            if (apiResponse.IsSuccessStatusCode)
            {
                string jsonSubCategory = await apiResponse.Content.ReadAsStringAsync();
                SubCategoryModel subCategory = JsonConvert.DeserializeObject<SubCategoryModel>(jsonSubCategory);
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
            var apiResponse = await Client.PostAsJsonAsync<SubCategoryModel>(Client.BaseAddress, newSubCategory);
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveSubCategoryAsync(int subCategoryId)
        {
            var apiResponse = await Client.DeleteAsync($"{subCategoryId}");
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateSubCategoryAsync(SubCategoryModel subCategory)
        {
            var apiResponse = await Client.PutAsJsonAsync<SubCategoryModel>(Client.BaseAddress, subCategory);
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
