using Microsoft.AspNetCore.Mvc;
using ValhallaVaultCyberAwareness.Domain.Models;
using ValhallaVaultCyberAwareness.Repositories;


namespace ValhallaVaultCyberAwareness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        QuestionRepository _questionRepo;
        public QuestionController(QuestionRepository questionRepo)
        {
            _questionRepo = questionRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<QuestionModel>>> GetAllQuestionsPerSubCategoryAsync(int subCategoryId)
        {
            var questions = await _questionRepo.GetAllQuestionsSubCategoryAsync(subCategoryId);

            if (questions != null)
            {
                return Ok(questions);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<QuestionModel>> PostQuestion(QuestionModel newQuestion)
        {
            var questionToAdd = await _questionRepo.AddQuestionAsync(newQuestion);

            if (questionToAdd != null)
            {
                return Ok(questionToAdd);
            }

            return BadRequest();
        }
    }
}
