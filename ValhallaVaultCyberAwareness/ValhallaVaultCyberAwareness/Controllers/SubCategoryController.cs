using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using System.Text.Json;
using System.Text.Json.Serialization;
using ValhallaVaultCyberAwareness.Cache;
using ValhallaVaultCyberAwareness.Domain.Models;
using ValhallaVaultCyberAwareness.Repositories.Interfaces;

namespace ValhallaVaultCyberAwareness.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SubCategoryController : ControllerBase
	{
		public ISubCategoryRepository _subCategoryRepo;
		private readonly IOutputCacheStore _outputCacheStore;
		private JsonSerializerOptions _jsonSerializerOptions = new()
		{
			ReferenceHandler = ReferenceHandler.Preserve
		};

		public SubCategoryController(ISubCategoryRepository subCategoryRepo, IOutputCacheStore outputCacheStore)
		{
			_subCategoryRepo = subCategoryRepo;
			_outputCacheStore = outputCacheStore;
		}
		[HttpGet]
		[Route("{subCategoryId}")]
		[OutputCache(PolicyName = "ByIdCachePolicy")]

		public async Task<IActionResult> GetSubCategoryById(int subCategoryId)
		{
			var subCategory = await _subCategoryRepo.GetSubCategoryByIdAsync(subCategoryId);

			if (subCategory != null)
			{
				return Ok(subCategory);
			}

			return BadRequest();
		}

		[HttpPost]
		[OutputCache(PolicyName = "Category-Segment-SubCategoryPolicy")]
		public async Task<ActionResult> AddSubCategory(SubCategoryModel newSubCategory, CancellationToken cancellationToken)
		{
			var subCategoryToAdd = await _subCategoryRepo.AddSubCategory(newSubCategory);
			if (subCategoryToAdd != null)
			{
				//When a subcategory has been added, we need to evict the shared tag for category and segment since subcategory is included in general calls (without parameter).
				//There is no need to remove subcategory by ID here, since it's new and cannot exist in any cache
				await CacheManager.RemoveFromCategorySegmentAndGeneralCache(subCategoryToAdd.Segment!.CategoryId, subCategoryToAdd.SegmentId, cancellationToken, _outputCacheStore);
				var subCategoryJson = JsonSerializer.Serialize(subCategoryToAdd, _jsonSerializerOptions);
				return Ok(subCategoryJson);
			}

			return BadRequest();
		}

		[HttpPut]
		[Route("{subCategoryId}")]
		[OutputCache(PolicyName = "ByIdCachePolicy")]
		public async Task<ActionResult> UpdateSubCategory(SubCategoryModel subCategory, CancellationToken cancellationToken)
		{
			//Here we need to figure out if the subcategory is changing it's Foreign Key (segment-ID). If it does, we need to evict both the old and new segment-id and category-ID from the cache
			try
			{
				SubCategoryModel? subCategoryToUpdate = await _subCategoryRepo.GetSubCategoryByIdAsync(subCategory.Id);
				if (subCategoryToUpdate != null)
				{
        	//Store the original segment- and categoryinfo.
					int originalSegmentId = subCategoryToUpdate.SegmentId;
					int originalCategoryId = subCategoryToUpdate.Segment!.CategoryId;
					SubCategoryModel? updatedSubCategory = await _subCategoryRepo.UpdateSubCategoryAsync(subCategory);
					if (updatedSubCategory != null)
					{
						if (updatedSubCategory.SegmentId != originalSegmentId && updatedSubCategory.Segment.CategoryId != originalCategoryId)
						{
							//The subcategory has moved from one segment that belongs to another category. Evict old segment and old category by ID
							await CacheManager.RemoveFromCategorySegmentSubCategoryAndGeneralCache(originalCategoryId, originalSegmentId, updatedSubCategory.Id, cancellationToken, _outputCacheStore);
						}
						//Always evivct the new/current categoryID and segmentID from the cache
						await CacheManager.RemoveFromCategorySegmentSubCategoryAndGeneralCache(updatedSubCategory.Segment!.CategoryId, updatedSubCategory.SegmentId, updatedSubCategory.Id, cancellationToken, _outputCacheStore);
						return Ok();
					}
				}
				return NotFound();
			}
			catch (ArgumentNullException ex)
			{
				return NotFound(ex.Message);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[HttpDelete]
		[Route("{subCategoryId}")]
		[OutputCache(PolicyName = "ByIdCachePolicy")]
		public async Task<ActionResult> DeleteSubCategory(int subCategoryId, CancellationToken cancellationToken)
		{
			try
			{
				SubCategoryModel deletedSubCategory = await _subCategoryRepo.DeleteSubCategoryAsync(subCategoryId);
				//Evict from all caches
				await CacheManager.RemoveFromCategorySegmentSubCategoryAndGeneralCache(deletedSubCategory.Segment!.CategoryId, deletedSubCategory.SegmentId, deletedSubCategory.Id, cancellationToken, _outputCacheStore);

				return Ok();
			}
			catch (ArgumentNullException ex)
			{
				return NotFound(ex.Message);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

	}
}