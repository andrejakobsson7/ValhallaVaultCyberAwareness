using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Domain.Models;
using ValhallaVaultCyberAwareness.Repositories.Interfaces;

namespace ValhallaVaultCyberAwareness.Repositories
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        public ApplicationDbContext _context { get; set; }
        public ISegmentRepository _segmentRepository { get; set; }

        public SubCategoryRepository(ApplicationDbContext context, ISegmentRepository segmentRepository)
        {
            _context = context;
            _segmentRepository = segmentRepository;
        }

        public async Task<List<SubCategoryModel>> GetSubCategoriesAsync()
        {
            return await _context.SubCategories.ToListAsync();
        }

        /// <summary>
        /// Gets all subcategories with their segments included
        /// </summary>
        /// <returns>List of segments</returns>
        public async Task<List<SubCategoryModel>> GetSubCategoriesWithIncludeAsync()
        {
            return await _context.SubCategories.Include(s => s.Questions).ToListAsync();
        }

        /// <summary>
        /// Gets a single subcategory by its id
        /// </summary>
        /// <param name="subCategoryId"></param>
        /// <returns>A single category</returns>
        public async Task<SubCategoryModel?> GetSubCategoryByIdAsync(int subCategoryId)
        {
            return await _context.SubCategories.FirstOrDefaultAsync(s => s.Id == subCategoryId);
        }

        public async Task<SubCategoryModel> AddSubCategory(SubCategoryModel newSubCategory)
        {
            //if (newSubCategory.Name == null)
            //{
            //    throw new DbUpdateException("Name cannot be null.");
            //}
            //else if (await _segmentRepository.GetSegmentByIdAsync(newSubCategory.SegmentId) == null)
            //{
            //    throw new DbUpdateException("Segment does not exist.");
            //}
            try
            {
                await _context.SubCategories.AddAsync(newSubCategory);
                await _context.SaveChangesAsync();
                return newSubCategory;
            }
            catch (Exception ex)
            {
                throw new DbUpdateException(ex.InnerException.Message);
            }

        }

        public async Task<bool> DeleteSubCategoryAsync(int Id)
        {
            var subCategory = await _context.SubCategories.FirstOrDefaultAsync(s => s.Id == Id);

            if (subCategory == null)
            {
                throw new ArgumentException($"Sub category does not exist.");

            }
            try
            {
                _context.SubCategories.Remove(subCategory);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw new DbUpdateException(ex.InnerException.Message);

            }

        }

        public async Task<SubCategoryModel> UpdateSubCategoryAsync(SubCategoryModel newSubCategory)
        {

            var subCategoryToUpdate = await _context.SubCategories.FirstOrDefaultAsync(c => c.Id == newSubCategory.Id);

            if (subCategoryToUpdate != null)
            {
                subCategoryToUpdate.Name = newSubCategory.Name;
                subCategoryToUpdate.Description = newSubCategory.Description;
                subCategoryToUpdate.SegmentId = newSubCategory.SegmentId;

                await _context.SaveChangesAsync();

                return subCategoryToUpdate;
            }

            throw new ArgumentException("SubCategory does not exist.");

        }
    }
}
