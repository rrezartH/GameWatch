using System;
using System.Collections.Generic;

namespace GameWatchAPI.Models
{
    public partial class BizneziKonzolaVideoloja
    {
        public int Id { get; set; }
        public int BiznesiKonzola { get; set; }
        public int VideoLojaId { get; set; }

        public virtual BiznesiKonzola BiznesiKonzolaNavigation { get; set; } = null!;
        public virtual VideoLoja VideoLoja { get; set; } = null!;
    }
}
