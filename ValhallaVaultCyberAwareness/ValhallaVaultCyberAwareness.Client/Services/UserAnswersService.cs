using System.Net.Http.Json;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public class UserAnswersService : IUserAnswersService
    {
        public HttpClient Client { get; set; }

        public UserAnswersService(HttpClient client, ValhallaHeaderService valhallaHeaderService)
        {
            Client = client;
            valhallaHeaderService.ConfigureHeaders(client);
        }

        public async Task<bool> AddUserAnswersAsync(List<UserAnswers> newUserAnswers)
        {
            var apiResponse = await Client.PostAsJsonAsync("/api/useranswers/", newUserAnswers);
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }


    }
}
