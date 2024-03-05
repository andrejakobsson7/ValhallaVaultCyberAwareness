using System.Net.Http.Json;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public class AnswerService : IAnswerService
    {
        public HttpClient Client { get; set; } = new()
        {
            BaseAddress = new Uri("https://localhost:7107/Answer/")
        };
        public async Task<bool> AddAnswerAsync(AnswerModel newAnswer)
        {
            var apiResponse = await Client.PostAsJsonAsync<AnswerModel>(Client.BaseAddress, newAnswer);
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveAnswerAsync(int answerId)
        {
            var apiResponse = await Client.DeleteAsync($"{answerId}");
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateAnswerAsync(AnswerModel answer)
        {
            var apiResponse = await Client.PutAsJsonAsync<AnswerModel>(Client.BaseAddress, answer);
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
