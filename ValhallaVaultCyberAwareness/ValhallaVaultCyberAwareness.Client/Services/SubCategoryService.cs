using Newtonsoft.Json;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        public HttpClient Client { get; set; } = new()
        {
            BaseAddress = new Uri("https://localhost:7107/SubCategory/")
        };

        public async Task<SubCategoryModel> GetSubCategoryById(int subCategoryId)
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
    }
}
