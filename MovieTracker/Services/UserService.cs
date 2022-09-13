using Microsoft.IdentityModel.Tokens;
using MovieTracker.DBContexts;
using MovieTracker.Models.Entities;
using MovieTracker.Repository;
using MovieTracker.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieTracker.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User, MovieTrackerContext> _repository;
        private readonly IConfiguration _configuration;
        public UserService(
            IGenericRepository<User, MovieTrackerContext> repository,
            IConfiguration configuration)
        {
            _repository = repository;        
            _configuration = configuration;
        }

        public async Task<string> LogIn(string email, string password)
        {
            var user = await _repository.FindAsync(user => user.EmailAddress == email && user.Password == password);

            if (user != null)
            {
                return GenerateToken(user);
            }

            return null;
        }

        public async Task<string> RegisterUser(User user)
        {
            user.InsertDate = DateTime.Now;
            await _repository.InsertAsync(user);

            return GenerateToken(user);
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));

            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("Id", user.Id.ToString()));
            claimsForToken.Add(new Claim("name", user.Name));
            claimsForToken.Add(new Claim("EmailAddress", user.EmailAddress));

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
               .WriteToken(jwtSecurityToken);

            return tokenToReturn;
        }
    }
}
