using Microsoft.AspNetCore.Identity;

namespace NZWalks.Interfaces
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
