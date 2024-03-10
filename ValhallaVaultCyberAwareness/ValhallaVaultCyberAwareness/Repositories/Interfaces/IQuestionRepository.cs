using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        Task<List<QuestionModel>> GetAllQuestionsAsync();
        Task<List<QuestionModel>> GetQuestionsBySubCategoryIdAsync(int subCategoryId);
        Task<QuestionModel> AddQuestionAsync(QuestionModel newQuestion);
        Task<bool> DeleteQuestionAsync(int Id);
        Task<QuestionModel> UpdateQuestionAsync(QuestionModel question);
    }
}
