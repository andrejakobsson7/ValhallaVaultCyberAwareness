using ValhallaTests.TestData;
using ValhallaVaultCyberAwareness.Client.ViewModels;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaTests
{
    public class SubCategoryViewModelTests
    {
        private SubCategoryScoreViewModel _scoreViewModel;
        private SubCategoryModel _subCategory;

        private void Reset()
        {
            _subCategory = SubCategoryTestData.SubCategories[0];
            _scoreViewModel = new(_subCategory);
        }

        [Fact]
        public void SetId()
        {
            Reset();
            Assert.Equal(_scoreViewModel.SubCategoryId, _subCategory.Id);
        }

        [Fact]
        public void SetName()
        {
            Reset();
            Assert.Equal(_scoreViewModel.SubCategoryName, _subCategory.Name);
        }

        [Fact]
        public void SetDecsription()
        {
            Reset();
            Assert.Equal(_scoreViewModel.SubCategoryDescription, _subCategory.Description);
        }

        [Fact]
        public void SetQuestionCount()
        {
            Reset();
            Assert.Equal(_scoreViewModel.TotalQuestions, _subCategory.Questions.Count);
        }

        [Fact]
        public void SetCorrectUserAnswers()
        {
            Reset();

            int correctUserAnswers = 0;

            foreach (var question in _subCategory.Questions)
            {
                AnswerModel correctAnswer = question.Answers.First(a => a.IsCorrect);

                //Check if the user has correctly answered this question
                if (correctAnswer.UserAnswers.Any())
                {
                    //Add to the total count of correct answers in this subcategory
                    correctUserAnswers++;
                }
            }

            Assert.Equal(_scoreViewModel.CorrectUserAnswers, correctUserAnswers);

        }

        [Fact]
        public void CalculateSuccessPercentage()
        {
            Reset();

            double percentage = 0;

            if (_scoreViewModel.TotalQuestions > 0)
            {
                percentage = Math.Round(((double)_scoreViewModel.CorrectUserAnswers / (double)_scoreViewModel.TotalQuestions) * 100, 2);
            }
            else
            {
                percentage = 100;
            }

            Assert.Equal(_scoreViewModel.UserCompletionPercentage, percentage);
        }

        [Fact]
        public void SetUserHasCompletedSubCategory()
        {
            Reset();

            bool hasCompletedSubCategory;

            if (_scoreViewModel.UserCompletionPercentage >= _scoreViewModel.CompletionPercentage || Double.IsNaN(_scoreViewModel.UserCompletionPercentage))
            {
                //Add true as the value if the user has passed enough in this subcategory.
                hasCompletedSubCategory = true;
            }
            else
            {
                //If not, add false as the value
                hasCompletedSubCategory = false;
            }

            Assert.Equal(_scoreViewModel.UserHasCompletedSubCategory, hasCompletedSubCategory);
        }

    }
}
