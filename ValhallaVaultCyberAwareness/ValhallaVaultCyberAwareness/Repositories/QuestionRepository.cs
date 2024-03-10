using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Domain.Models;
using ValhallaVaultCyberAwareness.Repositories.Interfaces;

namespace ValhallaVaultCyberAwareness.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        ApplicationDbContext _context;

        public QuestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<QuestionModel>> GetAllQuestionsAsync()
        {
            var questions = await _context.Questions.ToListAsync();
            return questions;
        }
        /// <summary>
        /// Method used to retrieve all questions in a subcategory. There is a safety check that verifies that all questions have a correct answer registered.
        /// </summary>
        /// <param name="subCategoryId"></param>
        /// <returns>A list of questions along with it's answers</returns>
        public async Task<List<QuestionModel>> GetQuestionsBySubCategoryIdAsync(int subCategoryId)
        {
            return await _context.Questions
                .Where(q => q.SubCategoryId == subCategoryId && q.Answers.Any(a => a.IsCorrect))
                .Include(q => q.Answers)
                .ToListAsync();
        }

        public async Task<QuestionModel> AddQuestionAsync(QuestionModel newQuestion)
        {
            await _context.Questions.AddAsync(newQuestion);
            await _context.SaveChangesAsync();

            return newQuestion;
        }

        public async Task<bool> DeleteQuestionAsync(int Id)
        {
            var question = await _context.Questions.FirstOrDefaultAsync(q => q.Id == Id);

            if (question != null)
            {
                _context.Questions.Remove(question);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<QuestionModel> UpdateQuestionAsync(QuestionModel question)
        {
            var questionToUpdate = await _context.Questions.FirstOrDefaultAsync(q => q.Id == question.Id);

            if (questionToUpdate != null)
            {
                questionToUpdate.Question = question.Question;
                questionToUpdate.Explanation = question.Explanation;
                await _context.SaveChangesAsync();
                return questionToUpdate;
            }

            throw new Exception("Question not found");

        }
    }
}
