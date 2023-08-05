using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data1.Models
{
    public class UserApp
    {
        public int UserAppId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<UserWatchList> UserWatchLists { get; set; }
        
    }
}
