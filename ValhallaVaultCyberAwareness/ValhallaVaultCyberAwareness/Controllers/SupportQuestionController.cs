using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using ValhallaVaultCyberAwareness.Domain.Models.Support;
using ValhallaVaultCyberAwareness.Repositories.Interfaces;

namespace ValhallaVaultCyberAwareness.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SupportQuestionController : ControllerBase
	{
		public ISupportQuestionRepository _supportQuestionRepo;
		private JsonSerializerOptions _jsonSerializerOptions = new()
		{
			ReferenceHandler = ReferenceHandler.Preserve
		};

		public SupportQuestionController(ISupportQuestionRepository supportQuestionRepo)
		{
			_supportQuestionRepo = supportQuestionRepo;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllSupportQuestionsAsync()
		{
			var supportQuestions = await _supportQuestionRepo.GetAllSupportQuestionsAsync();
			if (supportQuestions != null)
			{
				var supportQuestionsJson = JsonSerializer.Serialize(supportQuestions, _jsonSerializerOptions);
				return Ok(supportQuestionsJson);
			}
			return BadRequest();
		}

		[HttpPost]
		public async Task<IActionResult> AddSupportQuestionAsync(SupportQuestionModel newSupportQuestion)
		{
			var isSuccessfullyAdded = await _supportQuestionRepo.AddSupportQuestionAsync(newSupportQuestion);
			if (isSuccessfullyAdded != false)
			{
				return Ok(isSuccessfullyAdded);
			}
			return BadRequest();
		}

		[HttpPut]
		[Route("{supportQuestionId}")]
		public async Task<IActionResult> UpdateSupportQuestionAsync(SupportQuestionModel supportQuestion)
		{
			bool isSuccessfullyUpdated = await _supportQuestionRepo.UpdateSupportQuestionAsync(supportQuestion);
			if (isSuccessfullyUpdated != false)
			{
				return Ok(isSuccessfullyUpdated);
			}
			return BadRequest();
		}

		[HttpDelete]
		[Route("{supportQuestionId}")]
		public async Task<IActionResult> DeleteSupportQuestionAsync(int supportQuestionId)
		{
			bool isSuccessfullyRemoved = await _supportQuestionRepo.DeleteSupportQuestionAsync(supportQuestionId);
			if (isSuccessfullyRemoved != false)
			{
				return Ok(isSuccessfullyRemoved);
			}
			return BadRequest();
		}
	}
}
