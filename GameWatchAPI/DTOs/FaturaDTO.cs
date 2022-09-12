using GameWatchAPI.Models;

namespace GameWatchAPI.DTOs
{
    public class FaturaDTO
    {
        public string? MbarimiLojes { get; set; }
        public int NrLojtareve { get; set; }
        public decimal? Oret { get; set; }
        public int? BiznesiKonzola { get; set; }
        public int VideoLojaId { get; set; }
        public int LokaliId { get; set; }
        public decimal? CmimiTotal { get; set; }
    }

    public class UpdateFaturaDTO
    {
        public decimal? Oret { get; set; }
        public decimal? CmimiTotal { get; set; }
    }

    public class GetFaturaDTO
    {
        public int Id { get; set; }
        public DateTime FillimiLojes { get; set; }
        public string? MbarimiLojes { get; set; }
        public int NrLojtareve { get; set; }
        public decimal? Oret { get; set; }
        public int? BiznesiKonzola { get; set; }
        public int VideoLojaId { get; set; }
        public int LokaliId { get; set; }
        public decimal? CmimiTotal { get; set; }
        public bool? Closed { get; set; }

        public VideoLoja? VideoLoja { get; set; }
    }

    public class PreviewFaturaDTO
    {
        public string? MbarimiLojes { get; set; }
        public decimal? Oret { get; set; }
        public decimal CmimiTotal { get; set; }    
    }
}
