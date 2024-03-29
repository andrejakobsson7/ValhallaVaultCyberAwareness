﻿using ValhallaVaultCyberAwareness.Domain.Models;

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
            CategoryId = category.Id;
            CategoryName = category.Name;
            CategoryDescription = category.Description;
            SegmentUserScores = category.Segments.Select(s => new SegmentUserScoreViewModel(s)).ToList();
            CompletedSegments = SegmentUserScores.Where(s => s.UserHasCompletedSegment).Count();
            TotalSegments = SegmentUserScores.Count();
            //Calculate all correct useranswers in each segment and aggregate it to the category total.
            CorrectUserAnswers = SegmentUserScores.Aggregate(0, (total, segmentScore) => total + segmentScore.CorrectUserAnswers);
            //Calculate all questions in each segment and aggregate it to the category total.
            TotalQuestions = SegmentUserScores.Aggregate(0, (total, segmentScore) => total + segmentScore.TotalQuestions);
            //Calculate user success percentage in this category.
            if (TotalQuestions > 0)
            {
                UserCompletionPercentage = Math.Round(((double)CorrectUserAnswers / (double)TotalQuestions) * 100, 2);
            }
            else
            {
                UserCompletionPercentage = 0;
                AvailableSegmentIndex = -1;
            }
            //Calculate which segment the user is eligible to start from.
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
            //Check if the user has not finished all segments. If so, the category is not completed.
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
