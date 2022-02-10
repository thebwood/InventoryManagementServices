using IdentityAndSecurity.API.Data;
using IdentityAndSecurity.API.Models;

namespace IdentityAndSecurity.API.Services.Interfaces
{
    public interface IUserService
    {
        UserRegistrationModel Register(UserModel request);
        UserLoginModel Login(UserModel request);
    }
}
