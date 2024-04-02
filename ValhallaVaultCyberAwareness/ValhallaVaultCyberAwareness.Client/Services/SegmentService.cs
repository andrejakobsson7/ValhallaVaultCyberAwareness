using Newtonsoft.Json;
using System.Net.Http.Json;
using ValhallaVaultCyberAwareness.Client.ViewModels;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public class SegmentService : ISegmentService
    {
        public HttpClient Client { get; set; }

        public SegmentService(HttpClient client, ValhallaHeaderService valhallaHeaderService)
        {
            Client = client;
            valhallaHeaderService.ConfigureHeaders(Client);
        }
        public async Task<SegmentUserScoreViewModel> GetSegmentWithUserScore(int segmentId, string userId)
        {
            var apiResponse = await Client.GetAsync($"api/segment/{segmentId}/{userId}");
            if (apiResponse.IsSuccessStatusCode)
            {
                string jsonSegment = await apiResponse.Content.ReadAsStringAsync();
                SegmentModel? segment = JsonConvert.DeserializeObject<SegmentModel>(jsonSegment);
                if (segment == null)
                {
                    throw new JsonException();
                }
                else
                {
                    SegmentUserScoreViewModel segmentScore = new SegmentUserScoreViewModel(segment);
                    return segmentScore;
                }
            }
            throw new HttpRequestException();
        }

        public async Task<bool> AddSegmentAsync(SegmentModel newSegment)
        {
            Client.DefaultRequestHeaders.Add("IsAdmin", "True");
            var apiResponse = await Client.PostAsJsonAsync("/api/segment/", newSegment);
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveSegmentAsync(int segmentId)
        {
            Client.DefaultRequestHeaders.Add("IsAdmin", "True");
            var apiResponse = await Client.DeleteAsync($"/api/segment/{segmentId}/");
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateSegmentAsync(SegmentModel segment)
        {
            var apiResponse = await Client.PutAsJsonAsync($"/api/Segment/{segment.Id}/", segment);
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

    }
}
