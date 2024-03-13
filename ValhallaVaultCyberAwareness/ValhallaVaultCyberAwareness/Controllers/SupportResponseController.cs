using Microsoft.AspNetCore.Mvc;
using ValhallaVaultCyberAwareness.Domain.Models.Support;
using ValhallaVaultCyberAwareness.Repositories.Interfaces;

namespace ValhallaVaultCyberAwareness.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SupportResponseController : ControllerBase
	{
		public ISupportResponseRepository _supportResponseRepo;

		public SupportResponseController(ISupportResponseRepository supportResponseRepo)
		{
			_supportResponseRepo = supportResponseRepo;
		}

		[HttpPost]
		public async Task<IActionResult> AddSupportResponseAsync(SupportResponseModel newSupportResponse)
		{
			bool isSuccessfullyAdded = await _supportResponseRepo.AddSupportResponseAsync(newSupportResponse);
			if (isSuccessfullyAdded != false)
			{
				return Ok(isSuccessfullyAdded);
			}
			return BadRequest();
		}

		[HttpPut]
		[Route("{supportResponseId}")]
		public async Task<IActionResult> UpdateSupportResponseAsync(SupportResponseModel supportResponse)
		{
			bool isSuccessfullyUpdated = await _supportResponseRepo.UpdateSupportResponseAsync(supportResponse);
			if (isSuccessfullyUpdated != false)
			{
				return Ok(isSuccessfullyUpdated);
			}
			return BadRequest();
		}

		[HttpDelete]
		[Route("{supportResponseId}")]
		public async Task<IActionResult> DeleteSupportQuestionAsync(int supportResponseId)
		{
			bool isSuccessfullyRemoved = await _supportResponseRepo.DeleteSupportResponseAsync(supportResponseId);
			if (isSuccessfullyRemoved != false)
			{
				return Ok(isSuccessfullyRemoved);
			}
			return BadRequest();
		}
	}
}
