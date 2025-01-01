using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApi.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class AuthenticateResponse
    {
       public int Id { get; set; }
       public string Username { get; set; }
       public string Token { get; set; }

       public AuthenticateResponse(User user, string token)
       {
        Id = user.Id;
        Username = user.Username;
        Token = token;
       }
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }

}
