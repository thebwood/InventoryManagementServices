using IdentityAndSecurity.API.Data;
using IdentityAndSecurity.API.Models;

namespace IdentityAndSecurity.API.Services.Interfaces
{
    public interface IUserService
    {
        UserRegisterResponseModel Register(UserRegisterModel request);

        UserLoginResponseModel Login(UserLoginModel request);
    }
}
