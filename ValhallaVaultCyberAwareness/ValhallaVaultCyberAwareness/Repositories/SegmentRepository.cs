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
            try
            {
                return await _context.Segments.Where(s => s.Id == segmentId).
                    Include(s => s.SubCategories).
                    ThenInclude(s => s.Questions.Where(q => q.Answers.Any(a => a.IsCorrect))).
                    ThenInclude(q => q.Answers).
                    ThenInclude(a => a.UserAnswers.Where(u => u.UserId == userId)).
                    FirstOrDefaultAsync();
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

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
            try
            {
                await _context.Segments.AddAsync(newSegment);
                await _context.SaveChangesAsync();
                return newSegment;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Something went wrong when saving to the database: Detailed information about the exception:\n{ex.Message}\nInner exception:\n{ex.InnerException.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> RemoveSegmentAsync(int segmentId)
        {
            SegmentModel? segmentToRemove = await GetSegmentByIdWithoutIncludedDataAsync(segmentId);
            if (segmentToRemove == null)
            {
                throw new ArgumentException($"Segment with id {segmentId} could not be found");
            }
            else
            {
                try
                {
                    _context.Segments.Remove(segmentToRemove);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (DbUpdateException ex)
                {
                    throw new DbUpdateException($"Something went wrong when saving to the database. Detailed information about the exception:\n{ex.Message}\n{ex.InnerException.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task<SegmentModel?> UpdateSegmentAsync(SegmentModel segment)
        {
            SegmentModel? segmentToUpdate = await GetSegmentByIdWithoutIncludedDataAsync(segment.Id);
            if (segmentToUpdate == null)
            {
                throw new ArgumentException($"Segment with id {segment.Id} could not be found");
            }
            else
            {
                try
                {
                    segmentToUpdate.Name = segment.Name;
                    segmentToUpdate.Description = segment.Description;
                    segmentToUpdate.CategoryId = segment.CategoryId;
                    await _context.SaveChangesAsync();
                    return segmentToUpdate;
                }
                catch (DbUpdateException ex)
                {
                    throw new DbUpdateException($"Something went wrong when saving to the database.\nDetailed information about the exception:\n {ex.Message}\n{ex.InnerException.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

        }
    }
}
