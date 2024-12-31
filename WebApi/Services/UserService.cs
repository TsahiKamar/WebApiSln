
//using global::WebApi.Models;

using WebApi.Models;

namespace WebApi.Services
    {
        public class UserService : IUserService
        {
           private readonly IJwtService _jwtService;

           private List<User> _users = new List<User>
           {
                 new User { Id = 187456, Username = "adxxxoidd", Password = "876235jkhkj54" } //ONLY FOR TEST ENVIRONMENT USER
           };

        //private readonly AppSettings _appSettings;

            public UserService(IJwtService jwtService)//IOptions<AppSettings> appSettings
            {
                //_appSettings = appSettings.Value;
                _jwtService = jwtService;
            }

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

            //private string generateJwtToken(User user)
            //{
            //    // generate token that is valid for 7 days
            //    var tokenHandler = new JwtSecurityTokenHandler();
            //    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            //    var tokenDescriptor = new SecurityTokenDescriptor
            //    {
            //        Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            //        Expires = DateTime.UtcNow.AddDays(7),
            //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //    };
            //    var token = tokenHandler.CreateToken(tokenDescriptor);
            //    return tokenHandler.WriteToken(token);
            //}
        }
    }



