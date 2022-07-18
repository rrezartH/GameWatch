using System;
using System.Collections.Generic;

namespace GameWatchAPI.Models
{
    public partial class Lokali
    {
        public Lokali()
        {
            Fatura = new HashSet<Fatura>();
            PlayStation = new HashSet<PlayStation>();
        }

        public int Id { get; set; }
        public string Emri { get; set; } = null!;
        public string NrTel { get; set; } = null!;
        public string Qyteti { get; set; } = null!;
        public string? Adresa { get; set; }
        public int BiznesiId { get; set; }

        public virtual Biznesi Biznesi { get; set; } = null!;
        public virtual ICollection<Fatura> Fatura { get; set; }
        public virtual ICollection<PlayStation> PlayStation { get; set; }
    }
}
