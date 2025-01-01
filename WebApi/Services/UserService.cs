
using WebApi.Models;

namespace WebApi.Services
{
        public class UserService : IUserService
        {
           private readonly IJwtService _jwtService;

           //LOCAL USERS REPOSITORY - INSTEAD ON DATABASE
           private List<User> _users = new List<User>
           {
             new User { Id =1212121, Username = "adxxxoidd", Password = "876235jkhkj54" } 
           };


           public UserService(IJwtService jwtService)
           {
            _jwtService = jwtService;
           }

           /// <summary>
           /// User Authentication & Token Creation
           /// </summary>
           /// <param name="model"></param>
           /// <returns></returns>
           public AuthenticateResponse Authenticate(AuthenticateRequest model)
           {
             var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

             // return null if user not found
             if (user == null) return null;

             // authentication successful so generate jwt token
             var token = _jwtService.generateJwtToken(user);

             return new AuthenticateResponse(user, token);
           }

           public IEnumerable<User> GetAll()
           {
             return _users;
           }

           public User? GetById(int id)
           {
             return _users.FirstOrDefault(x => x.Id == id);
           }

        }
}



