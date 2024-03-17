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

		public async Task<List<SubCategoryModel>> GetSubCategoriesAsync()
		{
			return await _context.SubCategories.ToListAsync();
		}
		public async Task<List<SubCategoryModel>> GetSubCategoriesWithIncludeAsync()
		{
			return await _context.SubCategories.Include(s => s.Segment).ToListAsync();
		}
		public async Task<SubCategoryModel?> GetSubCategoryByIdAsync(int subCategoryId)
		{
			return await _context.SubCategories.Where(s => s.Id == subCategoryId).Include(s => s.Segment).FirstOrDefaultAsync();
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

				var newSub = await _context.SubCategories.AddAsync(newSubCategory);
				await _context.SaveChangesAsync();
				return await GetSubCategoryByIdWithIncludedData(newSub.Entity.Id);
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
				return null;
			}

		}

		public async Task<SubCategoryModel?> DeleteSubCategoryAsync(int subCategoryId)
		{
			SubCategoryModel? subCategory = await GetSubCategoryByIdWithIncludedData(subCategoryId);

			if (subCategory == null)
			{
				throw new ArgumentNullException(message: $"Segment with Id {subCategoryId} could not be found", null);
			}
			else
			{
				try
				{
					var deletedSubCategory = _context.SubCategories.Remove(subCategory);
					await _context.SaveChangesAsync();
					return deletedSubCategory.Entity;
				}
				catch (Exception)
				{
					return null;
				}

			}
		}

		public async Task<SubCategoryModel?> UpdateSubCategoryAsync(SubCategoryModel newSubCategory)
		{
			var subCategoryToUpdate = await GetSubCategoryByIdWithIncludedData(newSubCategory.Id);
			if (subCategoryToUpdate == null)
			{
				throw new ArgumentNullException(message: $"Subcategory with Id {newSubCategory.Id} could not be found", null);
			}
			else
			{
				try
				{
					_context.Attach(subCategoryToUpdate);

					subCategoryToUpdate.Name = newSubCategory.Name;
					subCategoryToUpdate.Description = newSubCategory.Description;
					subCategoryToUpdate.SegmentId = newSubCategory.SegmentId;

					await _context.SaveChangesAsync();

					return await GetSubCategoryByIdWithIncludedData(subCategoryToUpdate.Id);
				}
				catch (Exception)
				{
					return null;
				}
			}
		}

		private async Task<SubCategoryModel> GetSubCategoryByIdWithIncludedData(int subCategoryId)
		{
			return await _context.SubCategories.Where(s => s.Id == subCategoryId).Include(s => s.Segment).FirstOrDefaultAsync();
		}
	}
}
