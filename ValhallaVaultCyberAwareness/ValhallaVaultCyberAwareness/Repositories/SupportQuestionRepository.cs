using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Domain.Models.Support;
using ValhallaVaultCyberAwareness.Repositories.Interfaces;

namespace ValhallaVaultCyberAwareness.Repositories
{
    public class SupportQuestionRepository : ISupportQuestionRepository
    {
        public ApplicationDbContext _context { get; set; }

        public SupportQuestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Gets all support questions that is marked as "public" (open for everyone to see), along with all responses that are registered for this question.
        /// </summary>
        /// <returns>A list of supportquestions</returns>
        public async Task<List<SupportQuestionModel>> GetAllSupportQuestionsAsync()
        {
            return await _context.SupportQuestions
                .Where(q => q.IsPublic)
                .Include(q => q.SupportResponses)
                .ToListAsync();
        }

        public async Task<bool> AddSupportQuestionAsync(SupportQuestionModel supportQuestion)
        {
            try
            {
                await _context.AddAsync(supportQuestion);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateSupportQuestionAsync(SupportQuestionModel supportQuestion)
        {
            SupportQuestionModel? supportQuestionToUpdate = await GetSupportQuestionByIdAsync(supportQuestion.Id);
            if (supportQuestionToUpdate != null)
            {
                supportQuestionToUpdate.Question = supportQuestion.Question;
                supportQuestionToUpdate.Username = supportQuestion.Username;
                supportQuestionToUpdate.IsPublic = supportQuestion.IsPublic;
                supportQuestionToUpdate.IsOpen = supportQuestion.IsOpen;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteSupportQuestionAsync(int id)
        {
            SupportQuestionModel? supportQuestionToRemove = await GetSupportQuestionByIdAsync(id);
            if (supportQuestionToRemove != null)
            {
                try
                {
                    _context.Remove(supportQuestionToRemove);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        private async Task<SupportQuestionModel?> GetSupportQuestionByIdAsync(int id)
        {
            return await _context.SupportQuestions.FirstOrDefaultAsync(q => q.Id == id);
        }





    }
}
