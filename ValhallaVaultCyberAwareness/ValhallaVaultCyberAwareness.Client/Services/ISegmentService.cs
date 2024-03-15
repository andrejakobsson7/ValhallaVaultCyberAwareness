using ValhallaVaultCyberAwareness.Client.ViewModels;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public interface ISegmentService
    {
        public HttpClient Client { get; set; }

        /// <summary>
        /// Method to retrieve one segment by id.
        /// </summary>
        /// <param name="segmentId"></param>
        /// <param name="userId"></param>
        /// <returns>A single segment, converted to a viewmodel that holds all neccessary information for making decisions in the UI.</returns>
        /// <exception cref="JsonException"></exception>
        /// <exception cref="HttpRequestException"></exception>
        public Task<SegmentUserScoreViewModel> GetSegmentWithUserScore(int segmentId, string userId);
        public Task<bool> AddSegmentAsync(SegmentModel newSegment);

        public Task<bool> RemoveSegmentAsync(int segmentId);
        public Task<bool> UpdateSegmentAsync(SegmentModel segment);
    }
}
