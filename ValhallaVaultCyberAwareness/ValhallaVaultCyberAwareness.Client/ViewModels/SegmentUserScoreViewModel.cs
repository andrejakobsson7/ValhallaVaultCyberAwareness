using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.ViewModels
{
    public class SegmentUserScoreViewModel
    {
        public int SegmentId { get; set; }
        public string? SegmentName { get; set; }
        public string? SegmentDescription { get; set; }
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
            SegmentId = GetSegmentId(segment.Id);
            SegmentName = GetSegmentName(segment.Name);
            SegmentDescription = GetSegmentDescription(segment.Description);
            SubCategoryScores = ProjectSubCategoriesToViewModels(segment.SubCategories);
            CompletedSubcategories = GetCompletedSubCategories(SubCategoryScores);
            TotalSubCategories = GetTotalSubCategories(segment.SubCategories);
            CorrectUserAnswers = GetCorrectUserAnswersInSegment(SubCategoryScores);
            TotalQuestions = GetTotalQuestionsInSegment(SubCategoryScores);
            UserCompletionPercentage = GetUserCompletionPercentage(TotalQuestions, CorrectUserAnswers);
            AvailableSubCategoryIndex = GetSubCategoryStartIndex(SubCategoryScores, TotalQuestions);
            UserHasCompletedSegment = GetUserCompletedSegment(SubCategoryScores);
        }

        public int GetSegmentId(int id)
        {
            return id;
        }

        public string GetSegmentName(string name)
        {
            return name;
        }

        public string GetSegmentDescription(string description)
        {
            return description;
        }
        public int GetTotalSubCategories(List<SubCategoryModel> subCategories)
        {
            return subCategories.Count;
        }

        public List<SubCategoryScoreViewModel> ProjectSubCategoriesToViewModels(List<SubCategoryModel> subCategories)
        {
            List<SubCategoryScoreViewModel> subCategoryScores = subCategories.Select(s => new SubCategoryScoreViewModel(s)).ToList();
            return subCategoryScores;
        }

        public int GetCompletedSubCategories(List<SubCategoryScoreViewModel> subCategoryScores)
        {
            return subCategoryScores.Where(s => s.UserHasCompletedSubCategory).Count();
        }

        public int GetTotalQuestionsInSegment(List<SubCategoryScoreViewModel> subCategoryScores)
        {
            //Calculate all questions in each subcategory and aggregate it to the segments total.
            return subCategoryScores.Aggregate(0, (total, subCategoryScore) => total + subCategoryScore.TotalQuestions);
        }

        public int GetCorrectUserAnswersInSegment(List<SubCategoryScoreViewModel> subCategoryScores)
        {
            //Calculate all correct useranswers in each subcategory and aggregate it to the segments total.
            return subCategoryScores.Aggregate(0, (total, subCategoryScore) => total + subCategoryScore.CorrectUserAnswers);
        }

        public double GetUserCompletionPercentage(int totalQuestions, int correctUserAnswers)
        {
            if (totalQuestions > 0)
            {
                return Math.Round(((double)correctUserAnswers / (double)totalQuestions) * 100, 2);
            }
            else
            {
                return 100;
            }

        }

        public int GetSubCategoryStartIndex(List<SubCategoryScoreViewModel> subCategoryScores, int totalQuestions)
        {
            if (totalQuestions > 0)
            {
                int availableSubCategoryIndex = 0;
                for (int i = 0; i < subCategoryScores.Count; i++)
                {
                    if (subCategoryScores[i].UserHasCompletedSubCategory)
                    {
                        availableSubCategoryIndex++;
                    }
                    else
                    {
                        break;
                    }
                }
                return availableSubCategoryIndex;
            }
            else
            {
                return -1;
            }
        }

        public bool GetUserCompletedSegment(List<SubCategoryScoreViewModel> subCategoryScores)
        {
            //Check if the user has completed all subcategories. If the user has completed all subcategories, the segment is completed.
            if (subCategoryScores.All(s => s.UserHasCompletedSubCategory == true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
