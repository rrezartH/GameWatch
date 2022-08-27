using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace GameWatchAPI.Models
{
    public partial class Useri : IdentityUser<int>
    {
        public int UserId { get; set; }
        public string Emri { get; set; } = null!;
        public string Qyteti { get; set; } = null!;
        public int RoleId { get; set; }
        public int? BiznesiId { get; set; }
        public int? LokaliId { get; set; }

        public virtual Biznesi? Biznesi { get; set; }
        public virtual Lokali? Lokali { get; set; }
/*        public virtual UserRole RoleNameNavigation { get; set; } = null!;*/
    }
}
