using System;
using System.Collections.Generic;

namespace GameWatchAPI.Models
{
    public partial class Cmimorja
    {
        public int Id { get; set; }
        public int NrLojtareve { get; set; }
        public decimal Cmimi { get; set; }
        public int BiznesiId { get; set; }

        public virtual Biznesi Biznesi { get; set; } = null!;
    }
}
