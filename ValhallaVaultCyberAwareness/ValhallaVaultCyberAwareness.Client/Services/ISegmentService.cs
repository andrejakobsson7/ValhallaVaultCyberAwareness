using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public interface ISegmentService
    {
        public HttpClient Client { get; set; }

        public Task<SegmentModel> GetSegmentByIdAsync(int segmentId);

        public Task<bool> AddSegmentAsync(SegmentModel newSegment);

        public Task<bool> RemoveSegmentAsync(int segmentId);
        public Task<bool> UpdateSegmentAsync(SegmentModel segment);
    }
}
