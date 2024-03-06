using Newtonsoft.Json;
using System.Net.Http.Json;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public class SegmentService : ISegmentService
    {
        public HttpClient Client { get; set; }

        public SegmentService(HttpClient client)
        {
            Client = client;
        }
        public async Task<List<SegmentModel>> GetSegmentsByCategoryIdAsync(int categoryId)
        {

            var apiResponse = await Client.GetAsync($"/api/segment/{categoryId}/");
            if (apiResponse.IsSuccessStatusCode)
            {
                string jsonSegment = await apiResponse.Content.ReadAsStringAsync();
                List<SegmentModel> segments = JsonConvert.DeserializeObject<List<SegmentModel>>(jsonSegment);
                if (segments == null)
                {
                    throw new JsonException();
                }
                else
                {
                    return segments;
                }
            }
            throw new HttpRequestException();
        }

        public async Task<bool> AddSegmentAsync(SegmentModel newSegment)
        {
            var apiResponse = await Client.PostAsJsonAsync<SegmentModel>("/api/segment/", newSegment);
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveSegmentAsync(int segmentId)
        {
            var apiResponse = await Client.DeleteAsync($"/api/Segment/{segmentId}/");
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateSegmentAsync(SegmentModel segment)
        {
            var apiResponse = await Client.PutAsJsonAsync<SegmentModel>($"/api/Segment/{segment.Id}/", segment);
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

    }
}
