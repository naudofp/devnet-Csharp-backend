using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace devnet_Csharp_backend.api.Controllers
{
    [ApiController]
    [Route("api/course")]
    public class CourseController : ControllerBase
    {
        private readonly CourseService service;

        public CourseController(CourseService service){
            this.service = service;
        }

        [HttpPost]
        public async Task<ActionResult<List<CourseCardDTO>>> post([FromBody] CourseRegisterDTO dto) {
            return Ok(await service.save(dto));
        }
        
        [HttpPost("default")]
        public async Task<ActionResult<List<Course>>> postDefault() {
            return Ok(await service.addDefaultCourses());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> delete(long id){
            return Ok(await service.delete(id));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDetailsDTO>> getById(long id){
            return Ok(await service.findById(id));
        }

        [HttpGet]
        public async Task<ActionResult<List<CourseCardDTO>>> getAll(){
            return Ok(await service.findAll());
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<List<CourseCardDTO>>> getByName(string name){
            return Ok(await service.findByName(name));
        }
    }
}