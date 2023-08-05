using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data1.Models
{
    public class WatchList
    {
        public int WatchListId { get; set; }
        public int SerieId { get; set; }
        public int MovieId { get; set; }

        public string Type { get; set; }
        public ICollection<UserWatchList> UserWatchLists { get; set; }
        public Serie Serie { get; set; }
        public Movie Movie { get; set; }
    }
}
