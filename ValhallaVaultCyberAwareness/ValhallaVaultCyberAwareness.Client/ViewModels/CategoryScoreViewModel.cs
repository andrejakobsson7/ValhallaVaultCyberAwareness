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
        public int CorrectUserAnswers { get; set; }
        public int TotalQuestions { get; set; }
        public double UserCompletionPercentage { get; set; }
        public bool UserHasCompletedCategory { get; set; }
        public int AvailableSegmentIndex { get; set; } = 0;

        public CategoryScoreViewModel(CategoryModel category)
        {
            CategoryId = GetCategoryId(category.Id);
            CategoryName = GetCategoryName(category.Name);
            CategoryDescription = GetCategoryDescription(category.Description);
            SegmentUserScores = GetSegmentUserScores(category); // category.Segments.Select(s => new SegmentUserScoreViewModel(s)).ToList();
            CompletedSegments = GetCompletedSegments(SegmentUserScores); // SegmentUserScores.Where(s => s.UserHasCompletedSegment).Count();
            TotalSegments = GetTotalSegments(category); // SegmentUserScores.Count();
            //Calculate all correct useranswers in each segment and aggregate it to the category total.
            CorrectUserAnswers = GetCorrectAnswersInSegment(SegmentUserScores); // SegmentUserScores.Aggregate(0, (total, segmentScore) => total + segmentScore.CorrectUserAnswers);
            //Calculate all questions in each segment and aggregate it to the category total.
            TotalQuestions = GetTotalQuestions(SegmentUserScores); // SegmentUserScores.Aggregate(0, (total, segmentScore) => total + segmentScore.TotalQuestions);
            //Calculate user success percentage in this category.
            UserCompletionPercentage = GetUserCompletionPercentage(TotalQuestions, CorrectUserAnswers);
            /*
            if (TotalQuestions > 0)
            {
                UserCompletionPercentage = Math.Round(((double)CorrectUserAnswers / (double)TotalQuestions) * 100, 2);
            }
            else
            {
                UserCompletionPercentage = 0;
                AvailableSegmentIndex = -1;
            }
            */
            //Calculate which segment the user is eligible to start from.
            AvailableSegmentIndex = GetAvailableSegmentIndex(SegmentUserScores);
            /*
            for (int i = 0; i < SegmentUserScores.Count; i++)
            {
                if (SegmentUserScores[i].UserHasCompletedSegment)
                {
                    AvailableSegmentIndex++;
                }
                else
                {
                    break;
                }
            }
            */
            //Check if the user has not finished all segments. If so, the category is not completed.
            UserHasCompletedCategory = GetUserHasCompletedCategory(SegmentUserScores);
            /*
            if (SegmentUserScores.Any(s => s.UserHasCompletedSegment == false))
            {
                UserHasCompletedCategory = false;
            }
            else
            {
                UserHasCompletedCategory = true;
            }
            */
        }
        public int GetCategoryId(int id)
        {
            return id;
        }
        public string GetCategoryName(string name)
        {
            return name;
        }
        public string GetCategoryDescription(string description)
        {
            return description;
        }
        public List<SegmentUserScoreViewModel> GetSegmentUserScores(CategoryModel category)
        {
            return category.Segments.Select(s => new SegmentUserScoreViewModel(s)).ToList();
        }
        public int GetCompletedSegments(List<SegmentUserScoreViewModel> segmentUserScores)
        {
            return segmentUserScores.Where(s => s.UserHasCompletedSegment).Count();
        }
        public int GetTotalSegments(CategoryModel category)
        {
            return category.Segments.Count;
        }
        public int GetCorrectAnswersInSegment(List<SegmentUserScoreViewModel> segmentUserScores)
        {
            return segmentUserScores.Aggregate(0, (total, segmentScore) => total + segmentScore.CorrectUserAnswers);
        }
        public int GetTotalQuestions(List<SegmentUserScoreViewModel> segmentUserScores)
        {
            return segmentUserScores.Aggregate(0, (total, segmentScore) => total + segmentScore.TotalQuestions);
        }
        public double GetUserCompletionPercentage(int totalQuestions, int correctAnswers)
        {
            if (totalQuestions > 0)
            {
                return Math.Round(((double)correctAnswers / (double)totalQuestions) * 100, 2);
            }
            else
            {
                AvailableSegmentIndex = -1;
                return 0;

            }
        }
        public int GetAvailableSegmentIndex(List<SegmentUserScoreViewModel> segmentUserScores)
        {
            if (TotalQuestions > 0)
            {
                int availableSegmentIndex = 0;
                for (int i = 0; i < segmentUserScores.Count; i++)
                {
                    if (segmentUserScores[i].UserHasCompletedSegment)
                    {
                        availableSegmentIndex++;
                    }
                    else
                    {
                        break;
                    }
                }
                return availableSegmentIndex;
            }
            else
            {
                return -1;
            }
        }
        public bool GetUserHasCompletedCategory(List<SegmentUserScoreViewModel> segmentUserScores)
        {
            if (segmentUserScores.Any(s => s.UserHasCompletedSegment == false))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
