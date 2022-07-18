using System;
using System.Collections.Generic;

namespace GameWatchAPI.Models
{
    public partial class Stafi
    {
        public int Id { get; set; }
        public string Emri { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string NrTel { get; set; } = null!;
        public string Qyteti { get; set; } = null!;
        public int? BiznesiId { get; set; }

        public virtual Biznesi? Biznesi { get; set; }
    }
}
