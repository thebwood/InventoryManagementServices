namespace IdentityAndSecurity.API.Models
{
    public class UserLoginResponseModel
    {
        public Guid UserID { get; set; }
        public List<string> ErrorMessages { get; set; } = new List<string>();
    }
}
