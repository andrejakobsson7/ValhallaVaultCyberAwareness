using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Domain.Models.Support;
using ValhallaVaultCyberAwareness.Repositories.Interfaces;

namespace ValhallaVaultCyberAwareness.Repositories
{
    public class SupportResponseRepository : ISupportResponseRepository
    {
        public ApplicationDbContext _context { get; set; }

        public SupportResponseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddSupportResponseAsync(SupportResponseModel supportResponse)
        {
            try
            {
                await _context.AddAsync(supportResponse);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateSupportResponseAsync(SupportResponseModel supportResponse)
        {
            SupportResponseModel? supportResponseToUpdate = await GetSupportResponseByIdAsync(supportResponse.Id);
            if (supportResponseToUpdate != null)
            {
                supportResponseToUpdate.Response = supportResponse.Response;
                supportResponseToUpdate.AdminName = supportResponse.AdminName;
                supportResponseToUpdate.SupportQuestionId = supportResponse.SupportQuestionId;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteSupportResponseAsync(int id)
        {
            SupportResponseModel? supportResponseToRemove = await GetSupportResponseByIdAsync(id);
            if (supportResponseToRemove != null)
            {
                try
                {
                    _context.Remove(supportResponseToRemove);
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

        private async Task<SupportResponseModel?> GetSupportResponseByIdAsync(int id)
        {
            return await _context.SupportResponses.FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}
