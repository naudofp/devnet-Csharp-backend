using Microsoft.AspNetCore.Mvc;

namespace devnet_Csharp_backend.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeveloperController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<Developer> getDeveloper(int id){
            return Ok();
        }
    }
}