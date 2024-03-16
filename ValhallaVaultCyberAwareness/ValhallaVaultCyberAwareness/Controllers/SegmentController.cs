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
	public class SegmentController : ControllerBase
	{
		public ISegmentRepository _segmentRepo;
		private readonly IOutputCacheStore _outputCacheStore;
		private JsonSerializerOptions _jsonSerializerOptions = new()
		{
			ReferenceHandler = ReferenceHandler.Preserve
		};
		public SegmentController(ISegmentRepository segmentRepo, IOutputCacheStore outputCacheStore)
		{
			_segmentRepo = segmentRepo;
			_outputCacheStore = outputCacheStore;
		}

		//[HttpGet]
		//[Route("{segmentId}")]
		//public async Task<ActionResult<List<SegmentModel>>> GetSegmentById(int segmentId)
		//{
		//    var segment = await _segmentRepo.GetSegmentByIdAsync(segmentId);

		//    if (segment != null)
		//    {
		//        return Ok(segment);
		//    }
		//    return BadRequest();
		//}

		[HttpGet]
		[Route("{segmentId}/{userId}")]
		[OutputCache(PolicyName = "ByIdCachePolicy", VaryByQueryKeys = new[] { "userId" })]
		public async Task<IActionResult> GetCategoryWithUserScoresByUserIdAsync(int segmentId, string userId)
		{
			var segmentScore = await _segmentRepo.GetSegmentWithUserScoresByUserIdAsync(segmentId, userId);
			if (segmentScore != null)
			{
				SegmentApiModel apiSegmentScore = new SegmentApiModel(segmentScore);
				var segmentScoresJson = JsonSerializer.Serialize(apiSegmentScore, _jsonSerializerOptions);
				return Ok(segmentScoresJson);
			}
			return BadRequest();
		}

		[HttpPost]
		[OutputCache(PolicyName = "Category-Segment-SubCategoryPolicy")]
		public async Task<ActionResult<SegmentModel>> AddSegment(SegmentModel newSegment, CancellationToken cancellationToken)
		{
			var segmentToAdd = await _segmentRepo.AddSegmentAsync(newSegment);

			if (segmentToAdd != null)
			{
				await CacheManager.RemoveFromGeneralCache(cancellationToken, _outputCacheStore);
				return Ok(segmentToAdd);
			}

			return BadRequest();
		}

		[HttpPut]
		[Route("{segmentId}")]
		[OutputCache(PolicyName = "ByIdCachePolicy")]
		public async Task<ActionResult<SegmentModel>> UpdateSegment(SegmentModel segment, CancellationToken cancellationToken)
		{
			try
			{
				bool isSegmentUpdated = await _segmentRepo.UpdateSegmentAsync(segment);
				await CacheManager.RemoveFromCategorySegmentAndGeneralCache(segment.CategoryId, segment.Id, cancellationToken, _outputCacheStore);
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

		[HttpDelete]
		[Route("{segmentId}")]
		[OutputCache(PolicyName = "ByIdCachePolicy")]
		public async Task<ActionResult> DeleteSegment(int segmentId, CancellationToken cancellationToken)
		{
			try
			{
				SegmentModel deletedSegment = await _segmentRepo.RemoveSegmentAsync(segmentId);
				await CacheManager.RemoveFromCategorySegmentAndGeneralCache(deletedSegment.CategoryId, segmentId, cancellationToken, _outputCacheStore);
				return Ok();
			}
			//If the repository throws an argumentnullexception, it did not find the segment by the id sent along as a parameter
			catch (ArgumentNullException ex)
			{
				return NotFound(ex.Message);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		public class SegmentApiModel
		{
			public int Id { get; set; }
			public string Name { get; set; } = null!;
			public string? Description { get; set; }
			public int CategoryId { get; set; }
			public List<SubCategoryModel> SubCategories { get; set; } = new();

			public List<QuestionModel> Questions { get; set; } = new();

			public List<AnswerModel> Answers { get; set; } = new();

			public List<UserAnswers> UserAnswers { get; set; } = new();

			public SegmentApiModel(SegmentModel segment)
			{
				Id = segment.Id;
				Name = segment.Name;
				Description = segment.Description;
				CategoryId = segment.CategoryId;
				foreach (var subCategory in segment.SubCategories)
				{
					SubCategories.Add(subCategory);
					foreach (var question in subCategory.Questions)
					{
						Questions.Add(question);
						foreach (var answer in question.Answers)
						{
							Answers.Add(answer);
							foreach (var userAnswer in answer.UserAnswers)
							{
								UserAnswers.Add(userAnswer);
							}
						}
					}
				}
			}
		}
	}
}
