using System;
using System.Collections.Generic;

namespace GameWatchAPI.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            Useri = new HashSet<Useri>();
        }

        public string RoleName { get; set; } = null!;

        public virtual ICollection<Useri> Useri { get; set; }
    }
}
