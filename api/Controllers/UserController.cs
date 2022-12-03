using devnet_Csharp_backend.api.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace devnet_Csharp_backend.api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly UserService service;

        public UserController(UserService service)
        {
            this.service = service;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserHolderDTO>> login([FromBody] UserLoginDTO dto)
        {
            return Ok(await service.login(dto));
        }
    }
}