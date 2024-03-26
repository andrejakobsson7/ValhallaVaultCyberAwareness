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
                var segmentScoresJson = JsonSerializer.Serialize(segmentScore, _jsonSerializerOptions);
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
    }
}
