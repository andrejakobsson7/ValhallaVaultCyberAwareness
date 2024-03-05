using Microsoft.AspNetCore.Mvc;
using ValhallaVaultCyberAwareness.Domain.Models;
using ValhallaVaultCyberAwareness.Repositories;

namespace ValhallaVaultCyberAwareness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentController : ControllerBase
    {
        SegmentRepository _segmentRepo;
        public SegmentController(SegmentRepository segmentRepo)
        {
            _segmentRepo = segmentRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<SegmentModel>>> GetSegmentById(int segmentId)
        {
            var segment = await _segmentRepo.GetSegmentByIdAsync(segmentId);

            if (segment != null)
            {
                return Ok(segment);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<SegmentModel>> AddSegment(SegmentModel newSegment)
        {
            var segmentToAdd = await _segmentRepo.AddSegmentAsync(newSegment);

            if (segmentToAdd != false)
            {
                return Ok(segmentToAdd);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SegmentModel>> UpdateSegment(SegmentModel segment)
        {
            var updatedSegment = _segmentRepo.UpdateSegmentAsync(segment);

            if (updatedSegment != null)
            {
                return Ok(updatedSegment);

            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SegmentModel>> DeleteQuestion(int id)
        {
            var segmentToDelete = _segmentRepo.RemoveSegmentAsync(id);

            if (segmentToDelete != null)
            {
                return Ok(segmentToDelete);
            }
            return BadRequest();
        }
    }
}
