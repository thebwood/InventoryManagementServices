using System;
using System.Collections.Generic;

namespace Person.API.Data
{
    public partial class Actor
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
    }
}
