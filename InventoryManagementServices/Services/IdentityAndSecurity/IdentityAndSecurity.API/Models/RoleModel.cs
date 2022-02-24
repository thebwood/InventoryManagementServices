namespace IdentityAndSecurity.API.Models
{
    public class RoleModel
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
