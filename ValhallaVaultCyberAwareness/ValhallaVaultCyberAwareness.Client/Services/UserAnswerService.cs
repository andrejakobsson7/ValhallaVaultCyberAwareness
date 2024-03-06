using System.Net.Http.Json;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public class UserAnswerService : IUserAnswersService
    {
        public HttpClient Client { get; set; }

        public UserAnswerService(HttpClient client)
        {
            Client = client;
        }

        public async Task<bool> AddUserAnswerAsync(UserAnswers newUserAnswer)
        {
            var apiResponse = await Client.PostAsJsonAsync<UserAnswers>("/api/UserAnswers/", newUserAnswer);
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }


    }
}
