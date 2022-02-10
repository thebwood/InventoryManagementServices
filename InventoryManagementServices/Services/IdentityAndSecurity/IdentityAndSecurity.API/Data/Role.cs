using System;
using System.Collections.Generic;

namespace IdentityAndSecurity.API.Data
{
    public partial class Role
    {
        public Guid Id { get; set; }
        public string Role1 { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateAt { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
