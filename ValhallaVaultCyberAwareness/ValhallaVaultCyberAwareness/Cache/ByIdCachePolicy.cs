using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Primitives;

namespace ValhallaVaultCyberAwareness.Cache
{
    public class ByIdCachePolicy : IOutputCachePolicy
    {
        public ValueTask CacheRequestAsync(OutputCacheContext context, CancellationToken cancellation)
        {
            //Extract all id's we are interested in to use for invalidating the cache.
            var userId = context.HttpContext.Request.RouteValues["userId"];
            var categoryId = context.HttpContext.Request.RouteValues["categoryId"];
            var segmentId = context.HttpContext.Request.RouteValues["segmentId"];
            var subCategoryId = context.HttpContext.Request.RouteValues["subCategoryId"];
            var questionId = context.HttpContext.Request.RouteValues["questionId"];
            if (userId != null)
            {
                context.Tags.Add(userId.ToString()!);
            }
            if (categoryId != null)
            {
                context.Tags.Add(categoryId.ToString()!);
            }
            if (segmentId != null)
            {
                context.Tags.Add(segmentId.ToString()!);
            }
            if (subCategoryId != null)
            {
                context.Tags.Add(subCategoryId.ToString()!);
            }
            if (questionId != null)
            {
                context.Tags.Add(questionId.ToString()!);
            }
            return ValueTask.CompletedTask;
        }

        public ValueTask ServeFromCacheAsync(OutputCacheContext context, CancellationToken cancellation)
        {
            return ValueTask.CompletedTask;
        }

        public ValueTask ServeResponseAsync(OutputCacheContext context, CancellationToken cancellation)
        {
            var response = context.HttpContext.Response;

            // Verify existence of cookie headers
            if (!StringValues.IsNullOrEmpty(response.Headers.SetCookie))
            {
                context.AllowCacheStorage = false;
                return ValueTask.CompletedTask;
            }

            // Check response code
            if (response.StatusCode != StatusCodes.Status200OK)
            {
                context.AllowCacheStorage = false;
                return ValueTask.CompletedTask;
            }

            return ValueTask.CompletedTask;
        }
    }
}
