using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.ViewModels
{
    public class CategoryScoreViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public List<SegmentUserScoreViewModel> SegmentUserScores { get; set; } = new();
        public int CompletedSegments { get; set; }
        public int TotalSegments { get; set; }
        public bool UserHasCompletedCategory { get; set; }

        public CategoryScoreViewModel(CategoryModel category)
        {
            CategoryId = category.Id;
            CategoryName = category.Name;
            CategoryDescription = category.Description;
            SegmentUserScores = category.Segments.Select(s => new SegmentUserScoreViewModel(s)).ToList();
            CompletedSegments = SegmentUserScores.Where(s => s.UserHasCompletedSegment).Count();
            TotalSegments = SegmentUserScores.Count();
            if (SegmentUserScores.Any(s => s.UserHasCompletedSegment == false))
            {
                UserHasCompletedCategory = false;
            }
            else
            {
                UserHasCompletedCategory = true;
            }
        }
    }
}
