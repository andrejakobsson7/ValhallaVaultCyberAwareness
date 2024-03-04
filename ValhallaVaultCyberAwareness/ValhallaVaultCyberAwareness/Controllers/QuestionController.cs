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
        public ActionResult<List<QuestionModel>> GetAllQuestionsPerSubCategory(int subCategoryId)
        {
            var questions = _questionRepo.GetAllQuestionsSubCategory(subCategoryId);

            if (questions != null)
            {
                return Ok(questions);
            }
            return BadRequest();
        }
    }
}
