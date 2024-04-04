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
            try
            {
                await _userAnswersRepo.AddUserAnswersAsync(newUserAnswers);
                return StatusCode(201, "Useranswers have been successfully registered");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
