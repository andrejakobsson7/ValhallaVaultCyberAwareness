using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using ValhallaVaultCyberAwareness.Domain.Models;
using ValhallaVaultCyberAwareness.Repositories;

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
        [Route("{categoryId}/{userId}")]
        public async Task<IActionResult> GetSegmentsByCategoryId(int categoryId, string userId)
        {
            var segments = await _segmentRepo.GetSegmentsByCategoryIdAsync(categoryId);
            if (segments != null)
            {
                List<SegmentApiModel> apiSegments = segments.Select(s => new SegmentApiModel(s)).ToList();

                var segmentsJson = JsonSerializer.Serialize(apiSegments, _jsonSerializerOptions);
                return Ok(segmentsJson);
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

        public class SegmentApiModel
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;
            public string? Description { get; set; }
            public int CategoryId { get; set; }
            public List<SubCategoryModel> SubCategories { get; set; } = new();

            public SegmentApiModel(SegmentModel segment)
            {
                Id = segment.Id;
                Name = segment.Name;
                Description = segment.Description;
                CategoryId = segment.CategoryId;
                foreach (var subCategory in segment.SubCategories)
                {
                    SubCategories.Add(subCategory);
                }
            }
        }
    }
}
