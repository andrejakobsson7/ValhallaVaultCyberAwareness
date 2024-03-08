using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.ViewModels
{
    public class SubCategoryScoreViewModel
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; } = null!;
        public string? SubCategoryDescription { get; set; }
        public int CorrectUserAnswers { get; set; }
        public int TotalQuestions { get; set; }
        public bool UserHasCompletedSubCategory { get; set; }
        private double CompletionPercentage { get; set; } = 0.80;


        public SubCategoryScoreViewModel(SubCategoryModel subCategory)
        {
            SubCategoryId = subCategory.Id;
            SubCategoryName = subCategory.Name;
            SubCategoryDescription = subCategory.Description;
            TotalQuestions = subCategory.Questions.Count;
            foreach (QuestionModel question in subCategory.Questions)
            {
                //Find out the correct answer
                AnswerModel correctAnswer = question.Answers.First(a => a.IsCorrect);

                //Check if the user has correctly answered this question
                if (correctAnswer.UserAnswers.Any())
                {
                    //Add to the total count of correct answers in this subcategory
                    CorrectUserAnswers++;

                }
            }
            //Calculate the success percentage
            double completionPercentage = (double)CorrectUserAnswers / (double)subCategory.Questions.Count;
            //If the success percentage is over the threshold or NaN (which will be the case if the subcategory doesn't contain any questions).
            if (completionPercentage >= CompletionPercentage || Double.IsNaN(completionPercentage))
            {
                //Add true as the value if the user has passed enough in this subcategory.
                UserHasCompletedSubCategory = true;
            }
            else
            {
                //If not, add false as the value
                UserHasCompletedSubCategory = false;
            }
        }
    }
}
