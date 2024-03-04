using Microsoft.AspNetCore.Mvc;
using ValhallaVaultCyberAwareness.Data;

namespace ValhallaVaultCyberAwareness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        ApplicationDbContext _context;

        public QuestionController(ApplicationDbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public ActionResult<List<QuestionModel>> GetAllQuestions()
        //{

        //}


        //[HttpGet]
        //public ActionResult<List<QuestionModel>> GetAllQuestionsPerSegment()
        //{

        //}
    }
}
