using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

namespace WebAPiHealtyEats.Controllers
{
    public class OpenAiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("getResult")]
        public IActionResult GetResult([FromBody]string prompt)
        {

            string apiKey = "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";
            string answer = string.Empty;
            var openAi = new OpenAIAPI(apiKey);
            var completion = new CompletionRequest();
            completion.Prompt = prompt;
            completion.Model = OpenAI_API.Models.Model.DavinciText;
            completion.MaxTokens = 1000;
            var result = openAi.Completions.CreateCompletionAsync(completion);
            if (result != null)
            {
                foreach(var item in result.Result.Completions)
                {
                    answer = item.Text;
                }
                return Ok(answer);
            }
            else
            {
                return BadRequest("Not found");
            }

        
        }
    }

}
