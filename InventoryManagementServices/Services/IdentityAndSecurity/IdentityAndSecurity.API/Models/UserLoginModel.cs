namespace IdentityAndSecurity.API.Models
{
    public class UserLoginModel
    {
        public Guid UserID { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
