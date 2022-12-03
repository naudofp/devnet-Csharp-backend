using Microsoft.EntityFrameworkCore;
using devnet_Csharp_backend.api.Data;
using devnet_Csharp_backend.api.Services.User;
using devnet_Csharp_backend.api.Models;

namespace devnet_Csharp_backend.api.Services.user
{
    public class UserServiceImpl : UserService
    {
        private readonly DevnetDBContext context;

        public UserServiceImpl(DevnetDBContext _context)
        {
            context = _context;
        }
        public async Task<UserHolderDTO> login(UserLoginDTO dto)
        {
            var dev = await context.developer.FirstOrDefaultAsync(x => x.username == dto.username);
            if(dev == null) throw new Exception($"{dto.username} was not found");

            if(dev.password != dto.password) throw new Exception("Password Incorrect");

            return new UserHolderDTO(dev.id);   
        }
    }
}