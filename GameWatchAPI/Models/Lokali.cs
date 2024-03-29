﻿using System;
using System.Collections.Generic;

namespace GameWatchAPI.Models
{
    public partial class Lokali
    {
        public Lokali()
        {
            Useri = new HashSet<Useri>();
            BiznesiKonzola = new HashSet<BiznesiKonzola>();
            Fatura = new HashSet<Fatura>();
        }

        public int Id { get; set; }
        public string Emri { get; set; } = null!;
        public string NrTel { get; set; } = null!;
        public string Qyteti { get; set; } = null!;
        public string? Adresa { get; set; }
        public int BiznesiId { get; set; }

        public virtual Biznesi Biznesi { get; set; } = null!;
        public virtual ICollection<Useri> Useri { get; set; }
        public virtual ICollection<BiznesiKonzola> BiznesiKonzola { get; set; }
        public virtual ICollection<Fatura> Fatura { get; set; }
    }
}
