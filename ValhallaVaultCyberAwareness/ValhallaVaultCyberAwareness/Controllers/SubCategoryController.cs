using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using System.Text.Json;
using System.Text.Json.Serialization;
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
				await RemoveFromCategorySegmentAndGeneralCache(subCategoryToAdd.Segment!.CategoryId, subCategoryToAdd.SegmentId, cancellationToken);
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
			var updatedSubCategory = await _subCategoryRepo.UpdateSubCategoryAsync(subCategory);

			if (updatedSubCategory != null)
			{
				//When a subcategory is updated, we need to update the general cache and remove from category, segment and subcategory by respective ID, since we have calls per ID where subcategory is included.
				await RemoveFromCategorySegmentSubCategoryAndGeneralCache(updatedSubCategory.Segment!.CategoryId, updatedSubCategory.SegmentId, updatedSubCategory.Id, cancellationToken);
				var subCategoryJson = JsonSerializer.Serialize(updatedSubCategory, _jsonSerializerOptions);
				return Ok(subCategoryJson);

			}
			return BadRequest();
		}

		[HttpDelete]
		[Route("{subCategoryId}")]
		public async Task<ActionResult> DeleteSubCategory(int subCategoryId, CancellationToken cancellationToken)
		{
			try
			{
				SubCategoryModel deletedSubCategory = await _subCategoryRepo.DeleteSubCategoryAsync(subCategoryId);
				//Evict from all caches
				await RemoveFromCategorySegmentSubCategoryAndGeneralCache(deletedSubCategory.Segment!.CategoryId, deletedSubCategory.SegmentId, deletedSubCategory.Id, cancellationToken);
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

		private async Task RemoveFromGeneralCache(CancellationToken cancellationToken)
		{
			//Remove from general cache since we have a call that gets all categories with subcategories included
			await _outputCacheStore.EvictByTagAsync("Category-Segment-SubCategoryPolicy_Tag", cancellationToken);
		}

		private async Task RemoveFromSegmentCache(int segmentId, CancellationToken cancellationToken)
		{
			//Delete the segment-ID that the updated/removed subcategory belonged to
			await _outputCacheStore.EvictByTagAsync(segmentId.ToString(), cancellationToken);
		}
		private async Task RemoveFromCategoryCache(int categoryId, CancellationToken cancellationToken)
		{
			//Delete the category-ID that the updated/removed subcategory's segment belonged to
			await _outputCacheStore.EvictByTagAsync(categoryId.ToString(), cancellationToken);
		}

		private async Task RemoveFromSubCategoryCache(int subCategoryId, CancellationToken cancellationToken)
		{
			//Delete subcategory by id in the cache
			await _outputCacheStore.EvictByTagAsync(subCategoryId.ToString(), cancellationToken);
		}
		private async Task RemoveFromCategorySegmentAndGeneralCache(int categoryId, int segmentId, CancellationToken cancellationToken)
		{
			await RemoveFromCategoryCache(categoryId, cancellationToken);
			await RemoveFromSegmentCache(segmentId, cancellationToken);
			await RemoveFromGeneralCache(cancellationToken);
		}

		private async Task RemoveFromCategorySegmentSubCategoryAndGeneralCache(int categoryId, int segmentId, int subCategoryId, CancellationToken cancellationToken)
		{
			await RemoveFromCategoryCache(categoryId, cancellationToken);
			await RemoveFromSegmentCache(segmentId, cancellationToken);
			await RemoveFromSubCategoryCache(subCategoryId, cancellationToken);
			await RemoveFromGeneralCache(cancellationToken);
		}

	}
}