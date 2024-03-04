using Newtonsoft.Json;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public class CategoryService : ICategoryService
    {
        public HttpClient Client { get; set; } = new()
        {
            BaseAddress = new Uri("https://localhost:7107/Category/")
        };
        public async Task<List<CategoryModel>> GetAllCategoriesAsync()
        {
            var apiResponse = await Client.GetAsync(Client.BaseAddress);
            if (apiResponse.IsSuccessStatusCode)
            {
                string jsonCategories = await apiResponse.Content.ReadAsStringAsync();
                List<CategoryModel> allCategories = JsonConvert.DeserializeObject<List<CategoryModel>>(jsonCategories);
                if (allCategories == null)
                {
                    throw new JsonException();
                }
                else
                {
                    return allCategories;
                }
            }
            throw new HttpRequestException();
        }

        public async Task<CategoryModel> GetCategoryByIdAsync(int categoryId)
        {
            var apiResponse = await Client.GetAsync($"{categoryId}");
            if (apiResponse.IsSuccessStatusCode)
            {
                string jsonCategory = await apiResponse.Content.ReadAsStringAsync();
                CategoryModel category = JsonConvert.DeserializeObject<CategoryModel>(jsonCategory);
                if (category == null)
                {
                    throw new JsonException();
                }
                else
                {
                    return category;
                }
            }
            throw new HttpRequestException();
        }
    }
}
