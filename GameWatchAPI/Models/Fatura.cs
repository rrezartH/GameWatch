using System;
using System.Collections.Generic;

namespace GameWatchAPI.Models
{
    public partial class Fatura
    {
        public int Id { get; set; }
        public string FillimiLojes { get; set; } = null!;
        public string? MbarimiLojes { get; set; }
        public string? DateCreated { get; set; }
        public int NrLojtareve { get; set; }
        public int? BiznesiKonzola { get; set; }
        public int VideoLojaId { get; set; }
        public int LokaliId { get; set; }
        public decimal CmimiTotal { get; set; }

        public virtual BiznesiKonzola? BiznesiKonzolaNavigation { get; set; }
        public virtual Lokali Lokali { get; set; } = null!;
        public virtual VideoLoja VideoLoja { get; set; } = null!;
    }
}
