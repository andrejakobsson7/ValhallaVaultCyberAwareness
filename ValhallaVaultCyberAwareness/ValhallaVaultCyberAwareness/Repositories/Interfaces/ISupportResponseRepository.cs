using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Domain.Models.Support;

namespace ValhallaVaultCyberAwareness.Repositories.Interfaces
{
	public interface ISupportResponseRepository
	{
		public ApplicationDbContext _context { get; set; }

		public Task<bool> AddSupportResponseAsync(SupportResponseModel supportResponse);

		public Task<bool> UpdateSupportResponseAsync(SupportResponseModel supportResponse);

		public Task<bool> DeleteSupportResponseAsync(int id);
        Task GetAllQuestionsWithResponsesAsync();
    }
}
