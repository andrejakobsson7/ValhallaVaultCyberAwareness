using Microsoft.AspNetCore.OutputCaching;

namespace ValhallaVaultCyberAwareness.Cache
{
	public static class CacheManager
	{
		//Category cache
		public static async Task RemoveFromCategoryCache(int categoryId, CancellationToken cancellationToken, IOutputCacheStore outputCacheStore)
		{
			//Delete the category-ID that the updated/removed segment belonged to
			await outputCacheStore.EvictByTagAsync("category_" + categoryId.ToString(), cancellationToken);
		}

		public static async Task RemoveFromGeneralCache(CancellationToken cancellationToken, IOutputCacheStore outputCacheStore)
		{
			//Remove from general cache
			await outputCacheStore.EvictByTagAsync("Category-Segment-SubCategoryPolicy_Tag", cancellationToken);
		}

		public static async Task RemoveFromCategoryAndGeneralCache(int categoryId, CancellationToken cancellationToken, IOutputCacheStore outputCacheStore)
		{
			await RemoveFromCategoryCache(categoryId, cancellationToken, outputCacheStore);
			await RemoveFromGeneralCache(cancellationToken, outputCacheStore);
		}

		//Segment

		public static async Task RemoveFromSegmentCache(int segmentId, CancellationToken cancellationToken, IOutputCacheStore outputCacheStore)
		{
			//Delete segment by Segment-ID in the cache
			await outputCacheStore.EvictByTagAsync("segment_" + segmentId.ToString(), cancellationToken);
		}

		public static async Task RemoveFromCategorySegmentAndGeneralCache(int categoryId, int segmentId, CancellationToken cancellationToken, IOutputCacheStore outputCacheStore)
		{
			await RemoveFromCategoryCache(categoryId, cancellationToken, outputCacheStore);
			await RemoveFromSegmentCache(segmentId, cancellationToken, outputCacheStore);
			await RemoveFromGeneralCache(cancellationToken, outputCacheStore);
		}

		//Subcategory cache
		public static async Task RemoveFromSubCategoryCache(int subCategoryId, CancellationToken cancellationToken, IOutputCacheStore outputCacheStore)
		{
			//Delete subcategory by id in the cache
			await outputCacheStore.EvictByTagAsync("subCategory_" + subCategoryId.ToString(), cancellationToken);
		}

		public static async Task RemoveFromCategorySegmentSubCategoryAndGeneralCache(int categoryId, int segmentId, int subCategoryId, CancellationToken cancellationToken, IOutputCacheStore outputCacheStore)
		{
			await RemoveFromCategoryCache(categoryId, cancellationToken, outputCacheStore);
			await RemoveFromSegmentCache(segmentId, cancellationToken, outputCacheStore);
			await RemoveFromSubCategoryCache(subCategoryId, cancellationToken, outputCacheStore);
			await RemoveFromGeneralCache(cancellationToken, outputCacheStore);
		}
	}
}
