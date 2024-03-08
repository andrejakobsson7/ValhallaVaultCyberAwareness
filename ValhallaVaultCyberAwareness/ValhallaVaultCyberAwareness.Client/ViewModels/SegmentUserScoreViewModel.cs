using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.ViewModels
{
    public class SegmentUserScoreViewModel
    {
        public int SegmentId { get; set; }
        public string? SegmentName { get; set; }
        public string? SegmentDescription { get; set; }
        public List<SubCategoryModel> SegmentSubCategories { get; set; } = new();
        public List<QuestionModel> SegmentQuestions { get; set; } = new();
        public List<SubCategoryScoreViewModel> SubCategoryScores { get; set; } = new();
        public bool UserHasCompletedSegment { get; set; }

        public SegmentUserScoreViewModel(SegmentModel segment)
        {
            SegmentId = segment.Id;
            SegmentName = segment.Name;
            SegmentDescription = segment.Description;
            SegmentSubCategories = segment.SubCategories;
            SubCategoryScores = segment.SubCategories.Select(s => new SubCategoryScoreViewModel(s)).ToList();
            foreach (var subCategoryScore in SubCategoryScores)
            {
                if (subCategoryScore.UserHasCompletedSubCategory == false)
                {
                    UserHasCompletedSegment = false;
                    break;
                }
                UserHasCompletedSegment = true;
            }
        }
    }
}
