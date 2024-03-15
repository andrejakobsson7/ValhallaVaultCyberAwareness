using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Repositories.Interfaces
{
    public interface ISegmentRepository
    {
        public ApplicationDbContext _context { get; set; }
        public Task<SegmentModel?> GetSegmentByIdAsync(int segmentId);
        public Task<SegmentModel?> GetSegmentWithUserScoresByUserIdAsync(int segmentId, string userId);
        public Task<List<SegmentModel>> GetAllSegmentsAsync();
        public Task<List<SegmentModel>> GetAllSegmentsWithIncludeAsync();
        public Task<SegmentModel> AddSegmentAsync(SegmentModel newSegment);
        public Task<bool> RemoveSegmentAsync(int segmentId);
        public Task<bool> UpdateSegmentAsync(SegmentModel segment);
    }
}
