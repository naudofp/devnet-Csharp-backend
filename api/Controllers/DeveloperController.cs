using Microsoft.AspNetCore.Mvc;
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
            return Ok("Register was Successfully");
        }

        [HttpPut("add-course/{idCourse}/{idUser}")]
        public async Task<ActionResult<string>> addCourse(long idUser, long idCourse){
            return Ok(await service.addCourse(idUser, idCourse));
        }

        [HttpPut("remove-course/{course}/{user}")] 
         public async Task<ActionResult<string>> rmCourse(long user, long course){
            return Ok(await service.rmCourse(user, course));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> deleteDeveloper(long id){
            return Ok(await service.delete(id));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeveloperDetailsDTO>> getDeveloper(long id){
            return Ok(await service.findById(id));
        }

        [HttpGet("courses/{id}")]
        public async Task<ActionResult<List<CourseCardDTO>>> getDeveloperWithCourses(long id){
            return Ok(await service.findDeveloperWithCourses(id));
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<List<DeveloperCardDTO>>> getDevelopersByUsername(string name){
            return Ok(service.findByUsername(name));
        }
    }
}