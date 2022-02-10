using IdentityAndSecurity.API.Services.Interfaces;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using IdentityAndSecurity.API.Data;
using IdentityAndSecurity.API.Models;
using IdentityAndSecurity.API.Repositories.Interfaces;

namespace IdentityAndSecurity.API.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _respository;
        public UserService(IConfiguration configuration, IUserRepository respository)
        {
            _configuration = configuration;
            _respository = respository;
        }

        public UserRegistrationModel Register(UserModel userRequest)
        {
            var registration = new UserRegistrationModel();
            var user = new User();

            CreatePasswordHash(userRequest.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.UserName = userRequest.UserName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            return registration;
        }

        public UserLoginModel Login(UserModel request)
        {
            var userToken = new UserLoginModel();
            var user = new User();
            if (user.UserName != request.UserName)
            {
                userToken.ErrorMessages.Add("User not found.");
            }
            user.UserName = request.UserName;

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                userToken.ErrorMessages.Add("Password is incorrect");
            }

            if(userToken.ErrorMessages.Count > 0)
            {
                return userToken;
            }

            string token = CreateToken(user);
            return userToken;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

    }
}
