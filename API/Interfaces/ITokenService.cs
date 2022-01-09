using System.Collections.Generic;
using Domain;

namespace API.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user, List<string> roles);
    }
}