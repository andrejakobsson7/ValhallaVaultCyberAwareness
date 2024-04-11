using Microsoft.AspNetCore.Mvc;
using ValhallaVaultCyberAwareness.Domain.Models;
using ValhallaVaultCyberAwareness.Repositories.Interfaces;

namespace ValhallaVaultCyberAwareness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswersRepository _answerRepo;

        public AnswerController(IAnswersRepository answerRepo)
        {
            _answerRepo = answerRepo;
        }

        [HttpPost]
        public async Task<ActionResult> AddAnswersAsync(List<AnswerModel> answers)
        {
            try
            {
                await _answerRepo.AddAnswersAsync(answers);
                return StatusCode(201, answers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
