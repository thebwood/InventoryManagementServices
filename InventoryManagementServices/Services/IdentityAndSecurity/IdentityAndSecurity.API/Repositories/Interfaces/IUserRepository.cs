using IdentityAndSecurity.API.Data;
using IdentityAndSecurity.API.Models;

namespace IdentityAndSecurity.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void Register(User user);
        User FindUser(UserLoginModel user);
        void SaveUserLogin(UserLogin userLogin);
        UserLogin FindUserLogin(User user);
    }
}
