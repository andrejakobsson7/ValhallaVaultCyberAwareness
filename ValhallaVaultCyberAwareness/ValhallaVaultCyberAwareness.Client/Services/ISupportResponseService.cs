using ValhallaVaultCyberAwareness.Domain.Models.Support;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public interface ISupportResponseService
    {
        public HttpClient Client { get; set; }

        public Task<bool> AddSupportResponseAsync(SupportResponseModel newSupportResponse);

        public Task<bool> UpdateSupportResponseAsync(SupportResponseModel supportResponse);

        public Task<bool> RemoveSupportResponseAsync(int supportResponseId);


    }
}
