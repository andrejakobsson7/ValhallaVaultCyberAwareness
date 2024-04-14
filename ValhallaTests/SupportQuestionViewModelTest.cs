using Moq;
using ValhallaVaultCyberAwareness.Client.ViewModels;
using ValhallaVaultCyberAwareness.Domain.Models.Support;

namespace ValhallaTests
{
    public class SupportQuestionViewModelTest
    {
        private SupportQuestionViewModel _viewModel;
        private SupportQuestionModel _model;

        private void Reset()
        {
            _model = new SupportQuestionModel();
            _viewModel = new SupportQuestionViewModel(_model);
        }

        [Fact]
        public void TestViewModelInitialization()
        {

            _model = new SupportQuestionModel();
            _model.Created = DateTime.Now.AddDays(-3);

            _viewModel = new SupportQuestionViewModel(_model);

            double expectedDaysSincePost = 3;
            Assert.Equal(expectedDaysSincePost, _viewModel.DaysSincePost);
        }

        [Fact]
        public void TestViewModelDaysSincePostCalculation()
        {
            var createdDate = DateTime.Now.AddDays(-3);

            var supportQuestion = new SupportQuestionModel
            {
                Created = createdDate
            };


            var viewModel = new SupportQuestionViewModel(supportQuestion);

            double expectedDaysSincePost = (DateTime.Now - createdDate).TotalDays;
            double actualDaysSincePost = viewModel.DaysSincePost;


            Assert.Equal(expectedDaysSincePost, actualDaysSincePost, precision: 6);

        }

        [Fact]
        public void TestViewModelQuestionHasResponses()
        {
            var supportResponseMock = new Mock<SupportResponseModel>();
            var supportQuestionMock = new SupportQuestionModel
            {
                Id = 1,
                Question = "Test question",
                Username = "testuser",
                Created = DateTime.Now.AddDays(-2),
                SupportResponses = new List<SupportResponseModel> { supportResponseMock.Object }
            };

            var viewModel = new SupportQuestionViewModel(supportQuestionMock);

            Assert.True(viewModel.QuestionHasResponses);

        }

    }
}
