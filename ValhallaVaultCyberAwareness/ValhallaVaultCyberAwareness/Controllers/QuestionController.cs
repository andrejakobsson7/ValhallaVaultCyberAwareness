using Microsoft.AspNetCore.Mvc;
using ValhallaVaultCyberAwareness.Domain.Models;
using ValhallaVaultCyberAwareness.Repositories;


namespace ValhallaVaultCyberAwareness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        IQuestionRepository _questionRepo;

        public QuestionController(IQuestionRepository questionRepo)
        {
            _questionRepo = questionRepo;
        }

        [HttpGet("{subCategoryId}")]
        public async Task<ActionResult<List<QuestionModel>>> GetAllQuestionsPerSubCategoryAsync(int subCategoryId)
        {
            var questions = await _questionRepo.GetAllQuestionsSubCategoryAsync(subCategoryId);

            if (questions != null)
            {
                return Ok(questions);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<List<QuestionModel>>> GetAllQuestionsAsync()
        {
            var questions = await _questionRepo.GetAllQuestionsAsync();

            if (questions != null)
            {
                return Ok(questions);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<QuestionModel>> Post(QuestionModel newQuestion)
        {
            var questionToAdd = await _questionRepo.AddQuestionAsync(newQuestion);

            if (questionToAdd != null)
            {
                return Ok(questionToAdd);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<QuestionModel>> UpdateQuestion(int id, QuestionModel question)
        {
            var updatedQuestion = _questionRepo.UpdateQuestionAsync(id, question);

            if (updatedQuestion != null)
            {
                return Ok(question);

            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<QuestionModel>> DeleteQuestion(int id)
        {
            var questionToDelete = _questionRepo.DeleteQuestionAsync(id);

            if (questionToDelete != null)
            {
                return Ok(questionToDelete);
            }
            return BadRequest();
        }
    }
}
