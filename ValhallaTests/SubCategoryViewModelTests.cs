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
        public void TestSetId()
        {
            Reset();
            Assert.Equal(_scoreViewModel.SubCategoryId, _subCategory.Id);
        }

        [Fact]
        public void TestSetName()
        {
            Reset();
            Assert.Equal(_scoreViewModel.SubCategoryName, _subCategory.Name);
        }

        [Fact]
        public void TestSetDecsription()
        {
            Reset();
            Assert.Equal(_scoreViewModel.SubCategoryDescription, _subCategory.Description);
        }

        [Fact]
        public void TestSetQuestionCount()
        {
            Reset();
            Assert.Equal(_scoreViewModel.TotalQuestions, _subCategory.Questions.Count);
        }

        [Fact]
        public void TestSetCorrectUserAnswers()
        {
            Reset();

            int correctUserAnswers = _scoreViewModel.SetCorrectUserAnswers(_subCategory.Questions);

            Assert.Equal(_scoreViewModel.CorrectUserAnswers, correctUserAnswers);

        }

        [Fact]
        public void TestCalculateSuccessPercentage()
        {
            Reset();

            double percentage = _scoreViewModel.CalculateSuccessPercentage(_scoreViewModel.TotalQuestions, _scoreViewModel.CorrectUserAnswers);

            Assert.Equal(_scoreViewModel.UserCompletionPercentage, percentage);
        }

        [Fact]
        public void TestUserHasCompletedSubCategory()
        {
            Reset();

            bool hasCompletedSubCategory = _scoreViewModel.SetUserHasCompletedSubCategory();

            Assert.Equal(_scoreViewModel.UserHasCompletedSubCategory, hasCompletedSubCategory);
        }

    }
}