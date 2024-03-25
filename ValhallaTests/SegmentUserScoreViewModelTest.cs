using ValhallaTests.TestData;
using ValhallaVaultCyberAwareness.Client.ViewModels;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaTests
{
    public class SegmentUserScoreViewModelTest
    {
        private SegmentModel _segment;
        private SegmentUserScoreViewModel _segmentScore;

        [Fact]
        private void SetUp()
        {
            _segment = SegmentTestData.Segments.First();
            Assert.NotNull(_segment);
            _segmentScore = new();
            Assert.NotNull(_segmentScore);
        }

        [Fact]
        private void SetSegmentId()
        {
            SetUp();
            _segmentScore.SegmentId = _segmentScore.GetSegmentId(_segment.Id);
            Assert.Equal(_segment.Id, _segmentScore.SegmentId);
        }

        [Fact]
        private void SetSegmentName()
        {
            SetUp();
            _segmentScore.SegmentName = _segmentScore.GetSegmentName(_segment.Name);
            Assert.Equal(_segment.Name, _segmentScore.SegmentName);
        }

        [Fact]
        private void SetSegmentDescription()
        {
            SetUp();
            _segmentScore.SegmentDescription = _segmentScore.GetSegmentDescription(_segment.Description);
            Assert.Equal(_segment.Description, _segmentScore.SegmentDescription);
        }

        [Fact]
        private void SetTotalSubCategories()
        {
            SetUp();
            _segmentScore.TotalSubCategories = _segmentScore.GetTotalSubCategories(_segment.SubCategories);
            Assert.Equal(_segment.SubCategories.Count, _segmentScore.TotalSubCategories);
        }

        [Theory]
        [InlineData(100, 50, 50.0)]
        [InlineData(0, 0, 100.0)]
        [InlineData(1, 0, 0.0)]
        [InlineData(0, 10, 100.0)]
        [InlineData(-1, 0, 100.0)]
        [InlineData(6, 6, 100.0)]
        [InlineData(10, 2, 20.0)]
        [InlineData(6, 4, 66.67)]
        [InlineData(10, 20, 200.0)]
        private void SetUserCompletionPercentage(int totalQuestions, int correctUserAnswers, double expectedCompletionPercentage)
        {
            SetUp();
            _segmentScore.UserCompletionPercentage = _segmentScore.GetUserCompletionPercentage(totalQuestions, correctUserAnswers);
            Assert.Equal(expectedCompletionPercentage, _segmentScore.UserCompletionPercentage);
        }

        [Fact]
        private void ConvertToSubCategoryViewModel()
        {
            SetUp();
            _segmentScore.SubCategoryScores = _segmentScore.ProjectSubCategoriesToViewModels(_segment.SubCategories);
            Assert.NotNull(_segmentScore.SubCategoryScores);
        }

        [Fact]
        private void SetSubCategoryCompletionPercentage()
        {
            ConvertToSubCategoryViewModel();
            _segmentScore.CompletedSubcategories = _segmentScore.GetCompletedSubCategories(_segmentScore.SubCategoryScores);
            Assert.Equal(0, _segmentScore.CompletedSubcategories);
        }

        [Fact]
        private void SetTotalQuestionsInSegment()
        {
            ConvertToSubCategoryViewModel();
            _segmentScore.TotalQuestions = _segmentScore.GetTotalQuestionsInSegment(_segmentScore.SubCategoryScores);
            Assert.Equal(6, _segmentScore.TotalQuestions);
        }

        [Fact]
        private void SetCorrectUserAnswersInSegment()
        {
            ConvertToSubCategoryViewModel();
            _segmentScore.CorrectUserAnswers = _segmentScore.GetCorrectUserAnswersInSegment(_segmentScore.SubCategoryScores);
            Assert.Equal(4, _segmentScore.CorrectUserAnswers);
        }

        [Fact]
        private void SetSubCategoryStartIndex()
        {
            SetTotalQuestionsInSegment();
            _segmentScore.AvailableSubCategoryIndex = _segmentScore.GetSubCategoryStartIndex(_segmentScore.SubCategoryScores);
            Assert.Equal(0, _segmentScore.AvailableSubCategoryIndex);
        }

        [Fact]
        private void SetUserCompletedSegment()
        {
            SetTotalQuestionsInSegment();
            _segmentScore.UserHasCompletedSegment = _segmentScore.GetUserCompletedSegment(_segmentScore.SubCategoryScores);
            Assert.False(_segmentScore.UserHasCompletedSegment);
        }

    }
}
