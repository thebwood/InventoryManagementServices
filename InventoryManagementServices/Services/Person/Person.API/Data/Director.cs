using System;
using System.Collections.Generic;

namespace Person.API.Data
{
    public partial class Director
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
    }
}
