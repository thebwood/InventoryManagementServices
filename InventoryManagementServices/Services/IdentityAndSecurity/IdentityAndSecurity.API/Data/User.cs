﻿using System;
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
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
    }
}
