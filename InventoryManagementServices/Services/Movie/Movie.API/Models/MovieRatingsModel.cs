using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.API.Models
{
    public class MovieRatingsModel
    {
        public Guid Id { get; set; }
        public string Rating { get; set; }
        public int Age { get; set; }
    }
}
