using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Domain.Models;
using ValhallaVaultCyberAwareness.Repositories.Interfaces;

namespace ValhallaVaultCyberAwareness.Repositories
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        public ApplicationDbContext _context { get; set; }

        public SubCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<SubCategoryModel>> GetSubCategoriesWithIncludeAsync()
        {
            return await _context.SubCategories.Include(s => s.Segment).ToListAsync();
        }
        public async Task<List<SubCategoryModel>> GetSubCategoriesBySegmentId(int segmentId)
        {
            var subCategories = await _context.SubCategories.Where(s => s.SegmentId == segmentId).ToListAsync();
            return subCategories;
        }

        public async Task<SubCategoryModel> AddSubCategory(SubCategoryModel newSubCategory)
        {
            try
            {
                var local = _context.SubCategories.FirstOrDefault(s => s.Id == newSubCategory.Id);
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }

                await _context.SubCategories.AddAsync(newSubCategory);
                await _context.SaveChangesAsync();
                return newSubCategory;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }

        }

        public async Task<bool> DeleteSubCategoryAsync(int Id)
        {
            var subCategory = await _context.SubCategories.FirstOrDefaultAsync(s => s.Id == Id);

            if (subCategory != null)
            {
                _context.SubCategories.Remove(subCategory);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<SubCategoryModel> UpdateSubCategoryAsync(SubCategoryModel newSubCategory)
        {
            var subCategoryToUpdate = await _context.SubCategories.FirstOrDefaultAsync(c => c.Id == newSubCategory.Id);

            if (subCategoryToUpdate != null)
            {
                _context.Attach(subCategoryToUpdate);

                subCategoryToUpdate.Name = newSubCategory.Name;
                subCategoryToUpdate.Description = newSubCategory.Description;
                subCategoryToUpdate.SegmentId = newSubCategory.SegmentId;

                await _context.SaveChangesAsync();

                return subCategoryToUpdate;
            }

            throw new Exception("Sub category not found");

        }

    }
}
