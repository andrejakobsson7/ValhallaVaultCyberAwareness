using System.Net.Http.Json;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public class AnswerService : IAnswerService
    {
        public HttpClient Client { get; set; }
        public AnswerService(HttpClient client)
        {
            Client = client;
        }
        public async Task<bool> AddAnswerAsync(AnswerModel newAnswer)
        {
            var apiResponse = await Client.PostAsJsonAsync<AnswerModel>("api/Answer/", newAnswer);
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveAnswerAsync(int answerId)
        {
            var apiResponse = await Client.DeleteAsync($"/api/Answer/{answerId}/");
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateAnswerAsync(AnswerModel answer)
        {
            var apiResponse = await Client.PutAsJsonAsync<AnswerModel>($"/api/Answer/{answer.Id}", answer);
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
