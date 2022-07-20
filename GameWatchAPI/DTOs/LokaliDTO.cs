namespace GameWatchAPI.DTOs
{
    public class LokaliDTO
    {
        public string Emri { get; set; } = null!;
        public string NrTel { get; set; } = null!;
        public string Qyteti { get; set; } = null!;
        public string? Adresa { get; set; }
        public int BiznesiId { get; set; }
    }
}
