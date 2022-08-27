using GameWatchAPI.Models;

namespace GameWatchAPI.DTOs
{
    public class BiznesiKonzolaDTO
    {
        public string Emri { get; set; } = null!;
        public int KonzolaId { get; set; }
        public int LokaliId { get; set; }
        public bool Statusi { get; set; }
    }

    public class GetBiznesiKonzolaDTO
    {
        public int Id {get; set;}
        public string Emri { get; set; } = null!;
        public int KonzolaId { get; set; }
        public int LokaliId { get; set; }
        public bool? Statusi { get; set; }

        public Konzola Konzola { get; set; }
        public Lokali Lokali { get; set; }
    }
}
