using System;
using System.Collections.Generic;

namespace IdentityAndSecurity.API.Data
{
    public partial class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
