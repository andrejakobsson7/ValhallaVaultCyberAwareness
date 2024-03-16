using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using ValhallaVaultCyberAwareness.Domain.Models;
using ValhallaVaultCyberAwareness.Repositories.Interfaces;

namespace ValhallaVaultCyberAwareness.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserAnswersController : ControllerBase
	{
		public IUserAnswersRepository _userAnswersRepo { get; set; }
		private readonly IOutputCacheStore _outputCacheStore;

		public UserAnswersController(IUserAnswersRepository userAnswerRepo, IOutputCacheStore outputCacheStore)
		{
			_userAnswersRepo = userAnswerRepo;
			_outputCacheStore = outputCacheStore;
		}

		[HttpPost]
		[OutputCache(PolicyName = "ByIdCachePolicy")]
		public async Task<IActionResult> AddUserAnswersAsync(List<UserAnswers> newUserAnswers, CancellationToken cancellationToken)
		{
			bool isSuccesfullyAdded = await _userAnswersRepo.AddUserAnswersAsync(newUserAnswers);
			if (isSuccesfullyAdded)
			{
				string userId = newUserAnswers.First().UserId;
				await RemoveFromUserCacheAsync(userId, cancellationToken);
				return Ok();
			}
			return BadRequest();
		}

		private async Task RemoveFromUserCacheAsync(string userId, CancellationToken cancellationToken)
		{
			await _outputCacheStore.EvictByTagAsync(userId, cancellationToken);
		}


	}
}
