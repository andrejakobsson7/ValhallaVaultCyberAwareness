using Newtonsoft.Json;
using System.Net.Http.Json;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public class CategoryService : ICategoryService
    {
        public HttpClient Client { get; set; }
        public CategoryService(HttpClient client)
        {
            Client = client;
        }
        public async Task<List<CategoryModel>> GetAllCategoriesAsync()
        {
            var apiResponse = await Client.GetAsync("api/category/");
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
            var apiResponse = await Client.GetAsync($"/api/category/{categoryId}/");
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

        public async Task<bool> AddCategoryAsync(CategoryModel newCategory)
        {
            var apiResponse = await Client.PostAsJsonAsync("/api/category/", newCategory);
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveCategoryAsync(int categoryId)
        {
            var apiResponse = await Client.DeleteAsync($"/api/Category/{categoryId}/");
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateCategoryAsync(CategoryModel category)
        {
            var apiResponse = await Client.PutAsJsonAsync($"/api/Category/{category.Id}", category);
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
