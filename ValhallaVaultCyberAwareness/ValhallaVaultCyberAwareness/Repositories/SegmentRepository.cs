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
		/// Retrieves one segment with included data (subcategories). 
		/// </summary>
		/// <param name="segmentId"></param>
		/// <returns>The segment that matches the id passed along as parameter, or null if not found. </returns>
		public async Task<SegmentModel?> GetSegmentByIdAsync(int segmentId)
		{
			return await _context.Segments.FirstOrDefaultAsync(s => s.Id == segmentId);
		}
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
		public async Task<List<SegmentModel>> GetAllSegmentsWithIncludeAsync()
		{
			return await _context.Segments.Include(s => s.Category).ToListAsync();
		}

		private async Task<SegmentModel?> GetSegmentByIdWithoutIncludedDataAsync(int segmentId)
		{
			return await _context.Segments.FirstOrDefaultAsync(s => s.Id == segmentId);
		}

		public async Task<SegmentModel?> AddSegmentAsync(SegmentModel newSegment)
		{
			try
			{
				await _context.Segments.AddAsync(newSegment);
				await _context.SaveChangesAsync();
				return newSegment;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public async Task<SegmentModel> RemoveSegmentAsync(int segmentId)
		{
			SegmentModel? segmentToRemove = await GetSegmentByIdWithoutIncludedDataAsync(segmentId);
			if (segmentToRemove == null)
			{
				throw new ArgumentNullException(message: $"Segment with Id {segmentId} could not be found", null);
			}
			else
			{
				try
				{
					var deletedSegment = _context.Segments.Remove(segmentToRemove);
					await _context.SaveChangesAsync();
					return deletedSegment.Entity;
				}
				catch (Exception)
				{
					return null;
				}
			}
		}

		public async Task<bool> UpdateSegmentAsync(SegmentModel segment)
		{
			SegmentModel? segmentToUpdate = await GetSegmentByIdWithoutIncludedDataAsync(segment.Id);
			if (segmentToUpdate == null)
			{
				throw new ArgumentNullException(message: $"Segment with Id {segment.Id} could not be found", null);
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
