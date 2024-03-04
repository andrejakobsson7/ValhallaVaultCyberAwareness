using Newtonsoft.Json;
using System.Net.Http.Json;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public class SegmentService : ISegmentService
    {
        public HttpClient Client { get; set; } = new()
        {
            BaseAddress = new Uri("https://localhost:7107/Segment/")
        };
        public async Task<SegmentModel> GetSegmentByIdAsync(int segmentId)
        {
            var apiResponse = await Client.GetAsync($"{segmentId}");
            if (apiResponse.IsSuccessStatusCode)
            {
                string jsonSegment = await apiResponse.Content.ReadAsStringAsync();
                SegmentModel segment = JsonConvert.DeserializeObject<SegmentModel>(jsonSegment);
                if (segment == null)
                {
                    throw new JsonException();
                }
                else
                {
                    return segment;
                }
            }
            throw new HttpRequestException();
        }

        public async Task<bool> AddSegmentAsync(SegmentModel newSegment)
        {
            var apiResponse = await Client.PostAsJsonAsync<SegmentModel>(Client.BaseAddress, newSegment);
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveSegmentAsync(int segmentId)
        {
            var apiResponse = await Client.DeleteAsync($"{segmentId}");
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateSegmentAsync(SegmentModel segment)
        {
            var apiResponse = await Client.PutAsJsonAsync<SegmentModel>(Client.BaseAddress, segment);
            if (apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

    }
}
