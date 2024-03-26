using ValhallaTests.TestData;
using ValhallaVaultCyberAwareness.Client.ViewModels;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaTests
{
    public class SegmentUserScoreViewModelTest
    {
        private SegmentModel _segment;
        private SegmentUserScoreViewModel _segmentScore;
        private List<SubCategoryScoreViewModel> _completedSubCategoryScores;
        private List<SubCategoryScoreViewModel> _failedSubCategoryScores;
        private List<SubCategoryScoreViewModel> _allSubCategoryScores;
        private List<SubCategoryScoreViewModel> _emptyListofSubCategoryScores = new();




        [Fact]
        private void SetUp()
        {
            _segment = SegmentTestData.Segments.First();
            Assert.NotNull(_segment);
            _segmentScore = new();
            Assert.NotNull(_segmentScore);
        }

        [Fact]
        private void SetUpSegmentScoreWithSubcategoryScores()
        {
            _segment = SegmentTestData.Segments.First();
            Assert.NotNull(_segment);
            _segmentScore = new(_segment);
            Assert.NotNull(_segmentScore);
            _completedSubCategoryScores = _segmentScore.SubCategoryScores.Where(s => s.UserHasCompletedSubCategory).ToList();
            Assert.NotEmpty(_completedSubCategoryScores);
            _failedSubCategoryScores = _segmentScore.SubCategoryScores.Where(s => s.UserHasCompletedSubCategory == false).ToList();
            Assert.NotEmpty(_failedSubCategoryScores);
            _allSubCategoryScores = _segmentScore.SubCategoryScores.ToList();
            Assert.NotEmpty(_allSubCategoryScores);
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
        private void ConvertToSubCategoryViewModels()
        {
            SetUp();
            _segmentScore.SubCategoryScores = _segmentScore.ProjectSubCategoriesToViewModels(_segment.SubCategories);
            Assert.NotNull(_segmentScore.SubCategoryScores);
            Assert.NotEmpty(_segmentScore.SubCategoryScores);
        }

        [Fact]
        private void ConvertEmptyListToSubCategoryViewModels()
        {
            SetUp();
            List<SubCategoryModel> emptySubCategoryList = new();
            _segmentScore.SubCategoryScores = _segmentScore.ProjectSubCategoriesToViewModels(emptySubCategoryList);
            Assert.NotNull(_segmentScore.SubCategoryScores);
            Assert.Empty(_segmentScore.SubCategoryScores);
        }

        [Fact]
        private void SetCompletedSubcategories()
        {
            ConvertToSubCategoryViewModels();
            _segmentScore.CompletedSubcategories = _segmentScore.GetCompletedSubCategories(_segmentScore.SubCategoryScores);
            Assert.Equal(1, _segmentScore.CompletedSubcategories);
        }

        [Fact]
        private void SetTotalQuestionsInSegment()
        {
            ConvertToSubCategoryViewModels();
            _segmentScore.TotalQuestions = _segmentScore.GetTotalQuestionsInSegment(_segmentScore.SubCategoryScores);
            Assert.Equal(6, _segmentScore.TotalQuestions);
        }

        [Fact]
        private void SetTotalQuestionsInSegmentFromEmptySubcategoryList()
        {
            ConvertEmptyListToSubCategoryViewModels();
            _segmentScore.TotalQuestions = _segmentScore.GetTotalQuestionsInSegment(_segmentScore.SubCategoryScores);
            Assert.Equal(0, _segmentScore.TotalQuestions);
        }

        [Fact]
        private void SetCorrectUserAnswersInSegment()
        {
            ConvertToSubCategoryViewModels();
            _segmentScore.CorrectUserAnswers = _segmentScore.GetCorrectUserAnswersInSegment(_segmentScore.SubCategoryScores);
            Assert.Equal(4, _segmentScore.CorrectUserAnswers);
        }

        [Fact]
        private void SetCorrectUserAnswersInSegmentFromEmptySubcategoryList()
        {
            ConvertEmptyListToSubCategoryViewModels();
            _segmentScore.CorrectUserAnswers = _segmentScore.GetCorrectUserAnswersInSegment(_segmentScore.SubCategoryScores);
            Assert.Equal(0, _segmentScore.CorrectUserAnswers);
        }

        [Fact]
        private void SetSubCategoryStartIndex()
        {
            SetUpSegmentScoreWithSubcategoryScores();
            //Test where the first subcategory (id 0) is completed, so user should be eligible to start from the next.
            _segmentScore.AvailableSubCategoryIndex = _segmentScore.GetSubCategoryStartIndex(_completedSubCategoryScores);
            Assert.Equal(1, _segmentScore.AvailableSubCategoryIndex);
            //Test where no subcategory is completed, so the user should be eligible to start from the first.
            _segmentScore.AvailableSubCategoryIndex = _segmentScore.GetSubCategoryStartIndex(_failedSubCategoryScores);
            Assert.Equal(0, _segmentScore.AvailableSubCategoryIndex);
            //Test where the first subcategory is not completed, but the second one is. User should be eligible to start from the first.
            _segmentScore.AvailableSubCategoryIndex = _segmentScore.GetSubCategoryStartIndex(_allSubCategoryScores);
            Assert.Equal(0, _segmentScore.AvailableSubCategoryIndex);
        }

        [Fact]
        private void SetSubCategoryStartIndexFromEmptySubcategoryList()
        {
            SetTotalQuestionsInSegmentFromEmptySubcategoryList();
            _segmentScore.AvailableSubCategoryIndex = _segmentScore.GetSubCategoryStartIndex(_segmentScore.SubCategoryScores);
            Assert.Equal(-1, _segmentScore.AvailableSubCategoryIndex);
        }

        [Fact]
        private void SetUserCompletedSegment()
        {
            SetUpSegmentScoreWithSubcategoryScores();

            //Test where 1 subcategory is completed and 1 failed
            _segmentScore.UserHasCompletedSegment = _segmentScore.GetUserCompletedSegment(_allSubCategoryScores);
            Assert.False(_segmentScore.UserHasCompletedSegment);

            //Test where all subcategories are completed
            _segmentScore.UserHasCompletedSegment = _segmentScore.GetUserCompletedSegment(_completedSubCategoryScores);
            Assert.True(_segmentScore.UserHasCompletedSegment);

            //Test where all subcategories are failed
            _segmentScore.UserHasCompletedSegment = _segmentScore.GetUserCompletedSegment(_failedSubCategoryScores);
            Assert.False(_segmentScore.UserHasCompletedSegment);

            //Test where subcategory is an empty list
            _segmentScore.UserHasCompletedSegment = _segmentScore.GetUserCompletedSegment(_emptyListofSubCategoryScores);
            Assert.True(_segmentScore.UserHasCompletedSegment);
        }
    }
}
