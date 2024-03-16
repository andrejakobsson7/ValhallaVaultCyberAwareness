using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Domain.Models;
using ValhallaVaultCyberAwareness.Repositories.Interfaces;

namespace ValhallaVaultCyberAwareness.Repositories
{
    public class AnswersRepository : IAnswersRepository
    {
        private readonly ApplicationDbContext _context;

        public AnswersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all answers by their question id
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns>A list of Answers</returns>
        public async Task<List<AnswerModel>> GetAnswersByQuestionIdAsync(int questionId)
        {
            return await _context.Answers.Where(a => a.QuestionId == questionId).ToListAsync();
        }

        public async Task<AnswerModel> UpdateAnswerAsync(AnswerModel newAnswer)
        {
            var answerToUpdate = await _context.Answers.FirstOrDefaultAsync(a => a.Id == newAnswer.Id);

            if (answerToUpdate != null)
            {
                answerToUpdate.Answer = newAnswer.Answer;
                answerToUpdate.IsCorrect = newAnswer.IsCorrect;
                await _context.SaveChangesAsync();
                return answerToUpdate;
            }

            throw new Exception("Answer not found");
        }

    }
}
