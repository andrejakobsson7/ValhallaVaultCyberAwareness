using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public ApplicationDbContext _context { get; set; }

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryModel>> GetAllCategoriesWithInclude()
        {
            var categories = await _context.Categories.Include(c => c.Segments).ThenInclude(c => c.SubCategories).ToListAsync();
            return categories;
        }

        public async Task<CategoryModel> GetCategoryById(int categoryId)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
            return category;
        }

        public async Task<CategoryModel> AddCategoryAsync(CategoryModel newCategory)
        {
            await _context.Categories.AddAsync(newCategory);
            await _context.SaveChangesAsync();

            return newCategory;
        }

        public async Task<bool> DeleteCategoryAsync(int Id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == Id);

            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<CategoryModel> UpdateCategoryAsync(CategoryModel category)
        {
            var categoryToUpdate = await _context.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);

            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;

                _context.Attach(categoryToUpdate);
                _context.Entry(categoryToUpdate).Property(p => p.Name).IsModified = true;
                _context.Entry(categoryToUpdate).Property(p => p.Description).IsModified = true;

                await _context.SaveChangesAsync();

                return categoryToUpdate;
            }

            throw new Exception("Category not found");

        }

    }
}