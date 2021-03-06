using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models.People
{
    public class PersonSearchResultsModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string BirthCity { get; set; }
        public string BirthState { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
