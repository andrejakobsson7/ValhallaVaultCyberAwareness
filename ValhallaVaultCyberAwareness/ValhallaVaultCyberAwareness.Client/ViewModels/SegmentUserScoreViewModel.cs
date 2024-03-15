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
        public int CompletedSubcategories { get; set; }
        public int TotalSubCategories { get; set; }
        public double UserCompletionPercentage { get; set; }
        public bool UserHasCompletedSegment { get; set; }
        public int AvailableSubCategoryIndex { get; set; } = 0;


        public SegmentUserScoreViewModel(SegmentModel segment)
        {
            SegmentId = segment.Id;
            SegmentName = segment.Name;
            SegmentDescription = segment.Description;
            SegmentSubCategories = segment.SubCategories;
            SubCategoryScores = segment.SubCategories.Select(s => new SubCategoryScoreViewModel(s)).ToList();
            CompletedSubcategories = SubCategoryScores.Where(s => s.UserHasCompletedSubCategory).Count();
            TotalSubCategories = SubCategoryScores.Count();
            //Calculate all correct useranswers in each subcategory and aggregate it to the segments total.
            CorrectUserAnswers = SubCategoryScores.Aggregate(0, (total, subCategoryScore) => total + subCategoryScore.CorrectUserAnswers);
            //Calculate all questions in each subcategory and aggregate it to the segments total.
            TotalQuestions = SubCategoryScores.Aggregate(0, (total, subCategoryScore) => total + subCategoryScore.TotalQuestions);
            //Calculate user success percentage in this segment.
            if (TotalQuestions > 0)
            {
                UserCompletionPercentage = Math.Round(((double)CorrectUserAnswers / (double)TotalQuestions) * 100, 2);
            }
            else
            {
                UserCompletionPercentage = 0;
                AvailableSubCategoryIndex = -1;
            }
            //Calculate which subcategory the user is eligible to start from.
            for (int i = 0; i < SubCategoryScores.Count; i++)
            {
                if (SubCategoryScores[i].UserHasCompletedSubCategory)
                {
                    AvailableSubCategoryIndex++;
                }
                else
                {
                    break;
                }
            }
            //Check if the user has completed all subcategories. If the user has completed all subcategories, the segment is completed.
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
