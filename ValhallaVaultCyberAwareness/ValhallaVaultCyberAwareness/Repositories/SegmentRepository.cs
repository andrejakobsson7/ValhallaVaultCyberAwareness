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
            return await _context.Segments.Include(s => s.SubCategories).FirstOrDefaultAsync(s => s.Id == segmentId);
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
