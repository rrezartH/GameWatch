using System;
using System.Collections.Generic;

namespace GameWatchAPI.Models
{
    public partial class Konzola
    {
        public Konzola()
        {
            BiznesiKonzola = new HashSet<BiznesiKonzola>();
        }

        public int Id { get; set; }
        public string Modeli { get; set; } = null!;

        public virtual ICollection<BiznesiKonzola> BiznesiKonzola { get; set; }
    }
}
