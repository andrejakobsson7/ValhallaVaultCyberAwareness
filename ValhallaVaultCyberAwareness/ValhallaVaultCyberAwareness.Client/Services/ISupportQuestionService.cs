using ValhallaVaultCyberAwareness.Domain.Models.Support;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public interface ISupportQuestionService
    {
        public HttpClient Client { get; set; }

        public Task<List<SupportQuestionModel>> GetAllSupportQuestionsAsync();

        public Task<bool> AddSupportQuestionAsync(SupportQuestionModel newSupportQuestion);

        public Task<bool> UpdateSupportQuestionAsync(SupportQuestionModel supportQuestionToUpdate);

        public Task<bool> RemoveSupportQuestionAsync(int supportQuestionId);
    }
}
