using System;
using System.Collections.Generic;

namespace Person.API.Data
{
    public partial class Owner
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
    }
}
