using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data1.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Moviename { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }
        public ICollection<WatchList> WatchLists { get; set; }
    }
}
