using System;
using System.Collections.Generic;

namespace RefData.API.Data
{
    public partial class Country
    {
        public Guid Id { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }
    }
}
