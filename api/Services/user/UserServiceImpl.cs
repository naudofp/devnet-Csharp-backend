using Microsoft.EntityFrameworkCore;
using devnet_Csharp_backend.api.Data;
using devnet_Csharp_backend.api.Services.User;
using devnet_Csharp_backend.api.Services.security;

namespace devnet_Csharp_backend.api.Services.user
{
    public class UserServiceImpl : UserService
    {
        private readonly DevnetDBContext context;
        private readonly SecurityService security;

        public UserServiceImpl(DevnetDBContext context, SecurityService security)
        {
            this.context = context;
            this.security = security;
        }

        public async Task<UserHolderDTO> login(UserLoginDTO dto)
        {
            var dev = await context.developer.FirstOrDefaultAsync(x => x.username == dto.username);
            if(dev == null) throw new Exception($"{dto.username} was not found");

            if(!await security.verifyPassword(dto.password, dev.password)) throw new Exception("Password Incorrect");
            return new UserHolderDTO(dev.id);   
        }
    }
}