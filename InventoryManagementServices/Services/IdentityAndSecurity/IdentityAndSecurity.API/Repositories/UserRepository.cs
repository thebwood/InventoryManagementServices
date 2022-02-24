using IdentityAndSecurity.API.Data;
using IdentityAndSecurity.API.Models;
using IdentityAndSecurity.API.Repositories.Interfaces;

namespace IdentityAndSecurity.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IdentityAndSecurityContext _context;

        public UserRepository(IdentityAndSecurityContext context) => _context = context;

        public User FindUser(UserLoginModel user)
        {

            return _context.Users.Where(u => u.UserName == user.UserName).FirstOrDefault();
        }


        public void Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public UserLogin FindUserLogin(User user)
        {
            var userLogin = _context.UserLogins.FirstOrDefault(u => u.UserId == user.Id);
            if (userLogin == null)
                userLogin = new UserLogin()
                {
                    UserId = user.Id,

                };
            return userLogin;
        }

        public void SaveUserLogin(UserLogin userLogin)
        {
            if (userLogin == null) return;

            if (userLogin.Id == null)
                _context.UserLogins.Add(userLogin);
            else
                _context.UserLogins.Update(userLogin);
            _context.SaveChanges();

        }
    }
}
