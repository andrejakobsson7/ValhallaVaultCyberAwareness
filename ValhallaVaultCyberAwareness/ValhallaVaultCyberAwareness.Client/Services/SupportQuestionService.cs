using Newtonsoft.Json;
using System.Net.Http.Json;
using ValhallaVaultCyberAwareness.Domain.Models.Support;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public class SupportQuestionService : ISupportQuestionService
    {
        public HttpClient Client { get; set; }

        public SupportQuestionService(HttpClient client)
        {
            Client = client;
        }

        public async Task<List<SupportQuestionModel>> GetAllSupportQuestionsAsync()
        {
            var apiResponse = await Client.GetAsync("api/supportquestion/");
            if (apiResponse.IsSuccessStatusCode)
            {
                string jsonSupportQuestions = await apiResponse.Content.ReadAsStringAsync();
                List<SupportQuestionModel>? allSupportQuestions = JsonConvert.DeserializeObject<List<SupportQuestionModel>>(jsonSupportQuestions);
                if (allSupportQuestions == null)
                {
                    throw new JsonException();
                }
                else
                {
                    return allSupportQuestions;
                }
            }
            throw new HttpRequestException();
        }

        public async Task<bool> AddSupportQuestionAsync(SupportQuestionModel newSupportQuestion)
        {
            var apiResponse = await Client.PostAsJsonAsync("/api/supportquestion/", newSupportQuestion);
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateSupportQuestionAsync(SupportQuestionModel supportQuestion)
        {
            var apiResponse = await Client.PutAsJsonAsync($"/api/supportquestion/{supportQuestion.Id}/", supportQuestion);
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveSupportQuestionAsync(int supportQuestionId)
        {
            var apiResponse = await Client.DeleteAsync($"api/supportquestion/{supportQuestionId}/");
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
