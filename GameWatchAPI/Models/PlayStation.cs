using System;
using System.Collections.Generic;

namespace GameWatchAPI.Models
{
    public partial class PlayStation
    {
        public PlayStation()
        {
            Fatura = new HashSet<Fatura>();
            VideoLoja = new HashSet<VideoLoja>();
        }

        public int Id { get; set; }
        public string Modeli { get; set; } = null!;
        public int LokaliId { get; set; }

        public virtual Lokali Lokali { get; set; } = null!;
        public virtual ICollection<Fatura> Fatura { get; set; }
        public virtual ICollection<VideoLoja> VideoLoja { get; set; }
    }
}
