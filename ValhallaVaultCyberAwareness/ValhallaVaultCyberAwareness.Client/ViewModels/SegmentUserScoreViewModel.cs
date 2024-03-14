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
        public int CorrectUserAnswers { get; set; }
        public int TotalQuestions { get; set; }

        public double UserCompletionPercentage { get; set; }
        public bool UserHasCompletedSegment { get; set; }

        public SegmentUserScoreViewModel(SegmentModel segment)
        {
            SegmentId = segment.Id;
            SegmentName = segment.Name;
            SegmentDescription = segment.Description;
            SegmentSubCategories = segment.SubCategories;
            SubCategoryScores = segment.SubCategories.Select(s => new SubCategoryScoreViewModel(s)).ToList();
            CorrectUserAnswers = SubCategoryScores.Aggregate(0, (total, subCategoryScore) => total + subCategoryScore.CorrectUserAnswers);
            TotalQuestions = SubCategoryScores.Aggregate(0, (total, subCategoryScore) => total + subCategoryScore.TotalQuestions);
            UserCompletionPercentage = Math.Round((double)CorrectUserAnswers / (double)TotalQuestions);
            if (SubCategoryScores.Any(s => s.UserHasCompletedSubCategory == false))
            {
                UserHasCompletedSegment = false;
            }
            else
            {
                UserHasCompletedSegment = true;
            }
        }
    }
}
