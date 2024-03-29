﻿using System;
using System.Collections.Generic;

namespace GameWatchAPI.Models
{
    public partial class BiznesiKonzola
    {
        public BiznesiKonzola()
        {
            BizneziKonzolaVideoloja = new HashSet<BizneziKonzolaVideoloja>();
            Fatura = new HashSet<Fatura>();
        }

        public int Id { get; set; }
        public string Emri { get; set; } = null!;
        public int KonzolaId { get; set; }
        public int LokaliId { get; set; }
        public bool? Statusi { get; set; }

        public virtual Konzola Konzola { get; set; } = null!;
        public virtual Lokali Lokali { get; set; } = null!;
        public virtual ICollection<BizneziKonzolaVideoloja> BizneziKonzolaVideoloja { get; set; }
        public virtual ICollection<Fatura> Fatura { get; set; }
    }
}
