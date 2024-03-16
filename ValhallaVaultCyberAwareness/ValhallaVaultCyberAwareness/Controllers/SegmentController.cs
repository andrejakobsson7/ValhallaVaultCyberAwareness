using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using ValhallaVaultCyberAwareness.Domain.Models;
using ValhallaVaultCyberAwareness.Repositories.Interfaces;

namespace ValhallaVaultCyberAwareness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentController : ControllerBase
    {
        public ISegmentRepository _segmentRepo;
        private JsonSerializerOptions _jsonSerializerOptions = new()
        {
            ReferenceHandler = ReferenceHandler.Preserve
        };
        public SegmentController(ISegmentRepository segmentRepo)
        {
            _segmentRepo = segmentRepo;
        }

        [HttpGet]
        [Route("{segmentId}/{userId}")]
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

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<SegmentModel>> UpdateSegment(SegmentModel segment)
        {
            var updatedSegment = await _segmentRepo.UpdateSegmentAsync(segment);

            if (updatedSegment != false)
            {
                return Ok(updatedSegment);

            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<SegmentModel>> DeleteSegment(int id)
        {
            var segmentToDelete = await _segmentRepo.RemoveSegmentAsync(id);

            if (segmentToDelete != false)
            {
                return Ok(segmentToDelete);
            }
            return BadRequest();
        }

        //Temporary model that is returned from the API to enable that the client service can get access to navigation properties,
        //since these are not serialized otherwise
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
