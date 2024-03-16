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

        public async Task<List<CategoryModel>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<List<CategoryModel>> GetAllCategoriesWithInclude()
        {
            var categories = await _context.Categories.Include(c => c.Segments).ThenInclude(c => c.SubCategories).ToListAsync();
            return categories;
        }
        /// <summary>
        /// Gets all categories along with it's segments, subcategories, questions, answers and useranswers, so we can calculate how many correct answers the user has in this category.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>A list of categories</returns>
        public async Task<List<CategoryModel>> GetAllCategoriesWithUserScores(string userId)
        {
            return await _context.Categories.
                Include(c => c.Segments).
                ThenInclude(s => s.SubCategories).
                ThenInclude(s => s.Questions.Where(q => q.Answers.Any(a => a.IsCorrect))).
                ThenInclude(q => q.Answers).
                ThenInclude(a => a.UserAnswers.Where(u => u.UserId == userId)).
                ToListAsync();
        }
        /// <summary>
        /// Gets a single category along with it's segments, subcategories, questions, answers and useranswers, so we can calculate how many correct answers the user has in this category.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="userId"></param>
        /// <returns>A single category, or null if not found</returns>

        public async Task<CategoryModel?> GetCategoryWithUserScoresByUserIdAsync(int categoryId, string userId)
        {
            return await _context.Categories.Where(c => c.Id == categoryId).
                Include(c => c.Segments).
                ThenInclude(s => s.SubCategories).
                ThenInclude(s => s.Questions.Where(q => q.Answers.Any(a => a.IsCorrect))).
                ThenInclude(q => q.Answers).
                ThenInclude(a => a.UserAnswers.Where(u => u.UserId == userId)).
                FirstOrDefaultAsync();
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