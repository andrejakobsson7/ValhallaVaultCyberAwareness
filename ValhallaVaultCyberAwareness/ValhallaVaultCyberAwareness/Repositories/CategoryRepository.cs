using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Repositories
{
    public class CategoryRepository
    {
        ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryModel>> GetAllCategories()
        {
            var categories = await _context.Categories.Include(c => c.Segments).ThenInclude(c => c.SubCategories).ToListAsync();
            return categories;
        }

        public async Task<CategoryModel> GetCategoryById(int categoryId)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
            return category;
        }

    }
}
