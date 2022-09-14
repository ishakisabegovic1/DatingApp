using DatingAppServer.Entities;

namespace DatingAppServer.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser appUser);
    }
}
