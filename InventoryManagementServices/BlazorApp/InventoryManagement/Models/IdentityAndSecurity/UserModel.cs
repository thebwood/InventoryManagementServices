using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models.IdentityAndSecurity
{
    public class UserModel
    {
        public Guid? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "User Name is Required")]
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
