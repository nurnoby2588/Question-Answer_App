using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Question_Answer_App.DataAccess;
using Question_Answer_App.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Question_Answer_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuesAnsController : ControllerBase
    {
        private readonly QuesAnsREpository _quesAnsREpository;

        public QuesAnsController(QuesAnsREpository quesAnsREpository)
        {
            _quesAnsREpository = quesAnsREpository;
        }

        [HttpGet("GetAllQuesetion")]
        public async Task<IActionResult> GetAllQuesetion()
        {
            List<Question> questions = await _quesAnsREpository.GetAllQuestion(); 

            return Ok(new
            {
                StatusCode=200,
                Data=questions
            });
        }
    }
}
