using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Domain.Models;
using ValhallaVaultCyberAwareness.Repositories.Interfaces;

namespace ValhallaVaultCyberAwareness.Repositories
{
    public class SegmentRepository : ISegmentRepository
    {
        public ApplicationDbContext _context { get; set; }

        public SegmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SegmentModel>> GetAllCategoriesAsync()
        {
            return await _context.Segments.ToListAsync();
        }

        /// <summary>
        /// Retrieves one segment with included data (subcategories). 
        /// </summary>
        /// <param name="segmentId"></param>
        /// <returns>The segment that matches the id passed along as parameter, or null if not found. </returns>
        public async Task<SegmentModel?> GetSegmentByIdAsync(int segmentId)
        {
            return await _context.Segments.FirstOrDefaultAsync(s => s.Id == segmentId);
        }

        /// <summary>
        /// Retrieves all segments by category-id. A fail safe is included so that we don't include any questions that doesn't have a correct answer registered.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="userId"></param>
        /// <returns>A list of segments with included data</returns>
        public async Task<List<SegmentModel>> GetSegmentsByCategoryIdAsync(int categoryId, string userId)
        {
            return await _context.Segments
                .Where(s => s.CategoryId == categoryId)
                .Include(s => s.SubCategories)
                .ThenInclude(s => s.Questions.Where(q => q.Answers.Any(a => a.IsCorrect)))
                .ThenInclude(q => q.Answers)
                .ThenInclude(a => a.UserAnswers.Where(u => u.UserId == userId))
                .ToListAsync();
        }
        public async Task<List<SegmentModel>> GetAllSegmentsAsync()
        {
            return await _context.Segments.ToListAsync();
        }
        public async Task<List<SegmentModel>> GetAllSegmentsWithIncludeAsync()
        {
            return await _context.Segments.Include(s => s.Category).ToListAsync();
        }

        private async Task<SegmentModel?> GetSegmentByIdWithoutIncludedDataAsync(int segmentId)
        {
            return await _context.Segments.FirstOrDefaultAsync(s => s.Id == segmentId);
        }

        public async Task<SegmentModel> AddSegmentAsync(SegmentModel newSegment)
        {
            _context.Attach(newSegment);
            await _context.Segments.AddAsync(newSegment);
            await _context.SaveChangesAsync();

            return newSegment;
        }

        public async Task<bool> RemoveSegmentAsync(int segmentId)
        {
            SegmentModel? segmentToRemove = await GetSegmentByIdWithoutIncludedDataAsync(segmentId);
            if (segmentToRemove == null)
            {
                return false;
            }
            else
            {
                try
                {
                    _context.Segments.Remove(segmentToRemove);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public async Task<bool> UpdateSegmentAsync(SegmentModel segment)
        {
            SegmentModel? segmentToUpdate = await GetSegmentByIdWithoutIncludedDataAsync(segment.Id);
            if (segmentToUpdate == null)
            {
                return false;
            }
            else
            {
                try
                {
                    _context.Attach(segmentToUpdate);
                    segmentToUpdate.Name = segment.Name;
                    segmentToUpdate.Description = segment.Description;
                    segmentToUpdate.CategoryId = segment.CategoryId;
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

        }
    }
}
