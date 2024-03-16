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
				//await RemoveFromCategorySegmentAndGeneralCache(subCategoryToAdd.Segment!.CategoryId, subCategoryToAdd.SegmentId, cancellationToken);
				await CacheManager.RemoveFromCategorySegmentAndGeneralCache(subCategoryToAdd.Segment!.CategoryId, subCategoryToAdd.SegmentId, cancellationToken, _outputCacheStore);
				var subCategoryJson = JsonSerializer.Serialize(subCategoryToAdd, _jsonSerializerOptions);
				return Ok(subCategoryJson);
			}

			return BadRequest();
		}

		[HttpPut]
		[Route("{subCategoryId}")]
		//Maybe I can't use ByIdCachePolicy here??
		[OutputCache(PolicyName = "ByIdCachePolicy")]
		public async Task<ActionResult> UpdateSubCategory(SubCategoryModel subCategory, CancellationToken cancellationToken)
		{
			var updatedSubCategory = await _subCategoryRepo.UpdateSubCategoryAsync(subCategory);

			if (updatedSubCategory != null)
			{
				//When a subcategory is updated, we need to update the general cache and remove from category, segment and subcategory by respective ID, since we have calls per ID where subcategory is included.
				//await RemoveFromCategorySegmentSubCategoryAndGeneralCache(updatedSubCategory.Segment!.CategoryId, updatedSubCategory.SegmentId, updatedSubCategory.Id, cancellationToken);
				await CacheManager.RemoveFromCategorySegmentSubCategoryAndGeneralCache(updatedSubCategory.Segment!.CategoryId, updatedSubCategory.SegmentId, updatedSubCategory.Id, cancellationToken, _outputCacheStore);
				var subCategoryJson = JsonSerializer.Serialize(updatedSubCategory, _jsonSerializerOptions);
				return Ok(subCategoryJson);

			}
			return BadRequest();
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
				//await RemoveFromCategorySegmentSubCategoryAndGeneralCache(deletedSubCategory.Segment!.CategoryId, deletedSubCategory.SegmentId, deletedSubCategory.Id, cancellationToken);
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