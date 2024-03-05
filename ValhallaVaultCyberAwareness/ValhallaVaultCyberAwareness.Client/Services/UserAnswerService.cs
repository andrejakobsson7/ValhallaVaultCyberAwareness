using System.Net.Http.Json;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public class UserAnswerService : IUserAnswersService
    {
        public HttpClient Client { get; set; } = new()
        {
            BaseAddress = new Uri("https://localhost:7107/UserAnswer/")
        };

        public async Task<bool> AddUserAnswerAsync(UserAnswers newUserAnswer)
        {
            var apiResponse = await Client.PostAsJsonAsync<UserAnswers>(Client.BaseAddress, newUserAnswer);
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }


    }
}
