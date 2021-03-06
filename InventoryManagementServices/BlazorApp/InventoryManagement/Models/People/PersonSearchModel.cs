using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models.People
{
    public class PersonSearchModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string BirthCity { get; set; }
        public int? BirthStateId { get; set; }
        public string City { get; set; }
        public int? StateId { get; set; }
    }
}
