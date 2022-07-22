using System;
using System.Collections.Generic;

namespace GameWatchAPI.Models
{
    public partial class Biznesi
    {
        public Biznesi()
        {
            Cmimorja = new HashSet<Cmimorja>();
            Lokali = new HashSet<Lokali>();
            Stafi = new HashSet<Stafi>();
        }

        public int Id { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public string Emri { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string NrTel { get; set; } = null!;
        public string Qyteti { get; set; } = null!;
        public string? Adresa { get; set; }

        public virtual ICollection<Cmimorja> Cmimorja { get; set; }
        public virtual ICollection<Lokali> Lokali { get; set; }
        public virtual ICollection<Stafi> Stafi { get; set; }
    }
}
