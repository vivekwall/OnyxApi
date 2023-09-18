using JwtApp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Onyx.Core.Application.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Onyx.Auth.Service
{
    public class AuthService : IAuthService
    {
        private IConfiguration _config;
        public AuthService(IConfiguration config)
        {
            _config = config;
        }
        public string GetAuthToken(UserLogin userLogin)
        {
            var user = Authenticate(userLogin);

            if (user != null)
            {
                var token = Generate(user);
                return token;
            }

            return null;
        }

        private string Generate(UserModel user)
        {
            var test = _config["Jwt:Key"];
            var test1 = _config["Jwt:Issuer"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.GivenName, user.GivenName),
                new Claim(ClaimTypes.Surname, user.Surname),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel Authenticate(UserLogin userLogin)
        {
            var currentUser = UsersDb.Users.FirstOrDefault(o => o.Username.ToLower() == userLogin.Username.ToLower() && o.Password == userLogin.Password);

            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }
    }
}