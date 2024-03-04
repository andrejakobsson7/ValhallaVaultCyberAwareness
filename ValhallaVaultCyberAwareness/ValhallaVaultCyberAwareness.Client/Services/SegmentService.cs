using Newtonsoft.Json;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public class SegmentService : ISegmentService
    {
        public HttpClient Client { get; set; } = new()
        {
            BaseAddress = new Uri("https://localhost:7107/Segment/")
        };
        public async Task<SegmentModel> GetSegmentById(int segmentId)
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


    }
}
