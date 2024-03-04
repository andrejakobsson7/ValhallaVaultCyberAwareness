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
            var apiResponse = await Client.GetAsync($"{subCategoryId}");
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
            var apiResponse = await Client.GetAsync(Client.BaseAddress);
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
            var apiResponse = await Client.PostAsJsonAsync<QuestionModel>(Client.BaseAddress, newQuestion);
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveQuestionAsync(int questionId)
        {
            var apiResponse = await Client.DeleteAsync($"{questionId}");
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateQuestionAsync(QuestionModel question)
        {
            var apiResponse = await Client.PutAsJsonAsync<QuestionModel>(Client.BaseAddress, question);
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
