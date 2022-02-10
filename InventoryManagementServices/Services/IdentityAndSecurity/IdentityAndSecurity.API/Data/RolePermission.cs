using System;
using System.Collections.Generic;

namespace IdentityAndSecurity.API.Data
{
    public partial class RolePermission
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public string Permission { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateAt { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
