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

        /// <summary>
        /// Gets a segment by its id
        /// </summary>
        /// <param name="segmentId"></param>
        /// <returns>A single segment</returns>
        public async Task<SegmentModel?> GetSegmentByIdAsync(int segmentId)
        {
            return await _context.Segments.FirstOrDefaultAsync(s => s.Id == segmentId);
        }

        /// <summary>
        /// Gets a single segment by Id along with it's subcategories, questions, answers and all registered useranswers, so we can calculate how many correct answers the user has in this particular segment.
        /// 
        /// </summary>
        /// <param name="segmentId"></param>
        /// <param name="userId"></param>
        /// <returns>A segment or null if not found</returns>
        public async Task<SegmentModel?> GetSegmentWithUserScoresByUserIdAsync(int segmentId, string userId)
        {
            return await _context.Segments.Where(s => s.Id == segmentId).
                Include(s => s.SubCategories).
                ThenInclude(s => s.Questions.Where(q => q.Answers.Any(a => a.IsCorrect))).
                ThenInclude(q => q.Answers).
                ThenInclude(a => a.UserAnswers.Where(u => u.UserId == userId)).
                FirstOrDefaultAsync();
        }

        public async Task<List<SegmentModel>> GetAllSegmentsAsync()
        {
            return await _context.Segments.ToListAsync();
        }

        /// <summary>
        /// Gets all segments including their categories
        /// </summary>
        /// <returns>A list of segments</returns>
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
