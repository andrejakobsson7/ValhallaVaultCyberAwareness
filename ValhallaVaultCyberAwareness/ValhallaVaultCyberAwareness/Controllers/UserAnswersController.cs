using Microsoft.AspNetCore.Mvc;
using ValhallaVaultCyberAwareness.Domain.Models;
using ValhallaVaultCyberAwareness.Repositories.Interfaces;

namespace ValhallaVaultCyberAwareness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAnswersController : ControllerBase
    {
        public IUserAnswersRepository _userAnswersRepo { get; set; }

        public UserAnswersController(IUserAnswersRepository userAnswerRepo)
        {
            _userAnswersRepo = userAnswerRepo;
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAnswersAsync(List<UserAnswers> newUserAnswers)
        {
            bool isSuccesfullyAdded = await _userAnswersRepo.AddUserAnswersAsync(newUserAnswers);
            if (isSuccesfullyAdded)
            {
                return Ok();
            }
            return BadRequest();
        }


    }
}
