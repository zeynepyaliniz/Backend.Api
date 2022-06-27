using Backend.Api.Helper;
using Backend.Api.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Backend.Api.Services
{
    public class UserService : IUserService
    {
        
        private List<User> _users = new List<User> {
            new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test", Roles = new List<string>(){ "Admin"} },
            new User { Id = 2, FirstName = "Test", LastName = "User", Username = "user", Password = "user", Roles = new List<string>(){ "User"} }
        };


        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public List<User> GetAll()
        {
            return _users;
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        // helper methods

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days          
           
            Claim[] getClaims()
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.Id.ToString()));
                foreach (var item in user.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item));
                }
                return claims.ToArray();
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(getClaims()),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public Response Get()
        {
            throw new System.NotImplementedException();
        }

        public Response Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Response Update(User user)
        {
            throw new System.NotImplementedException();
        }
    }  
}
