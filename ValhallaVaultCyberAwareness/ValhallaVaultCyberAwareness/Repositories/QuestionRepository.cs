using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Repositories
{
    public class QuestionRepository
    {
        ApplicationDbContext _context;

        public QuestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<QuestionModel>> GetAllQuestions()
        {
            var questions = await _context.Questions.ToListAsync();
            return questions;
        }
        public async Task<List<QuestionModel>> GetAllQuestionsSubCategory(int subCategoryId)
        {
            var questions = await _context.Questions.Where(q => q.SubCategoryId == subCategoryId).ToListAsync();
            return questions;
        }
    }
}
