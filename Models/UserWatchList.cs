using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data1.Models
{
    public class UserWatchList
    {
        public int UserWatchListId { get; set; }
        public int WatchListId { get; set; }
        public int UserAppId { get; set; }

        public WatchList WatchList { get; set; }
        public UserApp UserApp { get; set; }
    }
}
