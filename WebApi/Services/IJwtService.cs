
using WebApi.Models;

namespace WebApi.Services
{
    public interface IJwtService
    {
       string generateJwtToken(User user);
    }
}
