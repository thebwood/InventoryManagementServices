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

        public UserRegisterResponseModel Register(UserRegisterModel request)
        {
            var registration = new UserRegisterResponseModel();
            var user = new User();

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.UserName = request.UserName;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Email = request.Email;
            user.CreatedAt = DateTime.Now;
            user.CreatedBy = "system";
            user.IsDeleted = false;
            _respository.Register(user);
            return registration;
        }

        public UserLoginResponseModel Login(UserLoginModel request)
        {
            var response = new UserLoginResponseModel();
            var user = _respository.FindUser(request);
            if (user == null || user.UserName != request.UserName)
            {
                response.ErrorMessages.Add("User not found.");
                return response;
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                response.ErrorMessages.Add("Password is incorrect");
                return response;
            }

            var token = CreateToken(user);
            var userLogin = _respository.FindUserLogin(user);
            userLogin.Token = token;
            userLogin.LoginAt = DateTime.Now;
            _respository.SaveUserLogin(userLogin);

            response.UserID = user.Id;
            return response;
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
