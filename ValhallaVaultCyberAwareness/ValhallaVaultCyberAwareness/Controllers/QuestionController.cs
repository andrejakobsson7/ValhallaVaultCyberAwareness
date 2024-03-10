using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using ValhallaVaultCyberAwareness.Domain.Models;
using ValhallaVaultCyberAwareness.Repositories.Interfaces;


namespace ValhallaVaultCyberAwareness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        public IQuestionRepository _questionRepo { get; set; }
        private JsonSerializerOptions _jsonSerializerOptions = new()
        {
            ReferenceHandler = ReferenceHandler.Preserve
        };

        public QuestionController(IQuestionRepository questionRepo)
        {
            _questionRepo = questionRepo;
        }

        [HttpGet("{subCategoryId}")]
        public async Task<ActionResult<List<QuestionModel>>> GetQuestionsBySubCategoryIdAsync(int subCategoryId)
        {
            var questions = await _questionRepo.GetQuestionsBySubCategoryIdAsync(subCategoryId);

            if (questions != null)
            {
                var questionsJson = JsonSerializer.Serialize(questions, _jsonSerializerOptions);
                return Ok(questionsJson);
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

            return BadRequest();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<QuestionModel>> UpdateQuestion(QuestionModel question)
        {
            var updatedQuestion = await _questionRepo.UpdateQuestionAsync(question);

            if (updatedQuestion != null)
            {
                return Ok(question);

            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<QuestionModel>> DeleteQuestion(int id)
        {
            var questionToDelete = await _questionRepo.DeleteQuestionAsync(id);

            if (questionToDelete != false)
            {
                return Ok(questionToDelete);
            }
            return BadRequest();
        }
    }
}
