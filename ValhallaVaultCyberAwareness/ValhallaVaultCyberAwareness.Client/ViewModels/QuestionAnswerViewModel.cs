using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.ViewModels
{

    public class QuestionAnswerViewModel
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string Explanation { get; set; }
        public int UserAnswerId { get; set; }
        public List<AnswerModel> Answers { get; set; } = new();
        public int CorrectAnswerId { get; set; }
        public string CorrectAnswer { get; set; }
        public QuestionAnswerViewModel(QuestionModel question)
        {
            QuestionId = question.Id;
            Question = question.Question;
            Explanation = question.Explanation;
            Answers = question.Answers;
            var correctAnswer = question.Answers.FirstOrDefault(a => a.IsCorrect);
            if (correctAnswer == null)
            {
                CorrectAnswerId = -1;
                CorrectAnswer = "Unfortunately there is no correct answer registered for this question.";
            }
            else
            {
                CorrectAnswerId = correctAnswer.Id;
                CorrectAnswer = correctAnswer.Answer;
            }
        }
    }
}
