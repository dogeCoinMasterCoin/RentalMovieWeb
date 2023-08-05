using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data1.Models
{
    public class Serie
    {
        public int SerieId { get; set; }
        public string Seriename { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }
        public ICollection<WatchList> WatchLists { get; set; }
    }
}
