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
        public async Task<IActionResult> GetSegmentWithUserScoresByUserIdAsync(int segmentId, string userId)
        {
            try
            {
                var segmentScore = await _segmentRepo.GetSegmentWithUserScoresByUserIdAsync(segmentId, userId);
                if (segmentScore != null)
                {
                    var segmentScoresJson = JsonSerializer.Serialize(segmentScore, _jsonSerializerOptions);
                    return Ok(segmentScoresJson);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<SegmentModel>> AddSegmentAsync(SegmentModel segment)
        {
            try
            {
                SegmentModel newSegment = await _segmentRepo.AddSegmentAsync(segment);
                return StatusCode(201, newSegment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<SegmentModel>> UpdateSegmentAsync(SegmentModel segment)
        {
            try
            {
                SegmentModel? updatedSegment = await _segmentRepo.UpdateSegmentAsync(segment);
                return Ok(updatedSegment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<SegmentModel>> DeleteSegment(int id)
        {
            try
            {
                bool isSegmentDeleted = await _segmentRepo.RemoveSegmentAsync(id);
                return Ok("Segment was successfully deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
