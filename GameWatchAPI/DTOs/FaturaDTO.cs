namespace GameWatchAPI.DTOs
{
    public class FaturaDTO
    {
        public string FillimiLojes { get; set; } = null!;
        public string? MbarimiLojes { get; set; }
        public int NrLojtareve { get; set; }
        public int? BiznesiKonzola { get; set; }
        public int VideoLojaId { get; set; }
        public int LokaliId { get; set; }
        public decimal CmimiTotal { get; set; }
    }
}
