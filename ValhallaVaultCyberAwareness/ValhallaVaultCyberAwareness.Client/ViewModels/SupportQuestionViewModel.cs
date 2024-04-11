using ValhallaVaultCyberAwareness.Domain.Models.Support;


namespace ValhallaVaultCyberAwareness.Client.ViewModels
{
    public class SupportQuestionViewModel
    {
        public int Id { get; set; }
        public string? Question { get; set; }
        public string? Username { get; set; }
        public double DaysSincePost { get; set; }
        public bool DisplayAnswers { get; set; }
        public bool HasAcceptedTerms { get; set; }
        public bool QuestionHasResponses { get; set; }
        public bool IsAnsweringEnabled { get; set; }
        public List<SupportResponseModel> SupportResponses { get; set; } = new();

        public SupportQuestionViewModel(SupportQuestionModel supportQuestion)
        {
            InitializeFromSupportQuestion(supportQuestion);
        }

        public SupportQuestionViewModel()
        {
            // Default constructor
        }

        private void InitializeFromSupportQuestion(SupportQuestionModel supportQuestion)
        {
            SetId(supportQuestion.Id);
            SetQuestion(supportQuestion.Question);
            SetUsername(supportQuestion.Username);
            CalculateDaysSincePost(supportQuestion.Created);
            InitializeSupportResponses(supportQuestion.SupportResponses);
            CheckIfQuestionHasResponses();
        }

        private void SetId(int id)
        {
            Id = id;
        }

        private void SetQuestion(string question)
        {
            Question = question;
        }

        private void SetUsername(string username)
        {
            Username = username;
        }

        private void CalculateDaysSincePost(DateTime created)
        {
            DaysSincePost = Math.Round((DateTime.Now - created).TotalDays);
        }

        private void InitializeSupportResponses(List<SupportResponseModel> responses)
        {
            SupportResponses = responses;
        }

        private void CheckIfQuestionHasResponses()
        {
            QuestionHasResponses = SupportResponses.Count > 0;
        }
    }
}
