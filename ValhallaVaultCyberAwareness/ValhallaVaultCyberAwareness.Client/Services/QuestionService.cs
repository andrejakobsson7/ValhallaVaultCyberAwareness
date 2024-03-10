using Newtonsoft.Json;
using System.Net.Http.Json;
using ValhallaVaultCyberAwareness.Client.ViewModels;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public class QuestionService : IQuestionService
    {
        public HttpClient Client { get; set; }
        public QuestionService(HttpClient client)
        {
            Client = client;
        }

        public async Task<List<QuestionModel>> GetQuestionsBySubCategoryId(int subCategoryId)
        {
            var apiResponse = await Client.GetAsync($"/api/Question/{subCategoryId}/");
            if (apiResponse.IsSuccessStatusCode)
            {
                string jsonQuestions = await apiResponse.Content.ReadAsStringAsync();
                List<QuestionModel>? allQuestions = JsonConvert.DeserializeObject<List<QuestionModel>>(jsonQuestions);
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

        public async Task<List<QuestionAnswerViewModel>> ImprovedGetQuestionsBySubCategoryId(int subCategoryId)
        {
            var apiResponse = await Client.GetAsync($"/api/Question/{subCategoryId}/");
            if (apiResponse.IsSuccessStatusCode)
            {
                string jsonQuestions = await apiResponse.Content.ReadAsStringAsync();
                List<QuestionModel>? allQuestions = JsonConvert.DeserializeObject<List<QuestionModel>>(jsonQuestions);
                if (allQuestions == null)
                {
                    throw new JsonException();
                }
                else
                {
                    //The following projects the database model to a viewmodel that holds all relevant information first hand.
                    List<QuestionAnswerViewModel> allQuestionAnswers = allQuestions.Select(q => new QuestionAnswerViewModel(q)).ToList();
                    return allQuestionAnswers;
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
                QuestionModel? question = JsonConvert.DeserializeObject<QuestionModel>(jsonQuestion);
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

        public async Task<QuestionModel> AddQuestionAsync(QuestionModel newQuestion)
        {
            var apiResponse = await Client.PostAsJsonAsync("/api/question/", newQuestion);
            if (apiResponse.IsSuccessStatusCode)
            {
                string jsonQuestion = await apiResponse.Content.ReadAsStringAsync();
                QuestionModel? question = JsonConvert.DeserializeObject<QuestionModel>(jsonQuestion);
                return question;
            }
            throw new HttpRequestException();
        }

        public async Task<bool> RemoveQuestionAsync(int questionId)
        {
            var apiResponse = await Client.DeleteAsync($"api/question/{questionId}/");
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateQuestionAsync(QuestionModel question)
        {
            var apiResponse = await Client.PutAsJsonAsync($"/api/question/{question.Id}", question);
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }


    }

}
