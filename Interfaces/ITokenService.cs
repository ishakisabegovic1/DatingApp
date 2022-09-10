using DatingAppServer.Entities;

namespace DatingAppServer.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser appUser);
    }
}
