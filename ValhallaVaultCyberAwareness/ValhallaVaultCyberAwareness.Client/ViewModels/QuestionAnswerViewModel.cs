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
            //Since the repository filters out invalid questions that doesn't have a correct answer registered, all questions that the service receives will have at least one correct answer.
            AnswerModel correctAnswer = question.Answers.First(a => a.IsCorrect);
            CorrectAnswerId = correctAnswer.Id;
            CorrectAnswer = correctAnswer.Answer;
        }
    }
}
