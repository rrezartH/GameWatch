﻿using System;
using System.Collections.Generic;

namespace GameWatchAPI.Models
{
    public partial class VideoLoja
    {
        public VideoLoja()
        {
            BizneziKonzolaVideoloja = new HashSet<BizneziKonzolaVideoloja>();
            Fatura = new HashSet<Fatura>();
        }

        public int Id { get; set; }
        public string Emri { get; set; } = null!;

        public virtual ICollection<BizneziKonzolaVideoloja> BizneziKonzolaVideoloja { get; set; }
        public virtual ICollection<Fatura> Fatura { get; set; }
    }
}
