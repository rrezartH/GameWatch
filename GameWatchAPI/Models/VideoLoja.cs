using System;
using System.Collections.Generic;

namespace GameWatchAPI.Models
{
    public partial class VideoLoja
    {
        public VideoLoja()
        {
            Fatura = new HashSet<Fatura>();
        }

        public int Id { get; set; }
        public string Emri { get; set; } = null!;
        public int PlayStationId { get; set; }

        public virtual PlayStation PlayStation { get; set; } = null!;
        public virtual ICollection<Fatura> Fatura { get; set; }
    }
}
