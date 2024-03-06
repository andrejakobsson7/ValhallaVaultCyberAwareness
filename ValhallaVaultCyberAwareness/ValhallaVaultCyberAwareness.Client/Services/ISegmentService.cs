using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public interface ISegmentService
    {
        public HttpClient Client { get; set; }

        public Task<List<SegmentModel>> GetSegmentsByCategoryIdAsync(int categoryId);

        public Task<bool> AddSegmentAsync(SegmentModel newSegment);

        public Task<bool> RemoveSegmentAsync(int segmentId);
        public Task<bool> UpdateSegmentAsync(SegmentModel segment);
    }

    public class SegmentWithSubcategories
    {
        public SegmentModel Segment { get; set; }
        public List<SubCategoryModel> Subcategories { get; set; }
    }
}
