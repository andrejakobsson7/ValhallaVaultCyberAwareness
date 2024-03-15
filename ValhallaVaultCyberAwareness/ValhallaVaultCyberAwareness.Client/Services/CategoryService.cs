using Newtonsoft.Json;
using System.Net.Http.Json;
using ValhallaVaultCyberAwareness.Client.ViewModels;
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

		public async Task<List<CategoryScoreViewModel>> GetAllCategoriesWithUserScores(string userId)
		{
			var apiResponse = await Client.GetAsync($"api/category/{userId}");
			if (apiResponse.IsSuccessStatusCode)
			{
				string jsonCategories = await apiResponse.Content.ReadAsStringAsync();
				List<CategoryModel>? categories = JsonConvert.DeserializeObject<List<CategoryModel>>(jsonCategories);
				if (categories == null)
				{
					throw new JsonException();
				}
				else
				{
					List<CategoryScoreViewModel> categoryScores = categories.Select(c => new CategoryScoreViewModel(c)).ToList();
					return categoryScores;
				}
			}
			throw new HttpRequestException();
		}

		public async Task<CategoryScoreViewModel> GetCategoryWithUserScore(int categoryId, string userId)
		{
			var apiResponse = await Client.GetAsync($"api/category/{categoryId}/{userId}");
			if (apiResponse.IsSuccessStatusCode)
			{
				string jsonCategory = await apiResponse.Content.ReadAsStringAsync();
				CategoryModel? category = JsonConvert.DeserializeObject<CategoryModel>(jsonCategory);
				if (category == null)
				{
					throw new JsonException();
				}
				else
				{
					CategoryScoreViewModel categoryScore = new CategoryScoreViewModel(category);
					return categoryScore;
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
