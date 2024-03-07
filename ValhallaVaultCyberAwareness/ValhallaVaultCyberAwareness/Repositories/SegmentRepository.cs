using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Repositories
{
    public class SegmentRepository : ISegmentRepository
    {
        public ApplicationDbContext _context { get; set; }

        public SegmentRepository(ApplicationDbContext context)
        {
            _context = context;
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
        /// Retrieves all segments by category-id.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="userId"></param>
        /// <returns>A list of segments with included data</returns>
        public async Task<List<SegmentModel>> GetSegmentsByCategoryIdAsync(int categoryId, string userId)
        {
            return await _context.Segments
                .Include(s => s.SubCategories)
                .ThenInclude(s => s.Questions)
                .ThenInclude(q => q.Answers)
                .ThenInclude(a => a.UserAnswers.Where(u => u.UserId == userId))
                .Where(s => s.CategoryId == categoryId)
                .ToListAsync();
        }

        private async Task<SegmentModel?> GetSegmentByIdWithoutIncludedDataAsync(int segmentId)
        {
            return await _context.Segments.FirstOrDefaultAsync(s => s.Id == segmentId);
        }

        public async Task<bool> AddSegmentAsync(SegmentModel newSegment)
        {
            try
            {
                await _context.Segments.AddAsync(newSegment);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
