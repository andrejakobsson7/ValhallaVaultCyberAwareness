using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Repositories
{
    public interface ISegmentRepository
    {
        public ApplicationDbContext _context { get; set; }

        public Task<SegmentModel?> GetSegmentByIdAsync(int segmentId);

        public Task<bool> AddSegmentAsync(SegmentModel newSegment);

        public Task<bool> RemoveSegmentAsync(int segmentId);

        public Task<bool> UpdateSegmentAsync(SegmentModel segment);
    }
}
