using Microsoft.AspNetCore.Mvc;
using Developer = devnet_Csharp_backend.api.Models.Developer;
using devnet_Csharp_backend.api.Services.developer;

namespace devnet_Csharp_backend.api.Controllers
{
    [ApiController]
    [Route("api/developer")]
    public class DeveloperController : ControllerBase
    {
        
        private readonly DeveloperService service;

        public DeveloperController(DeveloperService service){
            this.service = service;
        }

        [HttpPost]
        public async Task<ActionResult<string>> addDev([FromBody] DeveloperRegisterDTO dto){
            await service.save(dto);
            return Ok("Register was success");
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<DeveloperDetailsDTO>> getDeveloper(int id){
            return Ok(await service.findById(id));
        }
    }
}