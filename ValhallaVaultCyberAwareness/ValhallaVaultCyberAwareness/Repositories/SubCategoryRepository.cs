using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Repositories
{
    public class SubCategoryRepository
    {
        ApplicationDbContext _context;

        public SubCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SubCategoryModel>> GetSubCategoryBySegmentId(int segmentId)
        {
            var subCategories = await _context.SubCategories.Where(s => s.SegmentId == segmentId).ToListAsync();
            return subCategories;
        }
    }
}
