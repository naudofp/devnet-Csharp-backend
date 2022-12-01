using Microsoft.AspNetCore.Mvc;
using Developer = devnet_Csharp_backend.api.Models.Developer;

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