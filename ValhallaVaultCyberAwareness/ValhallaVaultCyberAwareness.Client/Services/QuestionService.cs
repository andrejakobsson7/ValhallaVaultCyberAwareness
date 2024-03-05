using Newtonsoft.Json;
using System.Net.Http.Json;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public class QuestionService : IQuestionService
    {
        public HttpClient Client { get; set; } = new()
        {
            BaseAddress = new Uri("https://localhost:7107/Question/")
        };

        public async Task<List<QuestionModel>> GetAllQuestionsBySubCategoryId(int subCategoryId)
        {
            var apiResponse = await Client.GetAsync($"/api/Question/{subCategoryId}/");
            if (apiResponse.IsSuccessStatusCode)
            {
                string jsonQuestions = await apiResponse.Content.ReadAsStringAsync();
                List<QuestionModel> allQuestions = JsonConvert.DeserializeObject<List<QuestionModel>>(jsonQuestions);
                if (allQuestions == null)
                {
                    throw new JsonException();
                }
                else
                {
                    return allQuestions;
                }
            }
            throw new HttpRequestException();
        }
        public async Task<QuestionModel> GetQuestionByIdAsync(int questionId)
        {
            var apiResponse = await Client.GetAsync($"/api/Question/{questionId}/");
            if (apiResponse.IsSuccessStatusCode)
            {
                string jsonQuestion = await apiResponse.Content.ReadAsStringAsync();
                QuestionModel question = JsonConvert.DeserializeObject<QuestionModel>(jsonQuestion);
                if (question == null)
                {
                    throw new JsonException();
                }
                else
                {
                    return question;
                }
            }
            throw new HttpRequestException();
        }

        public async Task<bool> AddQuestionAsync(QuestionModel newQuestion)
        {
            var apiResponse = await Client.PostAsJsonAsync<QuestionModel>("/api/Question/", newQuestion);
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveQuestionAsync(int questionId)
        {
            var apiResponse = await Client.DeleteAsync($"api/Question/{questionId}/");
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateQuestionAsync(QuestionModel question)
        {
            var apiResponse = await Client.PutAsJsonAsync<QuestionModel>($"/api/Question/{question.Id}", question);
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }

}
