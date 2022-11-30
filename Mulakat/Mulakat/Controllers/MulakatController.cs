using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mulakat.Services;

namespace Mulakat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MulakatController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> TestVerisiOlustur(int musteriAdet, int sepetAdet)
        {
            PostService postService = new PostService();
            return Ok(postService.TestVerisiOlustur(musteriAdet,sepetAdet));
        }

        [HttpGet]
        public async Task<IActionResult> SehirBazliAnalizYap()
        {
            AnalysisService analysisService = new AnalysisService();
            return Ok(analysisService.SehirBazliAnalizYap());
        }

    }
}
