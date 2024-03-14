using Newtonsoft.Json;
using System.Net.Http.Json;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public class UserAnswersService : IUserAnswersService
    {
        public HttpClient Client { get; set; }

        public UserAnswersService(HttpClient client)
        {
            Client = client;
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

        public async Task<List<UserProgress>> GetUserProgressAsync(string userId)
        {
            var apiResponse = await Client.GetAsync($"/api/useranswers/{userId}/progress");
            if (apiResponse.IsSuccessStatusCode)
            {
                string jsonResponse = await apiResponse.Content.ReadAsStringAsync();
                List<UserProgress> userProgress = JsonConvert.DeserializeObject<List<UserProgress>>(jsonResponse);
                if (userProgress == null)
                {
                    throw new JsonException();
                }
                else
                {
                    return userProgress;
                }
            }
            throw new HttpRequestException();
        }

        public class UserProgress
        {
  

            public int CategoryId { get; set; }
            public double Percentage { get; set; }
        }




    }
}
