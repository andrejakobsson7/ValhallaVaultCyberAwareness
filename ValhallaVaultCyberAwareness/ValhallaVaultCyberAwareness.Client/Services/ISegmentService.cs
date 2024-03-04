using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public interface ISegmentService
    {
        public HttpClient Client { get; set; }

        public Task<SegmentModel> GetSegmentById(int segmentId);
    }
}
