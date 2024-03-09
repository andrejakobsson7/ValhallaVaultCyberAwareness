using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Domain.Models;

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
        public async Task<List<QuestionModel>> GetQuestionsBySubCategoryIdAsync(int subCategoryId)
        {
            return await _context.Questions
                .Include(q => q.Answers)
                .Where(q => q.SubCategoryId == subCategoryId)
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
