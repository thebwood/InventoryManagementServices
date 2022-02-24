using System;
using System.Collections.Generic;

namespace IdentityAndSecurity.API.Data
{
    public partial class UserLogin
    {
        public Guid? Id { get; set; }
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public DateTime LoginAt { get; set; }
    }
}
