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
        public double UserCompletionPercentage { get; set; }
        public bool UserHasCompletedSubCategory { get; set; }
        private double CompletionPercentage { get; set; } = 80.0;


        public SubCategoryScoreViewModel(SubCategoryModel subCategory)
        {
            SubCategoryId = SetSubCategoryId(subCategory.Id);
            SubCategoryName = SetSubCategoryName(subCategory.Name);
            SubCategoryDescription = SetSubCategoryDescription(SubCategoryDescription);
            TotalQuestions = SetTotalQuestions(subCategory.Questions);
            CorrectUserAnswers = SetCorrectUserAnswers(subCategory.Questions);
            //Calculate the success percentage
            UserCompletionPercentage = CalculateSuccessPercentage(TotalQuestions, CorrectUserAnswers);
            UserHasCompletedSubCategory = SetUserHasCompletedSubCategory();
        }

        public int SetSubCategoryId(int id)
        {
            return id;
        }

        public string SetSubCategoryName(string name)
        {
            return name;
        }

        public string SetSubCategoryDescription(string description)
        {
            return description;
        }
        public int SetTotalQuestions(List<QuestionModel> questions)
        {
            return questions.Count;
        }

        public int SetCorrectUserAnswers(List<QuestionModel> questions)
        {
            int correctUserAnswers = 0;

            foreach (QuestionModel question in questions)
            {
                //Find out the correct answer
                AnswerModel correctAnswer = question.Answers.First(a => a.IsCorrect);

                //Check if the user has correctly answered this question
                if (correctAnswer.UserAnswers.Any())
                {
                    //Add to the total count of correct answers in this subcategory
                    correctUserAnswers++;
                }
            }

            return correctUserAnswers;

        }

        public double CalculateSuccessPercentage(int totalQuestions, int correctUserAnswers)
        {
            if (TotalQuestions > 0)
            {
                return Math.Round(((double)correctUserAnswers / (double)totalQuestions) * 100, 2);
            }
            else
            {
                return 100;
            }

        }

        public bool SetUserHasCompletedSubCategory()
        {
            //If the success percentage is over the threshold or NaN (which will be the case if the subcategory doesn't contain any questions).
            if (UserCompletionPercentage >= CompletionPercentage || Double.IsNaN(UserCompletionPercentage))
            {
                //Add true as the value if the user has passed enough in this subcategory.
                return true;
            }
            else
            {
                //If not, add false as the value
                return false;
            }
        }

    }
}
