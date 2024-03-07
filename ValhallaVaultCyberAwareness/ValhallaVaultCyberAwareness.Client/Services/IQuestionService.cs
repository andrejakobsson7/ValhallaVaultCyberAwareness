using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public interface IQuestionService
    {
        public HttpClient Client { get; set; }

        public Task<List<QuestionModel>> GetAllQuestionsBySubCategoryId(int subCategoryId);
        public Task<QuestionModel> GetQuestionByIdAsync(int questionId);

        public Task<QuestionModel> AddQuestionAsync(QuestionModel newQuestion);

        public Task<bool> RemoveQuestionAsync(int questionId);
        public Task<bool> UpdateQuestionAsync(QuestionModel question);
    }
}
