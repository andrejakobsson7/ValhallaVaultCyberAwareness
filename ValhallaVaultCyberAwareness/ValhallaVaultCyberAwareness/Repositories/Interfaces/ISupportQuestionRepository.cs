using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Domain.Models.Support;

namespace ValhallaVaultCyberAwareness.Repositories.Interfaces
{
    public interface ISupportQuestionRepository
    {
        public ApplicationDbContext _context { get; set; }

        public Task<List<SupportQuestionModel>> GetAllSupportQuestionsAsync();

        public Task<bool> AddSupportQuestionAsync(SupportQuestionModel supportQuestion);

        public Task<bool> UpdateSupportQuestionAsync(SupportQuestionModel supportQuestion);

        public Task<bool> DeleteSupportQuestionAsync(int id);
    }
}
