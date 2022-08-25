using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GameWatchAPI.Models
{
    public partial class Lokali
    {
        public Lokali()
        {
            BiznesiKonzola = new HashSet<BiznesiKonzola>();
            Fatura = new HashSet<Fatura>();
            Useri = new HashSet<Useri>();
        }

        public int Id { get; set; }
        public string Emri { get; set; } = null!;
        public string NrTel { get; set; } = null!;
        public string Qyteti { get; set; } = null!;
        public string? Adresa { get; set; }
        public int BiznesiId { get; set; }

        [JsonIgnore]
        public virtual Biznesi Biznesi { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<BiznesiKonzola> BiznesiKonzola { get; set; }
        [JsonIgnore]
        public virtual ICollection<Fatura> Fatura { get; set; }
        [JsonIgnore]
        public virtual ICollection<Useri> Useri { get; set; }
    }
}
