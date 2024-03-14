using System.Net.Http.Json;
using ValhallaVaultCyberAwareness.Domain.Models.Support;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public class SupportResponseService : ISupportResponseService
    {
        public HttpClient Client { get; set; }

        public SupportResponseService(HttpClient client)
        {
            Client = client;
        }

        public async Task<bool> AddSupportResponseAsync(SupportResponseModel newSupportResponse)
        {
            var apiResponse = await Client.PostAsJsonAsync("/api/supportresponse/", newSupportResponse);
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateSupportResponseAsync(SupportResponseModel supportResponse)
        {
            var apiResponse = await Client.PutAsJsonAsync($"/api/supportresponse/{supportResponse.Id}/", supportResponse);
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveSupportResponseAsync(int supportResponseId)
        {
            var apiResponse = await Client.DeleteAsync($"api/supportresponse/{supportResponseId}/");
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

    }
}
