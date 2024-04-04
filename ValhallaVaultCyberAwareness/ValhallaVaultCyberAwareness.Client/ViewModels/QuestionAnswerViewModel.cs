using System.ComponentModel.DataAnnotations;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.ViewModels
{

    public class QuestionAnswerViewModel
    {
        public int QuestionId { get; set; }
        public string? Question { get; set; }
        public string? Explanation { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "No answer has been selected.")]
        public int UserAnswerId { get; set; }
        public List<AnswerModel> Answers { get; set; } = new();
        public int CorrectAnswerId { get; set; }
        public string? CorrectAnswer { get; set; }

        public bool IsAnswerSubmitted { get; set; }
        public QuestionAnswerViewModel(QuestionModel question)
        {
            QuestionId = GetQuestionId(question.Id);
            Question = GetQuestion(question.Question);
            Explanation = GetExplanation(question.Explanation);
            Answers = GetAnswers(question.Answers);
            //Since the repository filters out invalid questions that doesn't have a correct answer registered, all questions that the service receives will have at least one correct answer.
            CorrectAnswerId = GetCorrectAnswerId(question);
            CorrectAnswer = GetCorrectAnswer(question);
            /*
            AnswerModel correctAnswer = question.Answers.First(a => a.IsCorrect);
            CorrectAnswerId = correctAnswer.Id;
            CorrectAnswer = correctAnswer.Answer;
            */
        }

        public QuestionAnswerViewModel()
        {

        }

        public int GetQuestionId(int id)
        {
            return id;
        }
        public string GetQuestion(string question)
        {
            return question;
        }
        public string GetExplanation(string explanation)
        {
            return explanation;
        }
        public List<AnswerModel> GetAnswers(List<AnswerModel> answers)
        {
            return answers.ToList();
        }
        public int GetCorrectAnswerId(QuestionModel question)
        {
            AnswerModel correctAnswer = question.Answers.First(a => a.IsCorrect);
            return correctAnswer.Id;
        }
        public string? GetCorrectAnswer(QuestionModel question)
        {
            AnswerModel correctAnswer = question.Answers.First(a => a.IsCorrect);
            return correctAnswer.Answer;
        }
    }
}
